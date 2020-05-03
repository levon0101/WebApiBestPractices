using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }
    }
}
