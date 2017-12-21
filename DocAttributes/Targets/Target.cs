using System;
using System.Linq;
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
        public string Name { get; protected internal set; }
        [Summary("Describes this particular target.")]
        public string Summary { get; protected internal set; }
        [Summary("Describes classes and types that are related to the target.")]
        public Type[] Related { get; protected internal set; }
        [Summary("Specifies which version this target became available.")]
        public string AvailableVersion { get; protected internal set; }
        [Summary("Specifies which version this target was modified.")]
        public string[] ModifiedVersions { get; protected internal set; }
        [Summary("Specifies if this target is obsolete.")]
        public bool Obsolete { get; protected internal set; }

        [Summary("Constructs a target from MemberInfo")]
        [SeeAlso(typeof(MemberInfo))]
        protected Target(MemberInfo memberInfo)
        {
            Name = memberInfo.Name;
            Summary = memberInfo.GetCustomAttribute<SummaryAttribute>()?.ToString();
            Related = memberInfo.GetCustomAttribute<SeeAlsoAttribute>()?.Related;
            AvailableVersion = memberInfo.GetCustomAttribute<AvailableSinceAttribute>()?.ToString();
            Obsolete = memberInfo.GetCustomAttribute<ObsoleteAttribute>() != null;
            ModifiedVersions = memberInfo.GetCustomAttributes<ModifiedVersionAttribute>()
                .Select(x => x.Version).ToArray();
        }

        [Summary("Constructs target from ParameterInfo")]
        [SeeAlso(typeof(MemberInfo))]
        protected Target(ParameterInfo parameterInfo)
        {
            Name = parameterInfo.Name;
            Summary = parameterInfo.GetCustomAttribute<SummaryAttribute>()?.ToString();
            Related = parameterInfo.GetCustomAttribute<SeeAlsoAttribute>()?.Related;
            AvailableVersion = parameterInfo.GetCustomAttribute<AvailableSinceAttribute>()?.ToString();
            Obsolete = parameterInfo.GetCustomAttribute<ObsoleteAttribute>() != null;
            ModifiedVersions = parameterInfo.GetCustomAttributes<ModifiedVersionAttribute>()
                .Select(x => x.Version).ToArray();
        }

        [Summary("Used for types.")]
        protected Target()
        {
        }
    }
}