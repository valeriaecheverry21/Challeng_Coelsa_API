using Coelsa.Business.ContactManager.Interface;
using Coelsa.Data.Models;
using Coelsa.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Business.ContactManager.Implementation
{
    public class ContactManager : IContactManager
    {
        private readonly IRepository _repository;

        public ContactManager(IRepository repository) => _repository = repository;


        public bool ContactExists(int id)
        {
            return _repository.Exists(id);
        }

        public Contact GetContactbyId(int id) {
            var result = _repository.GetbyId(id);
            if(result == null)
            {
                return null;
            }
            return result;
        }



        public IEnumerable<Contact> GetAllContactsPaging(ContactsParameters contactsParameters)
        {
            var result = _repository.GetAllPaging(contactsParameters);
            return result;
        }



        public IEnumerable<Contact> GetAllContacts() {
            return _repository.GetAll();
        }

        public Contact AddContact(Contact entity) {
            return _repository.Add(entity);
        }

        public Contact UpdateContact(Contact entity) {
            return _repository.Update(entity);
        }

        public int DeleteContact(Contact entity) {
            return _repository.Delete(entity);
        }
    }
}
