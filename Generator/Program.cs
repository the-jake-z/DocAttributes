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
            TypeTarget t1 = new TypeTarget(typeof(GenericTest<,>));

            AssemblyTarget a1 = new AssemblyTarget(typeof(TypeTarget).Assembly);

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            
            Console.WriteLine(JsonConvert.SerializeObject(t1, jsonSerializerSettings));
            Console.ReadKey();
        }
    }

    internal class GenericTest<[Summary("Test")] T1, [Summary("Test2")] T2>
    {
        public T1 Value { get; set; }
        public T2 Value2 { get; set; }

        public string GetString<T3>()
        {
            return string.Empty;
        }
    }
}