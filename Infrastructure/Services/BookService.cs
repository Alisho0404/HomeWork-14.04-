using Domain.DTO_s.BookDto;
using Domain.Enteties;
using Domain.Response;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BookService(DataContext context) : IBookService
    {
        public async Task<Response<string>> AddBookAsync(AddBookDto book)
        {
            try
            {
                var newBook = new Book()
                {
                    Title = book.Title,
                    Author = book.Author,
                    PublishedYear = book.PublishedYear,
                    Genre = book.Genre
                }; 
                await context.Books.AddAsync(newBook);
                var res = await context.SaveChangesAsync();
                if (res>0)
                {
                    return new Response<string>("Succefully added");
                }
                return new Response<string>("Filed to add");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        public async Task<Response<bool>> DeleteBookAsync(int id)
        {
            try
            {
                var existing=await context.Books.FindAsync(id);
                if (existing==null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                } 
                context.Books.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetBookDto>>> GetBookAsync()
        {
            try
            {
                var books = await context.Books.Where(x => x.Id > 0).ToListAsync();
                var list=new List<GetBookDto>();
                foreach (var e in books)
                {
                    var book = new GetBookDto()
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Author = e.Author,
                        PublishedYear = e.PublishedYear,
                        Genre = e.Genre
                    };
                    list.Add(book);
                }
                return new Response<List<GetBookDto>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetBookDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetBookDto>> GetBookByIDAsync(int id)
        {
            try
            {
                var book=await context.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (book==null)
                {
                    return new Response<GetBookDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var result = new GetBookDto()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PublishedYear = book.PublishedYear,
                    Genre = book.Genre
                };
                return new Response<GetBookDto>(result);
            }
            catch (Exception e)
            {
                return new Response<GetBookDto>(HttpStatusCode.InternalServerError, e.Message);
                
            }
        }

        public async Task<Response<string>> UpdateBookAsync(UpdateBookDto book)
        {
            try
            {
                var existingBook=await context.Books.FirstOrDefaultAsync(x=>x.Id==book.Id);
                if (existingBook==null)
                {
                    return new Response<string>("Not Found");
                } 
                existingBook.Title=book.Title;
                existingBook.Author=book.Author;
                existingBook.PublishedYear=book.PublishedYear;
                existingBook.Genre=book.Genre; 
                var result=await context.SaveChangesAsync();
                if (result>0)
                {
                    return new Response<string>("Succesfully updated");
                }
                return new Response<string>("Failed to update");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
            }
        }
    }
}
