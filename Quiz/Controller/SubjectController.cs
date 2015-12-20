using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz.Controller
{
    class SubjectController
    {
        QuizDbEntities qz = new QuizDbEntities();
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
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
