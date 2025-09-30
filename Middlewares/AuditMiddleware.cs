// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using isg_crm.Models;
// using isg_crm.Data;

// namespace isg_crm.Middlewares
// {
//     public class AuditMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public AuditMiddleware(RequestDelegate next)
//         {
//             _next = next;
//         }

//         public async Task InvokeAsync(HttpContext context, AppDbContext db)
//         {
//             var request = context.Request;
//             request.EnableBuffering();

//             string requestBody = "";
//             if (request.ContentLength > 0)
//             {
//                 request.Body.Position = 0;
//                 using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
//                 requestBody = await reader.ReadToEndAsync();
//                 request.Body.Position = 0;
//             }
//             var originalBodyStream = context.Response.Body;
//             using var responseBody = new MemoryStream();
//             context.Response.Body = responseBody;

//             await _next(context);

//             context.Response.Body.Seek(0, SeekOrigin.Begin);
//             var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
//             context.Response.Body.Seek(0, SeekOrigin.Begin);

//             var log = new AuditLog
//             {
//                 Path = request.Path,
//                 Method = request.Method,
//                 Query = request.QueryString.ToString(),
//                 Body = requestBody,
//                 User = context.User.FindFirst("email")?.Value ?? "Anonymous",
//                 IpAddress = context.Connection.RemoteIpAddress?.ToString(),
//                 StatusCode = context.Response.StatusCode,
//                 ResponseBody = responseText

//             };
//             db.AuditLogs.Add(log);
//             await db.SaveChangesAsync();

//             await responseBody.CopyToAsync(originalBodyStream);
//         }


//     }
// }

using System.Text;
using isg_crm.Data;
using isg_crm.Models;
using Microsoft.AspNetCore.Http;

namespace isg_crm.Middlewares
{
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            var request = context.Request;
            request.EnableBuffering();

            // ✅ Request body oku
            string requestBody = string.Empty;
            if (request.ContentLength > 0 && request.Body.CanSeek)
            {
                request.Body.Position = 0;
                using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
                requestBody = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }

            // ✅ Response yakala
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            // ✅ Kullanıcı bilgisi (JWT claim)
            var user = context.User.FindFirst("email")?.Value
                       ?? context.User.FindFirst("name")?.Value
                       ?? context.User.Identity?.Name
                       ?? "Anonymous";

            // ✅ Audit kaydı oluştur
            var log = new AuditLog
            {
                Path = request.Path,
                Method = request.Method,
                Query = request.QueryString.ToString(),
                Body = requestBody,
                User = user,
                IpAddress = context.Connection.RemoteIpAddress?.ToString(),
                StatusCode = context.Response.StatusCode,
                ResponseBody = responseText,
                CreatedAt = DateTime.UtcNow
            };

            db.AuditLogs.Add(log);
            await db.SaveChangesAsync();

            // ✅ Response geri yaz
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
