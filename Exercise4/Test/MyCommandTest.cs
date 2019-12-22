using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Test
{
    [TestClass]
    public class MyCommandTest
    {
        [TestMethod]
        public void MyCommnadTest()
        {
            int counter = 0;
            MyCommand myCommand = new MyCommand(() => counter++);
            myCommand.Execute(null);
            Assert.AreEqual(1, counter);
            Assert.IsTrue(myCommand.CanExecute(null));
            myCommand = new MyCommand(() => counter++, ()=> false );
            Assert.IsFalse(myCommand.CanExecute(null));
            myCommand.Execute(null);
            Assert.AreEqual(2, counter);
        }
    }
}
