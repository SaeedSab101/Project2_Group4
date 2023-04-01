using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
