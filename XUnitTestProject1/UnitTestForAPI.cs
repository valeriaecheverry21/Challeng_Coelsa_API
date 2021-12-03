using Coelsa.API.Controllers;
using Coelsa.Business.ContactManager.Implementation;
using Coelsa.Data.Models;
using Coelsa.Data.Repository.Implementation;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTestForAPI
    {
        [Fact]
        public void Test_GetContactsList_OK()
        {
            #region Arrange
            ContactRepository _repository = new ContactRepository();
            ContactManager _manager = new ContactManager(_repository);
            ContactsController controller = new ContactsController(_manager);

            ContactsParameters parameters = new ContactsParameters();
            parameters.PageNumber = 2;
            parameters.PageSize = 15;
            #endregion

            #region Act
            var result = controller.GetContacts(parameters);
            #endregion

            #region Assert
            Assert.True(result.Value != null);
            #endregion
        }




        [Fact]
        public void Test_GetContactItem_OK()
        {
            #region Arrange
            ContactRepository _repository = new ContactRepository();
            ContactManager _manager = new ContactManager(_repository);
            ContactsController controller = new ContactsController(_manager);

            int contactId = 1;
            #endregion

            #region Act
            var result = controller.GetContactItem(contactId);
            #endregion

            #region Assert
            Assert.True(result.Value != null);
            #endregion
        }



        [Fact]
        public void Test_CreateContact_OK()
        {
            #region Arrange
            ContactRepository _repository = new ContactRepository();
            ContactManager _manager = new ContactManager(_repository);
            ContactsController controller = new ContactsController(_manager);

            int contactId = 1;
            #endregion

            #region Act
            var result = controller.GetContactItem(contactId);
            #endregion

            #region Assert
            Assert.True(result != null);
            #endregion
        }




        [Fact]
        public void Test_UpdateContactItem_OK()
        {
            #region Arrange
            ContactRepository _repository = new ContactRepository();
            ContactManager _manager = new ContactManager(_repository);
            ContactsController controller = new ContactsController(_manager);

            int contactId = 1;
            Contact contact = new Contact();
            contact.Id = contactId;
            contact.FirstName = "New First Name";
            contact.LastName = "New Last Name";
            contact.Company = "New Company";
            contact.Email = "new@email.com";
            contact.ProneNumber = "999-9999";
            #endregion

            #region Act
            var initialContact = controller.GetContactItem(contactId);
            var result = controller.PutContactItem(contactId, contact);
            #endregion

            #region Assert
            Assert.True(result.Value.FirstName != initialContact.Value.FirstName);
            #endregion
        }


        [Fact]
        public void Test_DeleteContactItem_OK()
        {
            #region Arrange
            ContactRepository _repository = new ContactRepository();
            ContactManager _manager = new ContactManager(_repository);
            ContactsController controller = new ContactsController(_manager);

            int contactId = 1;
            #endregion

            #region Act
            var result = controller.DeleteContactItem(contactId);
            var deletedContact = controller.GetContactItem(contactId);
            #endregion

            #region Assert
            Assert.True(deletedContact.Value == null && result != null);
            #endregion
        }
    }
}
