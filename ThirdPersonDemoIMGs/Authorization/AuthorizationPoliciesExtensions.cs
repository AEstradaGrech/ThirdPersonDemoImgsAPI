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
                "anonymous", "customer","pr-bronze", "pr-silver", "pr-gold", "empolyee"
            };

            options.AddPolicy("Anonymous", policy => policy.RequireScope(scopes));

            return options;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options => {
                options.SetAnonymousTokenPolicy()
                       .SetEmployeePolicy()
                       .SetCustomersPolicy();

            });

            return services;
        }

        private static AuthorizationOptions SetEmployeePolicy(this AuthorizationOptions options)
        {
            var scopes = new List<string> { "employee" };

            options.AddPolicy("Employees", policy => policy.RequireScope(scopes));

            return options;
        }
        private static AuthorizationOptions SetCustomersPolicy(this AuthorizationOptions options)
        {
            var scopes = new List<string> { "customer","pr-bronze", "pr-silver", "pr-gold", "employee" };

            options.AddPolicy("Customers", policy => policy.RequireScope(scopes));

            return options;
        }

    }
}
