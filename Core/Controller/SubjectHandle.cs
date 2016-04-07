using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Core.Interface;

namespace Core.Controller
{
    public class SubjectHandle : ISubject
    {

        public List<SubButton> GetAllSubjectButton()
        {
            return DataHelper<Entities, SubButton>.GetAll();
        }

        public List<Subject> GetAllSubject()
        {
            return DataHelper<Entities, Subject>.GetAll();
        }

        public Subject GetSubjectById(int id)
        {
            return DataHelper<Entities, Subject>.FindByPrimaryKey(id);
        }

        public bool Add(Subject subject)
        {
            DataHelper<Entities, Subject>.Add(subject);
            return true;
        }

        public bool Edit(Subject subject)
        {
            DataHelper<Entities, Subject>.Edit(subject);
            return true;
        }

        public bool Delete(int id)
        {
            var subject = DataHelper<Entities, Subject>.FindByPrimaryKey(id);
            DataHelper<Entities, Subject>.Remove(subject);
            return true;
        }
    }
}
