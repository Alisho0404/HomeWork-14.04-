using Domain.DTO_s.BookDto;
using Domain.Enteties;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IBookService
    {
        Task<Response<List<GetBookDto>>> GetBookAsync(); 
        Task<Response<GetBookDto>>GetBookByIDAsync(int id); 
        Task<Response<string>>AddBookAsync(AddBookDto book);
        Task<Response<string>> UpdateBookAsync(UpdateBookDto book); 
        Task<Response<bool>>DeleteBookAsync(int id);

    }
}
