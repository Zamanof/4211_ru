using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Page_Intro.Data;
using System.Text;

namespace Razor_Page_Intro.Pages
{
    public class IndexModel : PageModel
    {

        //public IndexModel()
        //{ }
        public string foo(string name)
        {
            return $"{name} foo";
        }
        //public void OnGet(string name, int age)
        //{
        //    ViewData["Name"] = name;
        //    ViewData["Age"] = age;
        //}

        //public void OnGet(Person person)
        //{
        //    ViewData["Name"] = person.Name;
        //    ViewData["Age"] = person.Age;
        //}


        //public void OnGet(string[] names)
        //{
        //    StringBuilder message = new StringBuilder();
        //    foreach(string name in names)
        //    {
        //        message.Append($"{name} ");
        //    }
        //    ViewData["Name"] = message.ToString();
        //    ViewData["Age"] = 0;
        //}

        //public ContentResult OnGet()
        //{
        //    return Content("My content text");
        //}

        private readonly IWebHostEnvironment _environment;

        public IndexModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public FileResult OnGet()
        {
            string path = 
                Path.Combine(_environment.ContentRootPath, "Data/file.txt");
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "Application/txt", "Salam.txt");
        }
    }
}