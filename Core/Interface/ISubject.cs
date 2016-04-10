using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    interface ISubject
    {
        List<SubButton> GetAllSubjectButton();
        List<Subject> GetAllSubject();
        Subject GetSubjectById(int id);
        bool Add(Subject subject);
        bool Edit(Subject subject);
        bool Delete(int id);
        
    }
}
