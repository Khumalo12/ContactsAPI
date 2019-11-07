using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IContactRepository : IRepositoryBase<Entry>
    {
        Task<IEnumerable<Entry>> GetContacts(int phonebookId);
        Task<IEnumerable<Entry>> GetContacts(int phonebookId, string name);
        void PostContacts(string name, string phonenumber, int phonebook_id);
    }
}
