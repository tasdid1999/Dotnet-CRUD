using Microsoft.EntityFrameworkCore;
using QuadTheoryTestProject.Data_Access;
using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;
using QuadTheoryTestProject.Repository.InterFace;

namespace QuadTheoryTestProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public StudentRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public async Task AddStudentAsync(StudentViewModel student)
        {
            var _student = new Student
            {
                Id = new Guid(),
                ClassId = student.ClassId,
                Name = student.StudentName,
                Gender = student.Gender,
                DOB = student.DOB,
                CreatedDate = DateTime.Now,
                ModificationDate = DateTime.Now

            };
           var result =  await _dbcontext.students.AddAsync(_student);
           await _dbcontext.SaveChangesAsync();

        }

        public async Task<Student> DeleteStudentAsync(Guid studnetId)
        {
            var RemovableStudent = await _dbcontext.students.FirstAsync(x => x.Id == studnetId);

            
                _dbcontext.students.Remove(RemovableStudent);
                await _dbcontext.SaveChangesAsync();

                return RemovableStudent;

        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudentAsync()
        {
            var query = from a in _dbcontext.students
                        join b in _dbcontext.classes
                        on a.ClassId equals b.Id
                        into Class
                        from b in Class.DefaultIfEmpty()
                        select new StudentViewModel
                        {
                            Id = a.Id,
                            StudentName = a.Name,
                            Gender = a.Gender,
                            ClassId = b.Id,
                            ClassName = b.Name,
                            DOB = a.DOB

                        };

            var ListOfStudent = await query.ToListAsync();

            return ListOfStudent;
        }

        public async Task<StudentViewModel> GetStudentByIdAsync(Guid id)
        {
           var student = await _dbcontext.students.FirstAsync(x => x.Id  == id);

          
                return new StudentViewModel
                {
                    Id = student.Id,
                    StudentName = student.Name,
                    Gender = student.Gender,
                    ClassId = student.ClassId,
                    DOB = student.DOB

                };
            
        }

        public async Task<Student> UpdateStudentAsync(StudentViewModel student)
        {
            var updatableStudent = await _dbcontext.students.FirstAsync(x => x.Id == student.Id);

           
                updatableStudent.Name = student.StudentName;

                updatableStudent.Gender =student.Gender;

                updatableStudent.ClassId = student.ClassId;

                updatableStudent.DOB = student.DOB;

                updatableStudent.ModificationDate = DateTime.Now;

                await _dbcontext.SaveChangesAsync();

                return updatableStudent;
        }
    }
}
