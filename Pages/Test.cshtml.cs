using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Support;
using System.Collections.Generic;

namespace Project1.Pages {
    public class TestModel : PageModel {
        private readonly IDependency _myDependency;
        public TestModel(IDependency myDependency){
            _myDependency = myDependency;
        }
        public IActionResult OnGet(){
            _myDependency.SomeMess("Hello World");
            return Page();
        }
    }
}