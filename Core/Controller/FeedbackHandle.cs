using Core.Controller;
using Core.Model;

namespace Quiz.Controller
{
    public class FeedbackController
    {
        public bool Add(Feedback value)
        {
            DataHelper<Entities, Feedback>.Add(value);
            return true;
        }
    }
}
