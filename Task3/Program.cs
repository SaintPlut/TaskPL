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
            var tests = "{\"id\": 122, \"title\": \"Security test\", \"value\": \"\", \"values\":[{ \"id\": 5321, \"title\":\"Confidentiality\", \"value\": \"\"},{ \"id\": 5322, \"title\": \"Integrity\", \"value\": \"\"}]}";
            var values = File.ReadAllText("values.json");

            //var tests1 = File.ReadAllText("tests.json"); не успел с файлом 
            
           
            var dataTests = JsonConvert.DeserializeObject<myJson>(tests);
            
            var dataValues = JsonConvert.DeserializeObject<myJson>(values);

            foreach (var equalsDate in GetAllReports(dataValues).Where(val => val.Id.HasValue))
            {
  
                var value = GetAllReports(dataTests).FirstOrDefault(val => equalsDate.Id == val.Id);
     
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
            
            var reportString = JsonConvert.SerializeObject(dataTests, options);
            StreamWriter file = File.CreateText("report.json");
            file.WriteLine(reportString);
            file.Close();
        }
        private static IEnumerable<myJson> GetAllReports(myJson jsonFile)
        {
            yield return jsonFile;
            if (jsonFile.Values != null)
            {
                foreach (var js in jsonFile.Values.SelectMany(GetAllReports))
                {
                    yield return js;
                }
            }
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
