using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Boilerplate.Web.CORS
{
    public class CustomCORSAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public CustomCORSAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };

            _policy.Origins.Add("localhost");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}