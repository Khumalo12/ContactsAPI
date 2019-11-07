using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IContactRepository Contact { get; }
        IPhonebookRepository Phonebook { get; }
        Task SaveAsync();
    }
}
