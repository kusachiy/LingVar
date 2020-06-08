using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public static class FileLoader
    {
        public static List<AutoSaleModel> ImportWorkflow()
        {
            List<AutoSaleModel> records;
            using (var reader = new StreamReader(".\\Data\\autos_test.csv", Encoding.GetEncoding(1251), true))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("ru")))
            {
                csv.Configuration.Delimiter = ",";          
                //csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var import = csv.GetRecords<AutoSaleModel>();
                var list = import.ToList();
                records = list;
            }
            return records;
        }
    }
}
