using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace dtu.blognet.Services.Mapping
{
    public static class MappingConfiguraition
    {
        /// <summary>
        /// Create mappings based on the Services.Mapping assembly profiles.
        /// </summary>
        /// <returns>Configuration from the assembly</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MapperConfiguration GetMappingConfig()
        {
            var assembly = Assembly.Load(new AssemblyName("dtu.blognet.Services.Mapping"));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            var profiles = assembly.ExportedTypes.Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                .Where(t => !t.GetTypeInfo().IsAbstract);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(profiles);
            });
            return config;
        }
    }
}