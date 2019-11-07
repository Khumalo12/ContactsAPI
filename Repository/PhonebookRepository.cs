using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Repository
{
    public class PhonebookRepository : RepositoryBase<Phonebook>, IPhonebookRepository
    {
        public PhonebookRepository(RepositoryContext respositoryContext) : base(respositoryContext)
        {
        }

        public async Task<Phonebook> GetPhonebook(string phonebook)
        {
            return await FindByCondition(n => n.Name.Equals(phonebook)).SingleAsync();
        }
    }
}
