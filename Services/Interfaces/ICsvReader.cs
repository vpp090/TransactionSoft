

using Microsoft.AspNetCore.Http;

namespace Services.Interfaces
{
    public interface ICsvReader<T>
    {
        Task<T> ReadCsvFile(IFormFile file);
    }
}