using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderARMProviders
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("OrderARMProviders input.json output.json");
                return;
            }
            string jsonString = File.ReadAllText(args[0], Encoding.UTF8);
            JObject obj = (JObject)JsonConvert.DeserializeObject(jsonString);
            JArray providers = (JArray)obj["value"];
            obj["value"] = new JArray(providers.OrderBy(provider => provider["id"]));
            File.WriteAllText(args[1], JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}
