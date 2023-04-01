using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
namespace Project2_Group4
{
    public class CSVFile
    {
        public List<T> CSVDeserialize<T>(string filePath)
        {
            var result = new List<T>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    var obj = Activator.CreateInstance<T>();

                    for (int i = 0; i < values.Length; i++)
                    {
                        var propertyInfo = typeof(T).GetProperty($"Column{i + 1}");
                        if (propertyInfo != null)
                        {
                            var convertedValue = Convert.ChangeType(values[i], propertyInfo.PropertyType);
                            propertyInfo.SetValue(obj, convertedValue);
                        }
                    }

                    result.Add(obj);
                }
            }

            return result;
        }

        public List<Infix> populateList(string filePath)
        {
            // SORRY I DDINT NOTICE THE CSVFILE CLASS UNTIL AFTER I DID HTIS, JUST REPLACE IF YOUR VERSION WORKS TOO

            List<Infix> infixList = new();

            // 1. De-serialize CSV input to C# List named InFix (CSVFile class) 
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    // Access the fields of the record using the dynamic keyword
                    var field1 = record.sno;
                    var field2 = record.infix;
                    Infix tempInfix = new(field2);
                    infixList.Add(tempInfix);
                }
            }
            return infixList;
        }
    }
    // might not need to use this

}
