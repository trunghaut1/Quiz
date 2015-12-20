using Quiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Quiz.Controller
{
    class AddUserController
    {
        QuizDbEntities qz = new QuizDbEntities();
        public void AddUser(string username)
        {
            try
            {
                User user = new User();
                user.Name = username;
                qz.Users.Add(user);
                //qz.SaveChanges();
                createInfo();
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Adduser: " + e.Message);
            }

        }
        private void createInfo()
        {
            try
            {
                List<string> listSub = qz.Subjects.Select(t => t.SubId).ToList();
                var uid = qz.Users.Select(t => t.Id).FirstOrDefault();
                for(int i=0;i<listSub.Count;i++)
                {
                    Info inf = new Info();
                    inf.SubId = listSub[i];
                    inf.UserId = uid;
                    inf.NumAnswer = 0;
                    inf.NumAnswerTrue = 0;
                    inf.TimeUse = 0;
                    qz.Infoes.Add(inf);
                }
                qz.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("createInfo: "+e.Message);
            }
        }
    }
}
