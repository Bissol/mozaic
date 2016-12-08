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
            Bitmap bmp = UnitTestMozz.Properties.Resources.test;
            ImageProcessing.SmartMergeVertical(ref bmp, 150, 60, 10, 10, 2);
            bmp.Save("testSmart.png");
        }

        [TestMethod]
        public void TestAvgAvg()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test;
            ImageProcessing.test(ref bmp, 5, 5, false);
            bmp.Save("testavg.png");
        }

        [TestMethod]
        public void TestAvgSmoothness()
        {
            Bitmap bmp = UnitTestMozz.Properties.Resources.test;
            ImageProcessing.test(ref bmp, 5, 5, true);
            bmp.Save("testsmooth.png");
        }
    }
}
