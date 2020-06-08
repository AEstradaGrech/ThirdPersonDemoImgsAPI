using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ThirdPersonDemoIMGs.Authorization
{
    public static class AuthorizationPoliciesExtensions
    {

        private static AuthorizationPolicyBuilder RequireScope(this AuthorizationPolicyBuilder builder, IEnumerable<string> requiredScopes)
        {
            builder.AddRequirements(new AuthorizationRequirement(requiredScopes));

            return builder;
        }

        private static AuthorizationOptions SetAnonymousTokenPolicy(this AuthorizationOptions options)
        {
            var scopes = new List<string>
            {
                "anonymous", "pr-bronze", "pr-silver", "pr-gold", "empolyee"
            };

            options.AddPolicy("Anonymous", policy => policy.RequireScope(scopes));

            return options;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options => {
                options.SetAnonymousTokenPolicy();
                options.SetEmployeePolicy();
            });

            return services;
        }

        private static AuthorizationOptions SetEmployeePolicy(this AuthorizationOptions options)
        {
            var scopes = new List<string> { "employee" };

            options.AddPolicy("Employees", policy => policy.RequireScope(scopes));

            return options;
        }

    }
}
