﻿namespace RestaurantAPI.Exceptions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
       => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}
