
using EmployeeManagement.UI.Services.Departments;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentApiService _departmentService;

        public DepartmentController(IDepartmentApiService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _departmentService.GetAllDepartmentsAsync();
            if (result.IsSuccess)
            {
                return View(result.Value);
            }

            return View("Error");
        }
    }
}