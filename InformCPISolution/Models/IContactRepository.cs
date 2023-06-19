﻿namespace InformCPISolution.Models
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
