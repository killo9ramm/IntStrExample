using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd1()
        {
            string input =    "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string expected = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd11()
        {
            string input = "000009999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string expected = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd1_1()
        {
            string input = "+9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string expected = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd11_1()
        {
            string input = "+000009999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string expected = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd2()
        {
            string input =    "9999999999999999999999999999999999999999909999999999999999999999999999999999999999999999999";
            string expected = "9999999999999999999999999999999999999999910000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd21()
        {
            string input = "00000009999999999999999999999999999999999999999909999999999999999999999999999999999999999999999999";
            string expected = "9999999999999999999999999999999999999999910000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd3()
        {
            string input =    "1111112222222223333334444444444";
            string expected = "1111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd31()
        {
            string input = "00001111112222222223333334444444444";
            string expected = "1111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd4()
        {
            string input = "00001111112222222223333334444444444,32111";
            string expected = "1111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAdd5()
        {
            string input = "00001111112222222223333334444444444.32111";
            string expected = "1111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub1()
        {
            string expected = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string input =    "-10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub2()
        {
            string expected = "-9999999999999999999999999999999999999999909999999999999999999999999999999999999999999999999";
            string input =    "-9999999999999999999999999999999999999999910000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub3()
        {
            string expected = "-1111112222222223333334444444444";
            string input = "-1111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub4()
        {
            string expected = "-1111112222222223333334444444444";
            string input = "-1111112222222223333334444444445,23213";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub5()
        {
            string expected = "-1111112222222223333334444444444";
            string input = "-1111112222222223333334444444445.123123";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub11()
        {
            string expected = "-9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";
            string input = "-0000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub21()
        {
            string expected = "-9999999999999999999999999999999999999999909999999999999999999999999999999999999999999999999";
            string input = "-000009999999999999999999999999999999999999999910000000000000000000000000000000000000000000000000";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub31()
        {
            string expected = "-1111112222222223333334444444444";
            string input = "-00001111112222222223333334444444445";
            string actual = Program.Inc(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestErr1()
        {
            Exception exp=null;
            try {
                string input = "9999999999999999999999999999a99999999999909999999999999999999999999999999999999999999999999";
                string actual = Program.Inc(input);
            }catch(Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestErr2()
        {
            Exception exp = null;
            try
            {
                string input = null;
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestErr3()
        {
            Exception exp = null;
            try
            {
                string input = "";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState1()
        {
            Exception exp = null;
            try
            {
                string input = "-,324234324";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState2()
        {
            Exception exp = null;
            try
            {
                string input = "+,324234324";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState3()
        {
            Exception exp = null;
            try
            {
                string input = ",324234324";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState4()
        {
            Exception exp = null;
            try
            {
                string input = ",32423+4324";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState5()
        {
            Exception exp = null;
            try
            {
                string input = ",324234-324";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState6()
        {
            Exception exp = null;
            try
            {
                string input = "-0,3432423---";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState7()
        {
            Exception exp = null;
            try
            {
                string input = "-0.3432423++++";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState8()
        {
            Exception exp = null;
            try
            {
                string input = "-0.343,,,,2423++++";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState9()
        {
            Exception exp = null;
            try
            {
                string input = "-0...343,,,,2423++++";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState10()
        {
            Exception exp = null;
            try
            {
                string input = "-0..";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState11()
        {
            Exception exp = null;
            try
            {
                string input = "-0..3432";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        
        [TestMethod]
        public void TestPogranState12()
        {
            Exception exp = null;
            try
            {
                string input = "-----0.3432";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState13()
        {
            Exception exp = null;
            try
            {
                string input = "++++++.3432";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState14()
        {
            Exception exp = null;
            try
            {
                string input = "00034+32";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState15()
        {
            Exception exp = null;
            try
            {
                string input = "0003432+";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestPogranState16()
        {
            Exception exp = null;
            try
            {
                string input = "+00034+32+";
                string actual = Program.Inc(input);
            }
            catch (Exception ex)
            {
                exp = ex;
            }
            Assert.AreEqual(typeof(ArgumentException), exp.GetType());
        }
        [TestMethod]
        public void TestZero1()
        {
            string input = "0";
            string expected = "1";
            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestZero2()
        {
            string input = "-0";
            string expected = "1";
            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestZero3()
        {
            string input = "+0.3432423";
            string expected = "1";
            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestZero4()
        {
            string input = "-0,3432423";
            string expected = "1";
            string actual = Program.Inc(input);

            Assert.AreEqual(expected, actual);
        }
        
    }
}
