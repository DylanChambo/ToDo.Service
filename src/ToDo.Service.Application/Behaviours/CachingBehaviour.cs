using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ToDo.Service.Requests;

namespace ToDo.Service.Application.Behaviours;

/// <summary>
/// Caching behaviour for caching the MediatR request.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <typeparam name="TResponse">Type of the response.</typeparam>
public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheable
{
    private readonly IDistributedCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="CachingBehaviour{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="cache">Cache.</param>
    public CachingBehaviour(IDistributedCache cache)
    {
        _cache = cache;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var cachedValue = await _cache.GetStringAsync(request.CacheKey, cancellationToken).ConfigureAwait(false);

        if (!string.IsNullOrEmpty(cachedValue))
        {
            return JsonSerializer.Deserialize<TResponse>(cachedValue);
        }

        var response = await next().ConfigureAwait(false);
        cachedValue = JsonSerializer.Serialize(response);

        await _cache.SetStringAsync(
            request.CacheKey,
            cachedValue,
            new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(request.CacheDurationInMinutes) },
            cancellationToken).ConfigureAwait(false);

        return response;
    }
}