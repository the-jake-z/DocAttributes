using System.Reflection;

namespace DocAttributes
{
    internal static class Extensions
    {
        internal static bool IsPropertyAccessor(this MethodInfo methodInfo)
        {
            return methodInfo.Name.StartsWith("get_") || methodInfo.Name.StartsWith("set_");
        }
    }
}