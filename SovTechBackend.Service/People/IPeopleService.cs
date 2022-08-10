
using SovTechBackend.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTechBackend.Service.People
{
    public interface IPeopleService
    {
        Task<PeopleDTO> GetAllPeoples();
        Task<PeopleDTO> SearchPeople(string query);
    }
}
