using System;
using Mapster;

namespace E.S.Api.Helpers.Extensions;

public static class MapExtensions
{
    public static D CopyTo<T, D>(this T request, D domain, bool ignoreNullValues = true)
    {
        TypeAdapterConfig config = TypeAdapterConfig<T, D>
            .NewConfig()
            .IgnoreNullValues(ignoreNullValues).Config;

        request.Adapt(domain, config);

        return domain;
    }
}