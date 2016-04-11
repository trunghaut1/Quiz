using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    public class StaffController
    {
        Entities qz = new Entities();
        public List<Staff> getAllStaff()
        {
            return qz.Staffs.ToList();
        }
        public Staff getStaffById(int id)
        {
            return qz.Staffs.Find(id);
        }
        public int deleteStaff(int id)
        {
            Staff staff = qz.Staffs.Find(id);
            qz.Staffs.Remove(staff);
            return qz.SaveChanges();

        }
        public int saveStaff(Staff s)
        {
            qz.Staffs.Add(s);
            return qz.SaveChanges();
        }
        public int saveEditStaff(Staff s)
        {
            Staff staff = qz.Staffs.Find(s.id);
            staff.img_link = s.img_link;
            staff.name = s.name;
            staff.title = s.title;
            return qz.SaveChanges();
        }
    }
}
