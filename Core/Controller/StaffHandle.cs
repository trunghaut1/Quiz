using System.Collections.Generic;
using Core.Model;
using Core.Interface;

namespace Core.Controller
{
    public class StaffHandle : IStaff
    {
        public bool Add(Staff staff)
        {
            DataHelper<Entities, Staff>.Add(staff);
            return true;
        }

        public bool Edit(Staff staff)
        {
            DataHelper<Entities, Staff>.Edit(staff);
            return true;
        }

        public bool Delete(int id)
        {
            Staff staff = DataHelper<Entities, Staff>.FindByPrimaryKey(id);
            DataHelper<Entities, Staff>.Remove(staff);
            return true;
        }

        public List<Staff> getAllStaff()
        {
            return DataHelper<Entities, Staff>.GetAll();
        }

        public Staff GetStaffById(int id)
        {
            return DataHelper<Entities, Staff>.FindByPrimaryKey(id);
        }
    }
}
