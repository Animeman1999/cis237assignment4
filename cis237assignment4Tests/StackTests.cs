using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod()]
        public void PushTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            MyStack<Protocol> testProtocolStac = new MyStack<Protocol>();
            testProtocolStac.Push(testProtocol1);
            int testSize = testProtocolStac.Size;
            Protocol testProtocol2 = new Protocol("Nevo-Titanium", "Protocol", "Blue", 200);
            testProtocolStac.Push(testProtocol2);
            int testSize2 = testProtocolStac.Size;
            Protocol testProtocol3 = new Protocol("Nevo-Titanium", "Protocol", "Red", 300);
            testProtocolStac.Push(testProtocol3);
            int testSize3 = testProtocolStac.Size;

            Assert.AreEqual(1, testSize);
            Assert.AreEqual(2, testSize2);
            Assert.AreEqual(3, testSize3);
        }

        [TestMethod()]
        public void PopTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            MyStack<Protocol> testProtocolStac = new MyStack<Protocol>();
            testProtocolStac.Push(testProtocol1);           
            Protocol testProtocol2 = new Protocol("Nevo-Titanium", "Protocol", "Blue", 200);
            testProtocolStac.Push(testProtocol2);
            Protocol testProtocol3 = new Protocol("Nevo-Titanium", "Protocol", "Red", 300);
            testProtocolStac.Push(testProtocol3);

            Protocol actualProtocol1 = testProtocolStac.Pop();
            Protocol actualProtocol2 = testProtocolStac.Pop();
            Protocol actualProtocol3 = testProtocolStac.Pop();

            Assert.AreEqual(testProtocol1, actualProtocol1);
            Assert.AreEqual(testProtocol2, actualProtocol2);
            Assert.AreEqual(testProtocol3, actualProtocol3);
        }

        ///Redundant since used in PushTest and PopTest
        //[TestMethod()]
        //public void StackTest()
        //{
        //    Assert.Fail();
        //}
    }
}