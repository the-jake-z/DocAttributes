using System;

namespace DocAttributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    [Summary("Describes what version that a particular method, field or class was added.")]
    public class AvailableSinceAttribute: Attribute
    {
        private string Version { get; set; }
        public AvailableSinceAttribute(string version)
        {
            Version = version;
        }

        public override string ToString()
        {
            return Version;
        }
    }
}