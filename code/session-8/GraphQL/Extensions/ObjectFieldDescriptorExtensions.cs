using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseUpperCase(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor.Use(next => async context =>
            {
                await next(context);

                if (context.Result is string s)
                {
                    context.Result = s.ToUpperInvariant();
                }
            });
        }
    }
}