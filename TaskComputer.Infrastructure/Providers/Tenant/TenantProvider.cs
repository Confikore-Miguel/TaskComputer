using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace TaskComputer.Infrastructure.Providers.Tenant
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public TenantProvider(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string GetTenantConnectionString()
        {
            var tenantId = _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"].FirstOrDefault();

            if (tenantId == null)
                return _configuration.GetConnectionString("DB") ?? string.Empty;
            return _configuration.GetConnectionString($"DB_{tenantId}") ?? string.Empty;
        }
    }
}