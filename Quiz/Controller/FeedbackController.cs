using Quiz.Model;
using System;

namespace Quiz.Controller
{
    public class FeedbackController
    {
        QuizDbEntities db = new QuizDbEntities();
        public bool Add(Feedback value)
        {
            try
            {
                db.Feedback.Add(value);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
