using Coelsa.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Business.ContactManager.Interface
{
    public interface IContactManager
    {
        bool ContactExists(int id);

        Contact GetContactbyId(int id);
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> GetAllContactsPaging(ContactsParameters contactsParameters);
        Contact AddContact(Contact entity);
        Contact UpdateContact(Contact entity);
        int DeleteContact(Contact entity);
    }
}
