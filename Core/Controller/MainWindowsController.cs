using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Controller
{
    public class MainWindowsController
    {
        Entities qz = new Entities();
        public string getUser()
        {
            string a = "";
            var b = qz.AspNetUsers.Select(t => t.Id).FirstOrDefault();
            if (b !="") a = b;
            return a;
        }
    }
}
