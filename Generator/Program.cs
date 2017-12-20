using System;
using DocAttributes.Targets;
using DocAttributes;
using Newtonsoft.Json;

namespace Generator
{
    [Summary("An example program that can generate documentation from annotations.")]
    internal class Program
    {
        public static void Main(string[] args)
        {
            TypeTarget t1 = new TypeTarget(typeof(TypeTarget));

            AssemblyTarget a1 = new AssemblyTarget(typeof(TypeTarget).Assembly);

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            
            Console.WriteLine(JsonConvert.SerializeObject(a1, jsonSerializerSettings));
            Console.ReadKey();
        }
    }
}