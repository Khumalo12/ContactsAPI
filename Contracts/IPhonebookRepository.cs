﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhonebookRepository : IRepositoryBase<Phonebook>
    {
        Task<Phonebook> GetPhonebook(string phonebook);
    }
}
