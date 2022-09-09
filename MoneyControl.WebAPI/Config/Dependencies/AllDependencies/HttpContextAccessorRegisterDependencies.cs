namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class HttpContextAccessorRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
    }
}
