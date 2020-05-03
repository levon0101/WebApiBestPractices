using System;
using System.Collections.Generic;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}
