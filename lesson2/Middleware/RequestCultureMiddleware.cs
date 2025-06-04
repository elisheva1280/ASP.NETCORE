

//namespace lesson2.Middleware
using System.Globalization;
using MyFileServiceLib.Interface;

namespace lesson2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestCultureMiddleware
    {

        public string path=@"H:\finalApi\WebApi\action.txt";
        private readonly RequestDelegate _next;
        IFileService<string> _fileServices;

        public RequestCultureMiddleware(RequestDelegate next,IFileService<string> fileService){
            _next = next;
            _fileServices=fileService;
        }
        

        public Task Invoke(HttpContext httpContext)
        {
            var request=httpContext.Request;
       
            _fileServices.Write(path,"time: "+DateTime.Now.ToString());
            _fileServices.Write(path,"method: "+request.Method.ToString());
            _fileServices.Write(path,"body: "+request.Body.ToString());
            _fileServices.Write(path,"headers: "+request.Headers.ToString());
            
            var task=_next(httpContext);
            _fileServices.Write(path,"time: "+DateTime.Now.ToString());
            _fileServices.Write(path,"status code: "+httpContext.Response.StatusCode.ToString());
            _fileServices.Write(path," \n");


            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder Userc(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}