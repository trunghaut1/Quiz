using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Controller
{
    class QuestionController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public string getSubName(string sub)
        {
            string name = qz.Subjects.Where(t => t.SubId == sub).Select(t => t.SubName).FirstOrDefault();
            return name;
        }
        public List<Question> getQuestion(string sub, int number)
        {
            List<Question> _list = new List<Question>();
            _list = qz.Questions.OrderBy(t => Guid.NewGuid()).Where(i => i.SubId == sub).Take(number).ToList();
            return _list;
        }
    }
}
