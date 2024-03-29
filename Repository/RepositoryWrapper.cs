﻿using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IContactRepository _contact;
        private IPhonebookRepository _phonebook;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_repoContext);
                }
                return _contact;
            }
        }

        public IPhonebookRepository Phonebook
        {
            get
            {
                if (_phonebook == null)
                {
                    _phonebook = new PhonebookRepository(_repoContext);
                }
                return _phonebook;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
