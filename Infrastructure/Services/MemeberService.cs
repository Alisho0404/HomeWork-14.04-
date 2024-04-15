using Domain.DTO_s.BookDto;
using Domain.DTO_s.MemberDto;
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
    public class MemeberService(DataContext context) : IMemeberService
    {
        public async Task<Response<string>> AddMemberAsync(AddMemeberDTO member)
        {
            try
            {
                var newMember = new Member()
                {
                    FirstName= member.FirstName,
                    LastName=member.LastName,
                    MembershipDate= member.MembershipDate
                };
                await context.Members.AddAsync(newMember);
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

        public async Task<Response<bool>> DeleteMemberAsync(int id)
        {
            try
            {
                var existing = await context.Members.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                }
                context.Members.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetMemeberDTO>>> GetMemberAsync()
        {
            try
            {
                var members = await context.Members.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetMemeberDTO>();
                foreach (var e in members)
                {
                    var member = new GetMemeberDTO()
                    {
                        Id = e.Id,
                        FirstName=e.FirstName,
                        LastName=e.LastName,
                        MembershipDate=e.MembershipDate
                    };
                    list.Add(member);
                }
                return new Response<List<GetMemeberDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetMemeberDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetMemeberDTO>> GetMemberByIDAsync(int id)
        {
            try
            {
                var member = await context.Members.FirstOrDefaultAsync(x => x.Id == id);
                if (member == null)
                {
                    return new Response<GetMemeberDTO>(HttpStatusCode.BadRequest, "Not found");
                }
                var result = new GetMemeberDTO()
                {
                    Id = member.Id,
                    FirstName=member.FirstName, 
                    LastName=member.LastName, 
                    MembershipDate=member.MembershipDate
                };
                return new Response<GetMemeberDTO>(result);
            }
            catch (Exception e)
            {
                return new Response<GetMemeberDTO>(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        public async Task<Response<string>> UpdateMemberAsync(UpdateMemeberDTO member)
        {
            try
            {
                var existingMember = await context.Members.FirstOrDefaultAsync(x => x.Id == member.Id);
                if (existingMember == null)
                {
                    return new Response<string>("Not Found");
                } 
                existingMember.FirstName = member.FirstName;
                existingMember.LastName = member.LastName;
                existingMember.MembershipDate = member.MembershipDate;
                
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
