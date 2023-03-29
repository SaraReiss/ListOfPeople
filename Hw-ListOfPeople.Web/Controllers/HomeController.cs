using Hw_ListOfPeople.Data;
using Hw_ListOfPeople.Web.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hw_ListOfPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=People; Integrated Security=true;";
        public IActionResult Index()
        {
            var db = new PersonManager(_connectionString);
            var vm = new PersonVeiwModel
            {
                People = db.GetAll(),
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);

           
        }
        public IActionResult Add(List<Person> people)
        {
            var manager = new PersonManager(_connectionString);
            //foreach (var person in people)
            //{
            //    (another way - disable the button untill form is valid in js...)
            //    if (person.FirstName == null || person.LastName == null || person.Age == null)
            //    {
            //        return Redirect("/home/showadd");
            //    }
            //    else
            //    {
            //        manager.Add(person);
            //    }

            //}
            manager.AddMany(people);



            if (people.Count >=2)
            {
                TempData["message"] = $"{people.Count} people have been successfully added!";
                
            }
                else if  (people.Count == 1)
            {
                TempData["message"] = $"{people.Count} person  has been successfully added!";
            }
                else 
            {
                TempData["message"] = $"";
            }
               
            return Redirect("/home/index");
        }
        public IActionResult ShowAdd()
        {
            return View();
        }

    }
}