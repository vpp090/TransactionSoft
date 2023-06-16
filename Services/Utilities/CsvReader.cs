
using System.Data;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace Services.Utilities
{
    public class CsvReader : ICsvReader<DataTable>
    {
        public async Task<DataTable> ReadCsvFile(IFormFile file)
        {
           var table = new DataTable();
           using(var stream = file.OpenReadStream())
           using(StreamReader sr = new StreamReader(stream))
           {
                var line = await sr.ReadLineAsync();
                var headers = line.Split(',');

                foreach(var header in headers)
                {
                    table.Columns.Add(header);
                }

                while(!sr.EndOfStream)
                {
                     line = await sr.ReadLineAsync();
                     var entries = line.Split(',');
                     var row = table.NewRow();
                    
                     for(int i = 0; i < headers.Length; i++)
                     {
                        row[i] = entries[i];
                     }

                     table.Rows.Add(row);
                }
           }

           return table;
        }
    }
}