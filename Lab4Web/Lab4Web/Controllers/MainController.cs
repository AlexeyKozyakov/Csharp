
using System.Linq;
using lab4Web.Models;
using lab4Web.Views.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab4Web.Controllers
{
    [Route("/")]
    public class MainController : Controller
    {

        private readonly DataContext _context;

        public MainController(DataContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        [Route("Employee")]
        public IActionResult Employee(int id)
        {
            Employee emp;
            if (id > 0)
            {
                emp = _context.Employees.Find(id);
                ViewBag.controller = "UpdateEmployee";
            }
            else
            {
                emp = new Employee();
                ViewBag.controller = "SaveEmployee";
            }
            return View(emp);
        }

        [Route("Project")]
        public IActionResult Project(int id)
        {
            var employeesDesc = _context.Employees.ToList().Select(s => new
                {
                    s.Id,
                    Description = $" {s.Surname} {s.Name} {s.Patronymic}"
                });
                ViewBag.employees = new SelectList(employeesDesc, "Id",
                    "Description",0);
                Project project;
                if (id > 0)
                {
                    project = _context.Projects.Find(id);
                    ViewBag.controller = "UpdateProject";
                }
                else
                {
                    project = new Project();
                    ViewBag.controller = "SaveProject";
                }
            return View(project);
        }

        [Route("Projects")]
        public IActionResult Projects(int id)
        {
            var emp = _context.Employees.Find(id);
            ViewBag.EmployeeInfo = $"{emp.Surname} {emp.Name} {emp.Patronymic}";
            var projects = emp.Projects.ToList();
            return View(projects);
        }

        [Route("RemoveEmployee")]
        public IActionResult RemoveEmployee(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Route("RemoveProject")]
        public IActionResult RemoveProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Projects", "Main", new {id = project.EmployeeId});
        }

        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Employee", "Main", new {id = emp.Id});
        }

        [Route("UpdateProject")]
        public IActionResult UpdateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Project", "Main", new {id = project.Id});
        }

        [Route("Awards")]
        public IActionResult Awards()
        {
            var res = _context.Projects
                .GroupBy(project => project.Employee)
                .Select(p => new Award {Name = $"{p.Key.Name} {p.Key.Surname} {p.Key.Patronymic}", Value = p.Sum(project => project.Award)})
                .OrderByDescending(p => p.Value)
                .ToList();
            return View(res);
        }
        
    }
}