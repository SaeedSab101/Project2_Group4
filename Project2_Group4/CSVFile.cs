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
