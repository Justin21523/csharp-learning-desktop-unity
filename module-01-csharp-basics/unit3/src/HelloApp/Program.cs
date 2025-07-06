using System;
using Newtonsoft.Json;
using UtilsLib;  // 假設 UtilsLib 裡有擴充方法

namespace HelloApp
{
    class Program
    {
        static void Main()
        {
            var obj = new { Name = "Alice", Age = 30 };
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);
        }
    }
}
