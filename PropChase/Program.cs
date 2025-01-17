using Microsoft.OpenApi.Models;
using PropChase.DataLayer;
using PropChase.Repository;
using PropChase.Services.User;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<PropChase.Services.Listings.IListingsService, PropChase.Services.Listings.ListingsService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddMemoryCache();
    builder.Services.AddTransient<PropChase.Middleware.ApiKeyMiddleware>();
    builder.Services.AddSingleton<MongoDbContext>();
    builder.Services.AddScoped<IListingRepository, ListingRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    
    // Custom middleware
    app.Use(async (context, next) =>
    {
        var middleware = context.RequestServices.GetRequiredService<PropChase.Middleware.ApiKeyMiddleware>();
        await middleware.InvokeAsync(context, next);
    });
    
    app.MapControllers();
    app.Run();
}