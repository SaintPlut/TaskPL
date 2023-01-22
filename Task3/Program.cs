using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = File.ReadAllText("values.json");
            var tests = File.ReadAllText("tests.json");

            var dataTests = JsonConvert.DeserializeObject<myJson>(tests);
            var dataValues = JsonConvert.DeserializeObject<myJson>(values);

            foreach (var equalsDate in Reports(dataValues).Where(val => val.Id.HasValue))
            {
                var value = Reports(dataTests).FirstOrDefault(val => equalsDate.Id == val.Id);
                if (value != null)
                {
                    value.Value = equalsDate.Value;
                }
            }
            var options = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            Console.WriteLine(JsonConvert.SerializeObject(dataTests, options));
            Console.ReadKey();
            //var reportString = JsonConvert.SerializeObject(dataTests, options);
            //StreamWriter file = File.CreateText("report.json");
            //file.WriteLine(reportString);
            //file.Close();
        }

        private static IEnumerable<myJson> Reports(myJson jsonFile)
        {
            if (jsonFile.Values != null)
            {
                foreach (var js in jsonFile.Values.SelectMany(Reports))
                {
                    yield return js;
                }
            }
            else
                yield return jsonFile;
        }

        public class myJson
        {
            public int? Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
            public myJson[] Values { get; set; }
        }

    }
}
