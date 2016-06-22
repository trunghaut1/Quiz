using Core.Controller;
using Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace QuizWebApp
{
    /// <summary>
    /// Summary description for QuizService
    /// </summary>
    [WebService(Namespace = "http://www.quizonepro.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuizService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string getUser(string email)
        {
            UserHandle handle = new UserHandle();
            AspNetUser user = handle.GetUserByEmail(email);
            return user.ParserJSon<AspNetUser>();
        }
        [WebMethod]
        public string doLogin(string username, string password)
        {
            UserHandle handle = new UserHandle();
            bool result = handle.Authenticate(username, password);
            if (result == true) return result.ToString().ParserJSon();
            return result.ToString().ParserJSon();
        }
        [WebMethod]
        public string getNews()
        {
            NewsHandle handle = new NewsHandle();
            List<News> list = handle.Get4LastestNews();
            return list.ParserListToJSon<News>();
        }
        [WebMethod]
        public string get40Question(string category)
        {
            QuestionHandle handle = new QuestionHandle();
            List<Question> list = handle.GetQuestionBySubjectNameAndQuantity("KTPM", 40);
            return list.ParserListToJSon<Question>(); ;
        }
    }
    public static class Extension{
        public static string ParserJSon<Source>(this Source data) where Source : class
        {

            Type targetType = typeof(Source);
            var TargetInstance = Activator.CreateInstance(targetType, false);
            var dataOfTarget = from properties in targetType.GetMembers().ToList()
                               where properties.MemberType == MemberTypes.Property
                               select properties;
            List<MemberInfo> ListMember = dataOfTarget.Where(memberInfo => dataOfTarget.Select(c => c.Name)
             .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in ListMember)
            {
                propertyInfo = typeof(Source).GetProperty(memberInfo.Name);
                if (data.GetType().GetProperty(memberInfo.Name)!=null)
                {
                value = data.GetType().GetProperty(memberInfo.Name).GetValue(data, null);
                if (propertyInfo.ToString().Contains("System.Collections.Generic.ICollection"))
                {
                    propertyInfo.SetValue(TargetInstance, null, null);
                } else
                if (value != null )
                {
                    propertyInfo.SetValue(TargetInstance, value, null);
                }
                else
                {
                    propertyInfo.SetValue(TargetInstance, null, null);
                }
                }

            }

            var databack = JsonConvert.SerializeObject(TargetInstance,
                Formatting.None,
                new JsonSerializerSettings()
                {

                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            /*JavaScriptSerializer sc = new JavaScriptSerializer();
            string databack = sc.Serialize((Source)TargetInstance);*/
            return databack;
        }
        public static string ParserListToJSon<Source>(this List<Source> data) where Source : class
        {
            List<Source> list = new List<Source>();
            foreach(Source item in data)
            {
                Type targetType = typeof(Source);
                var TargetInstance = Activator.CreateInstance(targetType, false);
                var dataOfTarget = from properties in targetType.GetMembers().ToList()
                                   where properties.MemberType == MemberTypes.Property
                                   select properties;
                List<MemberInfo> ListMember = dataOfTarget.Where(memberInfo => dataOfTarget.Select(c => c.Name)
                 .ToList().Contains(memberInfo.Name)).ToList();
                PropertyInfo propertyInfo;
                object value;
                foreach (var memberInfo in ListMember)
                {
                    propertyInfo = typeof(Source).GetProperty(memberInfo.Name);
                    if (item.GetType().GetProperty(memberInfo.Name) != null)
                    {
                        value = item.GetType().GetProperty(memberInfo.Name).GetValue(item, null);
                        if (propertyInfo.ToString().Contains("System.Collections.Generic.ICollection"))
                        {
                            if (propertyInfo.CanWrite)
                            propertyInfo.SetValue(TargetInstance, null, null);
                        }
                        else
                            if (value != null)
                            {
                                if(propertyInfo.CanWrite)
                                {
                                    propertyInfo.SetValue(TargetInstance, value, null);
                                }
                            }
                            else
                            {
                                if (propertyInfo.CanWrite)
                                propertyInfo.SetValue(TargetInstance, null, null);
                            }
                    }

                }
                list.Add((Source)TargetInstance);
            }
            

            var databack = JsonConvert.SerializeObject(list,
                Formatting.None,
                new JsonSerializerSettings()
                {

                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            /*JavaScriptSerializer sc = new JavaScriptSerializer();
            string databack = sc.Serialize((Source)TargetInstance);*/
            return databack;
        }
    }
    
}
