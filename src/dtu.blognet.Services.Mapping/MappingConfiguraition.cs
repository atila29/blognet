using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace dtu.blognet.Services.Mapping
{
    public static class MappingConfiguraition
    {
        public static MapperConfiguration GetMappingConfig()
        {
            var assembly = Assembly.Load(new AssemblyName("dtu.blognet.Services.Mapping"));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(assembly);
            });
            return config;
        }
    }
}