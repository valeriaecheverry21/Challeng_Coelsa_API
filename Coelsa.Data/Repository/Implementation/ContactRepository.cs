using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Coelsa.Data.Models;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using Coelsa.Data.Repository.Interface;

namespace Coelsa.Data.Repository.Implementation
{
    public class ContactRepository : IRepository
    {
        private IDbConnection db = new SqlConnection("Data Source=PF1LZJ1320L6\\SQLEXPRESS ;Initial Catalog=CoelsaDB; Integrated Security=sspi");

        public bool Exists(int id)
        {
            string query = "SELECT COUNT(*) FROM dbo.Contacts WHERE Id = @Id";
            var result = this.db.Query<Contact>(query, new { Id = id }).SingleOrDefault();
            return result != null;
        }


        public Contact GetbyId(int id)
        {
            string query = "SELECT [Id],[FirstName],[LastName],[Company],[Email],[PhoneNumber] FROM [dbo].[Contacts] ";
            query += "WHERE [Id] = @Id ";
            return this.db.Query<Contact>(query, new { Id = id }).FirstOrDefault();   
        }



        public IEnumerable<Contact> GetAllPaging(ContactsParameters contactsParameters)
        {
            string query = "SELECT [Id],[FirstName],[LastName],[Company],[Email],[PhoneNumber] FROM [dbo].[Contacts] ";
            using (var multipleResults = this.db.QueryMultiple(query))
            {
                var contacts = multipleResults.Read<Contact>().ToList();
                return contacts.OrderBy(x => x.Id)
                    .Skip((contactsParameters.PageNumber - 1) * contactsParameters.PageSize)
                    .Take(contactsParameters.PageSize)
                    .ToList();
            }
        }


        public IEnumerable<Contact> GetAll()
        {
            string query = "SELECT [Id],[FirstName],[LastName],[Company],[Email],[PhoneNumber] FROM [dbo].[Contacts] ";
            using (var multipleResults = this.db.QueryMultiple(query))
            {
                var contacts = multipleResults.Read<Contact>().ToList();
                return contacts;
            }
        }


        public Contact Add(Contact contact)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FirstName", value: contact.FirstName);
            parameters.Add("@LastName", value: contact.LastName);
            parameters.Add("@Company", value: contact.Company);
            parameters.Add("@Email", value: contact.Email);
            parameters.Add("@PhoneNumber", value: contact.ProneNumber);

            var id = this.db.Execute("InsertContactSP", parameters, commandType: CommandType.StoredProcedure);
            contact.Id = parameters.Get<int>("@Id");
            return contact;
        }



        public Contact Update(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", value: contact.Id, dbType: DbType.Int32);
            parameters.Add("@FirstName", value: contact.FirstName);
            parameters.Add("@LastName", value: contact.LastName);
            parameters.Add("@Company", value: contact.Company);
            parameters.Add("@Email", value: contact.Email);
            parameters.Add("@PhoneNumber", value: contact.ProneNumber);

            var id = this.db.Execute("UpdateContactSP", parameters, commandType: CommandType.StoredProcedure);
            contact.Id = parameters.Get<int>("@Id");
            return contact;
        }


        public int Delete(Contact contact)
        {
            return this.db.Execute("DELETE FROM dbo.Contacts WHERE Id = @Id ", new { contact.Id });
        }
    }
}
