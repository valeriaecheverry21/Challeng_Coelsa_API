using Coelsa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coelsa.Data.Repository.Interface
{
    public interface IRepository
    {
        bool Exists(int id);
        Contact GetbyId(int id);
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> GetAllPaging(ContactsParameters contactsParameters);
        Contact Add(Contact entity);
        Contact Update(Contact entity);
        int Delete(Contact entity);
    }
}
