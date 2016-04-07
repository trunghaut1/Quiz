using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
