using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    interface IQuestion
    {
        List<Question> GetQuestionBySubjectNameAndQuantity(string subjectname, int number);
        string GetSubjectName(string subject);
        Question GetSubjectById(int id);
    }
}
