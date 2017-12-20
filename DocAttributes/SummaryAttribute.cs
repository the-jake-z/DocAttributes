using System;
using System.Xml.Xsl.Runtime;

namespace DocAttributes
{
    [Summary("This is an example method that can be documents",
        "It accepts a variable number of parameters to join them with new lines.")]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class SummaryAttribute : Attribute
    {
        public string[] SummaryLines { get; private set; }

        public SummaryAttribute(params string[] summaryLines)
        {
            SummaryLines = summaryLines;
        }

        public override string ToString()
        {
            return string.Join(System.Environment.NewLine, SummaryLines);
        }
    }
}