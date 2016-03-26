using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.Controller
{
    public class SubjectController
    {
        Entities qz = new Entities();
        public List<SubButton> loadSubjectButton()
        {
            try
            {
                List<SubButton> _subButton = new List<SubButton>();
                _subButton = qz.SubButtons.ToList();
                return _subButton;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<Subject> getAllSubject()
        {
            return qz.Subjects.ToList();
        }
    }
}
