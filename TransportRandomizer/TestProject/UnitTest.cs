using Microsoft.VisualStudio.TestTools.UnitTesting;
using EKRLib;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new Car("G1G1G", 30);
            System.Console.WriteLine(test);
        }

        [TestMethod]
        public void TestMethod2()
        {
            object test = new MotorBoat("G1G1G", 30);
            System.Console.WriteLine(test);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Transport test = new Car("G1G1G", 30);
            test.StartEngine();
        }
    }
}
