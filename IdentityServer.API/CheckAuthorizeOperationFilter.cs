﻿using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.API
{
    internal class CheckAuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            //check for any existing Authorize attribute 
            var authorizeAttributeExists = context.ApiDescription.ControllerAttributes().OfType<AuthorizeAttribute>().Any()
                || context.ApiDescription.ActionAttributes().OfType<AuthorizeAttribute>().Any();

            if (authorizeAttributeExists)
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
                operation.Security.Add(new Dictionary<string, IEnumerable<string>>
                {
                    { "oauth2", new []{ "IdentityServerApi" } }

                });



            }
        }

    }
}