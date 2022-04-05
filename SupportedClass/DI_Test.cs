using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project1.Support
{
    public interface IDependency {
        public void SomeMess(string mess);
    }
    public class MyDependency : IDependency {
        public void SomeMess(string mess){
            Console.WriteLine("MyDependency implemented the interface - Message: " + mess);
        }
    }
}