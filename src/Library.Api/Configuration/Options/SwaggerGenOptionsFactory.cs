﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Library.Api.Configuration.Options
{
    public static class SwaggerGenOptionsFactory
    {
        public static Action<SwaggerGenOptions> Create()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var openApiInfo = new OpenApiInfo
            {
                Title = "Library API",
                Version = "v1",
                Description = "Recursos são responsáveis por gerenciar biblioteca.",
            };

            return options =>
            {
                options.SwaggerDoc("v1", openApiInfo);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.OrderActionsBy(d => d.GroupName);
                options.EnableAnnotations();
                options.CustomSchemaIds(x => x.FullName);
                options.DescribeAllParametersInCamelCase();
            };
        }
    }
}
