using System;
using System.Reflection;

namespace DocAttributes.Targets
{
    [Summary("The base class that all targets inherit from. This means that all targets could have",
        "these properties")]
    [SeeAlso(typeof(TypeTarget), typeof(MethodTarget))]
    public abstract class Target
    {
        [Summary("Specified the name of the target.",
            "For classes/structs, it is the fully qualified name")]
        public string Name { get; protected set; }
        public string Summary { get; protected set; }
        public Type[] Related { get; protected set; }
        public string AvailableVersion { get; protected set; }
        public bool Obsolete { get; protected set; }

        protected Target(MemberInfo memberInfo)
        {
            Name = memberInfo.Name;
            Summary = memberInfo.GetCustomAttribute<SummaryAttribute>()?.ToString();
            Related = memberInfo.GetCustomAttribute<SeeAlsoAttribute>()?.Related;
            AvailableVersion = memberInfo.GetCustomAttribute<AvailableSinceAttribute>()?.ToString();
            Obsolete = memberInfo.GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        protected Target(ParameterInfo parameterInfo)
        {
            Name = parameterInfo.Name;
            Summary = parameterInfo.GetCustomAttribute<SummaryAttribute>()?.ToString();
            Related = parameterInfo.GetCustomAttribute<SeeAlsoAttribute>()?.Related;
            AvailableVersion = parameterInfo.GetCustomAttribute<AvailableSinceAttribute>()?.ToString();
            Obsolete = parameterInfo.GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        [Summary("Used for types.")]
        protected Target()
        {
        }
    }
}