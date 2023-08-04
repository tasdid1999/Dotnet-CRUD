using Microsoft.AspNetCore.Mvc;
using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;
using QuadTheoryTestProject.Repository.Interface;
using QuadTheoryTestProject.Repository.InterFace;

namespace QuadTheoryTestProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        
        public StudentController(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
           
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel student)
        {
            try
            {
               
                if (!ModelState.IsValid)
                {
                    RedirectToAction("AddStudent");
                }
               
                await _studentRepository.AddStudentAsync(student);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                throw new Exception("internal server error!");
            }

        }
        
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var listOfStudent = await _studentRepository.GetAllStudentAsync();

                return View(listOfStudent);
            }
            catch (Exception ex)
            {
                throw new Exception("internal server error!");
            }
           
        }

        public async Task<IActionResult> GetStudentById(Guid id)
        {
            try
            {
                var student = await _studentRepository.GetStudentByIdAsync(id);

                return View(student);
            }
            catch (Exception ex)
            {
                throw new Exception("internal server error!");
            }
        }

        public async Task<IActionResult> UpdateStudent(StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    RedirectToAction("UpdateStudent");
                }
          
                await _studentRepository.UpdateStudentAsync(student);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new Exception("internal server error!");
            }


        }
        public async  Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await _studentRepository.DeleteStudentAsync(id);
                return RedirectToAction("Index", "Home");

            }
            catch(Exception ex)
            {
                throw new Exception("internal server error!");
            }
           
        }

       
    }
}
