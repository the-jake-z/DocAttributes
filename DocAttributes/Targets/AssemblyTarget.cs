using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace DocAttributes.Targets
{
    [Summary("Used to represent entire assemblies and their targets for documentation.")]
    [SeeAlso(typeof(Assembly))]
    public class AssemblyTarget : Target
    {
        [Summary("The list of type documentation contained in this assembly.")]
        public ICollection<TypeTarget> Types { get; protected internal set; }
        
        [Summary("Constructs documentation for an assembly target.")]
        public AssemblyTarget(Assembly assembly)
        {
            Name = assembly.FullName;
            Summary = assembly.GetCustomAttribute<SummaryAttribute>().ToString();
            Types = new List<TypeTarget>();

            foreach (var type in assembly.GetTypes())
            {
                Types.Add(new TypeTarget(type));
            }
        }
    }

}