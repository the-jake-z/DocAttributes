using System;

namespace DocAttributes
{
    [Summary("Allows specifying related types that could be of interest to programmers.")]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class SeeAlsoAttribute : Attribute
    {
        public Type[] Related { get; private set; }

        public SeeAlsoAttribute(params Type[] related)
        {
            Related = related;
        }
    }
}