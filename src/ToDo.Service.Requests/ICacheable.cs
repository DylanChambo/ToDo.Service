namespace ToDo.Service.Requests;

/// <summary>
/// Cacheable
/// </summary>
public interface ICacheable
{
    /// <summary>
    /// Gets the cache key for the cacheable.
    /// </summary>
    string CacheKey { get; }

    /// <summary>
    /// Gets the cache duration in minutes.
    /// </summary>
    int CacheDurationInMinutes => 15;
}