using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nks_backend_auth_demo.Common
{
    public static class ValidateMiddlewareExtensions
    {
        public static void UseValidateMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ValidateMiddleware>();
        }
    }
}