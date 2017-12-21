using System.Reflection;

namespace DocAttributes
{
    [Summary("Extension methods used for various types throughout the DocAttributes assembly.")]
    public static class Extensions
    {
        [Summary("Determines if a given MethodInfo is also a property accessor.")]
        public static bool IsPropertyAccessor(this MethodInfo methodInfo)
        {
            // Since there is no property on MethodInfo to identify if it comes from a field or property,
            // we can check the name to roughly determine if it belongs to a property accessor.
            // Note: this may have adverse effects for methods named in snake_case, but since most C#
            // programmers use camelCase or PascalCase, it shouldn't be a huge deal.
            return methodInfo.Name.StartsWith("get_") || methodInfo.Name.StartsWith("set_");
        }
    }
}