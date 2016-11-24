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
            bmp.Save("test1.png");
        }
    }
}
