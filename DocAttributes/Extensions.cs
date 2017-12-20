using System.Reflection;

namespace DocAttributes
{
    public static class Extensions
    {
        public static bool IsPropertyAccessor(this MethodInfo methodInfo)
        {
            return methodInfo.Name.StartsWith("get_") || methodInfo.Name.StartsWith("set_");
        }
    }
}