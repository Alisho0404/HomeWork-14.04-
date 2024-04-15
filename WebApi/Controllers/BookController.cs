using Domain.DTO_s.BookDto;
using Domain.DTO_s.MemberDto;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetBookDto>>> GetBookAsync()
        {
            return await bookService.GetBookAsync();
        }

        [HttpGet("{bookId:int}")]
        public async Task<Response<GetBookDto>> GetBookByIdAsync(int bookId)
        {
            return await bookService.GetBookByIDAsync(bookId);
        }

        [HttpPost]
        public async Task<Response<string>> AddBookAsync(AddBookDto bookDTO)
        {
            return await bookService.AddBookAsync(bookDTO);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateBookAsync(UpdateBookDto bookDTO)
        {
            return await bookService.UpdateBookAsync(bookDTO);
        }

        [HttpDelete("{bookId:int}")]
        public async Task<Response<bool>> DeleteBookAsync(int bookId)
        {
            return await bookService.DeleteBookAsync(bookId);
        }
    }
}
