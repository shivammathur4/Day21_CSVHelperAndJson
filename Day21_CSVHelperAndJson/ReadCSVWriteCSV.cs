using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
//using Json.Net;
using Newtonsoft.Json;

namespace Day21_CSVHelperAndJson
{
    class ReadCSVWriteCSV
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\SHIVAM MATHUR\source\repos\Day21_CSVHelperAndJson\Day21_CSVHelperAndJson\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\SHIVAM MATHUR\source\repos\Day21_CSVHelperAndJson\Day21_CSVHelperAndJson\Utility\export.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);

                }
                Console.WriteLine("**********************Reading fromcsv file and Write to csv file **************************");

                //Writing json file
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
