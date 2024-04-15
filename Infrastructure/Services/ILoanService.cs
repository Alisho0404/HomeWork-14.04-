using Domain.DTO_s.LoanDto;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ILoanService
    {
        Task<Response<List<GetLoanDTO>>>GetLoansAsync();
        Task<Response<GetLoanDTO>>GetLoanById(int id);
        Task<Response<string>> AddLoanAsync(AddLoanDTO loan); 
        Task<Response<string>> UpdateLoanAsync(UpdateLoanDTO loan);  
        Task<Response<bool>> DeleteLoanAsync(int id);
       
    }
}
