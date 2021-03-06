﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Application.Web.ConfigurationObjects;
using dtu.blognet.Application.Web.Models.AccountViewModels;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.AccountQueries;
using dtu.blognet.Core.Query.QueryFactories;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace dtu.blognet.Application.Web.Controllers
{
    /// <summary>
    /// source : https://auth0.com/blog/asp-dot-net-core-authentication-tutorial/
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtConfiguration _config;
        
        public AccountController(
            IOptions<JwtConfiguration> options, 
            UserManager<Account> userManager, 
            SignInManager<Account> signInManager, 
            IOptions<JwtConfiguration> config,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config.Value;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile([FromServices] AccountQueryFactory accountQueryFactory)
        {
            var userId = _userManager.GetUserId(User);
            var query = new AccountFromIdQuery{Id = userId};
            var user = accountQueryFactory.Build(query).Get();
            var viewModel = _mapper.Map<AccountViewModel>(user);
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Credentials credentials)
        {
            await Register(ModelState, credentials);
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> ApiRegister([FromBody] Credentials credentials)
        {
            try
            {
                var account = await Register(ModelState, credentials);
                return new JsonResult(  new Dictionary<string, object>
                {
                    { "access_token", GetAccessToken(credentials.Email) },
                    { "id_token", GetIdToken(account) }
                });
            }
            catch (ArgumentException)
            {
                //TODO: add logger!!
                return Error("Unexpected error");
            }
            catch (AuthenticationException)
            {
                return new JsonResult("Unable to sign in") {StatusCode = 401};
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> ApiLogin(Credentials credentials)
        {   
            try
            {
                var account = await Login(ModelState, credentials);
                return new JsonResult(  new Dictionary<string, object>
                {
                    { "access_token", GetAccessToken(credentials.Email) },
                    { "id_token", GetIdToken(account) }
                });
            }
            catch (ArgumentException)
            {
                //TODO: add logger!!
                return Error("Unexpected error");
            }
            catch (AuthenticationException)
            {
                return new JsonResult("Unable to sign in") {StatusCode = 401};
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            await Login(ModelState, credentials);
            return RedirectToAction("Profile");
        }

        private async Task<Account> Register(ModelStateDictionary modelState, Credentials credentials)
        {
            if (!ModelState.IsValid) throw new ArgumentException();
            
            var user = new Account { UserName = credentials.Email, Email = credentials.Email };
            var result = await _userManager.CreateAsync(user, credentials.Password);
            
            if (!result.Succeeded) throw new AuthenticationException();
            
            await _signInManager.SignInAsync(user, isPersistent: false);
            return user;
        }


        private async Task<Account> Login(ModelStateDictionary modelState, Credentials credentials)
        {
            if (!ModelState.IsValid) throw new ArgumentException();
            
            var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);
            if (!result.Succeeded) throw new AuthenticationException();
            
            return await _userManager.FindByEmailAsync(credentials.Email);
        }
        
        
        private string GetIdToken(IdentityUser user) {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "sub", user.Email },
                { "email", user.Email },
                { "emailConfirmed", user.EmailConfirmed },
            };
            return GetToken(payload);
        }

        private string GetAccessToken(string email) {
            var payload = new Dictionary<string, object>
            {
                { "sub", email },
                { "email", email }
            };
            return GetToken(payload);
        }

        private string GetToken(Dictionary<string, object> payload) {
            var secret = _config.SecretKey;

            payload.Add("iss", _config.Issuer);
            payload.Add("aud", _config.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }

        private JsonResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) {StatusCode = 400};
        }

        private JsonResult Error(string message)
        {
            return new JsonResult(message) {StatusCode = 400};
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        
        
    }
}