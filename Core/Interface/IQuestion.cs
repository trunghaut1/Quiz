using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    interface IQuestion
    {
        List<Question> GetQuestionBySubjectNameAndQuantity(string subjectname, int number);
        string GetSubjectName(string subject);
        Question GetSubjectById(int id);
    }
}
