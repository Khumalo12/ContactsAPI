using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Entry>, IContactRepository
    {
        public ContactRepository(RepositoryContext respositoryContext) : base(respositoryContext)
        {
        }

        public async Task<IEnumerable<Entry>> GetContacts(int phonebookId)
        {
            return await FindByCondition(x => x.Phonebook_id.Equals(phonebookId))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Entry>> GetContacts(int phonebookId, string name)
        {
            return await FindByCondition(x => x.Phonebook_id.Equals(phonebookId))
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
        }

        public Task<Entry> PostContacts(string name, string phonenumber, int phonebook_id)
        {
            throw new NotImplementedException();
        }
    }
}
