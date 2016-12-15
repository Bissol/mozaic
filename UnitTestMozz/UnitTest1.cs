using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using mozaic;

namespace UnitTestMozz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test;
            ImageProcessing.MergeEdgesVertical(ref bmp, 150, 10);
            bmp.Save("testBasic.png");
        }

        [TestMethod]
        public void TestSmartEdge()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test2;
            ImageProcessing.SmartMergeVertical(ref bmp, 300, 30, 5, 2, 10);
            bmp.Save("testSmart.png");
        }

        [TestMethod]
        public void TestAvgAvg()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test;
            ImageProcessing.test(ref bmp, 5, 5, false, 0);
            bmp.Save("testavg.png");
        }

        [TestMethod]
        public void TestAvgSmoothness()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test2;
            ImageProcessing.test(ref bmp, 5, 5, true, 15);
            bmp.Save("testsmooth.png");
        }
    }
}
