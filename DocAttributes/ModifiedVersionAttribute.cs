using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAttributes
{
    [Summary("Allows for programmers to keep track of which version a specific",
        "target was modified.")]
    [AvailableSince("1.0")]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class ModifiedVersionAttribute : Attribute
    {
        public string Version { get; protected set; }

        public ModifiedVersionAttribute(string version)
        {
            Version = version;
        }
    }
}
