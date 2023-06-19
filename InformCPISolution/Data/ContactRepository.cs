using System.Collections.Generic;
using System.Linq;
using InformCPISolution.Models;
using InformCPISolution.Utilities;
using Microsoft.EntityFrameworkCore;


namespace InformCPISolution.Data
{

    public class ContactRepository : IContactRepository
    {
        private readonly InformCPIDbContext _dbContext;

        public ContactRepository(InformCPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contact> GetAllContacts()
        {
            try
            {
                return _dbContext.Contact.ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to get contacts.", ex);
            }
        }

        public Contact GetContactById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid contact ID.");

                return _dbContext.Contact.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Failed to get contact with ID {id}.", ex);
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                if (contact == null)
                    throw new ArgumentNullException(nameof(contact), "Contact object is null.");

                _dbContext.Contact.Add(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to add contact.", ex);
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                if (contact == null)
                    throw new ArgumentNullException(nameof(contact), "Contact object is null.");

                _dbContext.Entry(contact).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to update contact.", ex);
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid contact ID.");

                var contact = _dbContext.Contact.Find(id);
                if (contact != null)
                {
                    _dbContext.Contact.Remove(contact);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Failed to delete contact with ID {id}.", ex);
            }
        }
    }



}
