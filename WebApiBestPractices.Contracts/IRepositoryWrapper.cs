using System.Threading.Tasks;

namespace WebApiBestPractices.Contracts
{
    public interface IRepositoryWrapper 
    {
        IOwnerRepository Owner { get; }

        IAccountRepository Account { get; }

        Task SaveAsync();
    }
}
