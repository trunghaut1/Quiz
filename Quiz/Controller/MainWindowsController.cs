using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Controller
{
    class MainWindowsController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public int getUser()
        {
            int a = 0;
            var b = qz.Users.Select(t => t.Id).FirstOrDefault();
            if (b > 0) a = b;
            return a;
        }
    }
}
