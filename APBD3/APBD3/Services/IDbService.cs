using APBD3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD3.Services
{
    public interface IDbService
    {
        Task<IList<Book>> GetBookListAsync();
    }
}
