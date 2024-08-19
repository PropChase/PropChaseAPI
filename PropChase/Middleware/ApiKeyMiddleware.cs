using PropChase.Repository;
namespace PropChase.Middleware;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ApiKeyMiddleware
{
    private readonly IMemoryCache _cache;
    private readonly IListingRepository _listingRepository;

    public ApiKeyMiddleware(IMemoryCache cache, IListingRepository listingRepository)
    {
        _cache = cache;
        _listingRepository = listingRepository;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var apiKey = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (!_cache.TryGetValue(apiKey, out bool isValid))
        {
            isValid = await ValidateApiKey(apiKey);
            _cache.Set(apiKey, isValid, TimeSpan.FromMinutes(10));
        }

        if (!isValid)
        {
            context.Response.StatusCode = 401; 
            return;
        }

        await next(context);
    }

    private async Task<bool> ValidateApiKey(string apiKey)
    {
        var user = await _listingRepository.GetUserByApiKeyAsync(apiKey);
        return user != null;
    }
}