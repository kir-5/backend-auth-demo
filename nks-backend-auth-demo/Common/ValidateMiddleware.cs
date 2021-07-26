using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using nks_backend_auth_demo.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace nks_backend_auth_demo.Common
{
    public class ValidateMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context/*, IUserService userService, IJwtUtils jwtUtils*/)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if(token != null)
                {
                    var jwtSecurityToken = new JwtSecurityToken(jwtEncodedString: token);
                    var login = jwtSecurityToken.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
                    if (login == "admin@gmail.com")
                    {
                        //что доступно
                        //I вариант: получить url и найти в нём слово
                        var method = context.Request.Method;
                        var url = context.Request.Path.Value;
                        string[] tempArray = url.Split('/');
                        if(tempArray[2] != "staffs" && method == "GET")
                        {
                            throw new Exception("Access is forbidden");
                        }

                        //II вариант: обращаемся к БД и в таблице roleRecourseRelation проверяем доступен ли данный ресурс данному пользователю
                        //
                    }
                }
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            string result = JsonConvert.SerializeObject(new Error
            {
                Message = exception.Message
            });
            Log.Error(exception, "Ошибка");
            return context.Response.WriteAsync(result);
        }
    }
}