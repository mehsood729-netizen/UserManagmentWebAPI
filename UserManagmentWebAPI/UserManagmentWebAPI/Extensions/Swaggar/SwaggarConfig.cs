namespace UserManagmentWebAPI.Extensions.Swaggar
{
    public static class SwaggarConfig
    {
        public static IServiceCollection SwaggarConfigration(this IServiceCollection services) =>
            services.AddSwaggerGen();
    }
}
