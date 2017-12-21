using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocAttributes
{
    [Summary("Allows for programmers to keep track of which version a specific",
        "target was modified.")]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class ModifiedVersionAttribute : Attribute
    {
        [Summary("The version this item was modified.")]
        public string Version { get; private set; }

        public ModifiedVersionAttribute(string version)
        {
            Version = version;
        }
    }
}
