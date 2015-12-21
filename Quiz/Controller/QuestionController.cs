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
            try
            {
                string name = qz.Subjects.Where(t => t.SubId == sub).Select(t => t.SubName).FirstOrDefault();
                return name;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu","Lỗi");
            }
            return null;
            
        }
        public List<Question> getQuestion(string sub, int number)
        {
            try
            {
                List<Question> _list = new List<Question>();
                _list = qz.Questions.OrderBy(t => Guid.NewGuid()).Where(i => i.SubId == sub).Take(number).ToList();
                return _list;
            }
            catch (Exception)
            {
                
                System.Windows.MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu","Lỗi");
            }
            return null;
        }
    }
}
