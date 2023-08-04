using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuadTheoryTestProject.Data_Access;
using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;
using QuadTheoryTestProject.Repository.Interface;

namespace QuadTheoryTestProject.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ClassRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public  async Task<List<Class>> GetAllClassAsync()
        {
            var list = await _dbcontext.classes.ToListAsync();

            return list;
            
        }
    }
}
