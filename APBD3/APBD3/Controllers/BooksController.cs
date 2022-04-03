using APBD3.Models;
using APBD3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<IActionResult> GetBooksList()
        {
            //DbService db = new(); NIEDOBRE PODEJŚCIE

            IList<Book> result = await _dbService.GetBookListAsync();

            return Ok(result);
        }

    }
}
