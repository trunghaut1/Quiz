using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interface;
using Core.Model;

namespace Core.Controller
{
    public class QuestionHandle : IQuestion
    {
        public List<Question> GetQuestionBySubjectNameAndQuantity(string subjectname, int number)
        {
            return DataHelper<Entities, Question>.FindBy(t => t.SubId.Equals(subjectname)).OrderBy(v => Guid.NewGuid()).Take(number).ToList();
        }

        public string GetSubjectName(string subject)
        {
            return DataHelper<Entities,Subject>.FindBy(t => t.SubId.Equals(subject)).Select(t => t.SubName).FirstOrDefault();
        }

        public Question GetSubjectById(int id)
        {
            return DataHelper<Entities, Question>.FindByPrimaryKey(id);
        }
    }
}
