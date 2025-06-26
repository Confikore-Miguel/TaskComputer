namespace TaskComputer.Infrastructure.Providers.Tenant
{
    public interface ITenantProvider
    {
        string GetTenantConnectionString();
    }
}
