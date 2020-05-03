using System.Threading.Tasks;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;

namespace WebApiBestPractices.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _dbContext;
        private readonly IOwnerRepository _owner;
        private readonly IAccountRepository _account;

        public RepositoryWrapper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IOwnerRepository Owner => _owner ?? new OwnerRepository(_dbContext); // todo think about thread safe

        public IAccountRepository Account => _account ?? new AccountRepository(_dbContext); // todo think about thread safe

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();  
        }
    }
}
