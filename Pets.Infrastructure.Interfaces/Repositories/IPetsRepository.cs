using System.Threading.Tasks;

namespace Pets.Infrastructure.Interfaces.Repositories
{
    public interface IPetsRepository
    {
        Task Add(Pet pet);
    }
}