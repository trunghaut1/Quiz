using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Linq;
using System.Web;

namespace TestMVC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Core.Controller.SubjectController ctr = new Core.Controller.SubjectController();
            List<Core.Model.Subject> _list = ctr.getAllSubject();
            IEnumerable<SelectListItem> items = from c in _list
                                                select new SelectListItem
                                                {
                                                    Value = c.SubId,
                                                    Text = c.SubName
                                                };
            Assert.IsNotNull(items);
        }
    }
}
