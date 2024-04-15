using Domain.DTO_s.BookDto;
using Domain.DTO_s.LoanDto;
using Domain.Enteties;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LoanService(DataContext context) : ILoanService
    {
        public async Task<Response<string>> AddLoanAsync(AddLoanDTO loan)
        {
            try
            {
                var newLoan = new Loan()
                { 
                    BookId=loan.BookId,
                    MemeberId=loan.MemeberId,
                    LoanDate=loan.LoanDate,
                    ReturnDate=loan.ReturnDate
                };
                await context.Loans.AddAsync(newLoan);
                var res = await context.SaveChangesAsync();
                if (res > 0)
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

        public async Task<Response<bool>> DeleteLoanAsync(int id)
        {
            try
            {
                var existing = await context.Loans.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                }
                context.Loans.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetLoanDTO>> GetLoanById(int id)
        {
            try
            {
                var loan = await context.Loans.FirstOrDefaultAsync(x => x.Id == id);
                if (loan == null)
                {
                    return new Response<GetLoanDTO>(HttpStatusCode.BadRequest, "Not found");
                }
                var result = new GetLoanDTO()
                { 
                    Id=loan.Id,
                    BookId = loan.Id, 
                    MemeberId=loan.MemeberId,
                    LoanDate=loan.LoanDate,
                    ReturnDate=loan.ReturnDate
                    
                };
                return new Response<GetLoanDTO>(result);
            }
            catch (Exception e)
            {
                return new Response<GetLoanDTO>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<List<GetLoanDTO>>> GetLoansAsync()
        {
            try
            {
                var loans = await context.Loans.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetLoanDTO>();
                foreach (var e in loans)
                {
                    var loan = new GetLoanDTO()
                    {
                        Id = e.Id,
                        BookId = e.BookId,
                        MemeberId = e.MemeberId,
                        LoanDate = e.LoanDate,
                        ReturnDate = e.ReturnDate
                    };
                    list.Add(loan);
                }
                return new Response<List<GetLoanDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetLoanDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateLoanAsync(UpdateLoanDTO loan)
        {
            try
            {
                var existingLoan = await context.Loans.FirstOrDefaultAsync(x => x.Id == loan.Id);
                if (existingLoan == null)
                {
                    return new Response<string>("Not Found");
                }
                existingLoan.BookId=loan.BookId;
                existingLoan.MemeberId=loan.MemeberId;
                existingLoan.LoanDate=loan.LoanDate;
                existingLoan.ReturnDate=loan.ReturnDate;
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new Response<string>("Succesfully updated");
                }
                return new Response<string>("Failed to update");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
