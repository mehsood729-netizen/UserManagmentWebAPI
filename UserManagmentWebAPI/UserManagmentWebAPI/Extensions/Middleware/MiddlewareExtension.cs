namespace UserManagmentWebAPI.Extensions.Middleware
{
    public static class MiddlewareExtension
    {
        public static WebApplication MiddlewareConfig(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
