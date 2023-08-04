using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;

namespace QuadTheoryTestProject.Repository.Interface
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClassAsync();
    }
}
