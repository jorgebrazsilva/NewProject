using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scouter.Web.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request != null)
            {
                return (request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest");
            }
            return false;
        }
    }
}
