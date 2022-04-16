using APBD3.Models;
using APBD3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDbService _dbService;

        public BooksController(IDbService dbService)
        {
            _dbService = dbService;
        }

        // GET: localhost:XXXXX/api/books?orderBy=title
        // W tym przypadku wartość dla klucza orderBy pobieramy z tzw. query parameters, które następują po "?" w adresie URL
        // Żeby mapowanie nastąpiło automatycznie, nazwa argumentu metody i klucz w URL muszą być takie same
        // Jeżeli chcemy przekazać więcej query parameters oddzielamy je od siebie "&", np.
        // GET: localhost:XXXXX/api/books?orderBy=title&sortBy=idBook
        [HttpGet]
        public async Task<IActionResult> GetBooks(string orderBy)
        {
            //DbService db = new(); NIEDOBRE PODEJŚCIE

            IList<Book> result = await _dbService.GetBookListAsync();

            return Ok(result);
        }

        // GET: localhost:XXXXXX/api/books/tytulA
        // GET: localhost:XXXXXX/api/books/tytulB
        // To jest tylko przykład, który nie jest zbyt poprawny RESTowo, więc proszę się tym nie wzorować :)
        [HttpGet("{title}")]
        public async Task<IActionResult> GetBook(string title)
        {
            Book book = await _dbService.GetBookByTitleAsync(title);

            return Ok(book);
        }

        // Przekazywany w ciele żądania obiekt, reprezentujący określony zasób, jest zapisany w formacie JSON.
        // My w naszym API musimy go zdeserializować na obiekt C#.
        // W tym celu wystarczy jako argument metody (końcówki) przekazać obiekt, na który powinna nastąpić deserializacja
        // .NET sam sobie poradzi z tym i odczyta nasze intencje bez problemu
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            // Po poprawnie przesłanym żądaniu: POST localhost:XXXX/api/books
            // obiekt book powinien zostać zainicjalizowany wartościami przesłanymi w ciele żądania
            return Ok();
        }
    }
}
