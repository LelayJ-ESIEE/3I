using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static POO1_Tableaux.Program;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static bool ArrayEquals<T>(T[] t1, T[] t2)
        {
            if (t1.Length != t2.Length)
                return false;
            for (int i = 0; i < t1.Length; i++)
                if (!t1[i].Equals(t2[i]))
                    return false;
            return true;
        }

        static bool ArrayEquals<T>(T[,] t1, T[,] t2)
        {
            if (t1.GetLength(0) != t2.GetLength(0) || t1.GetLength(1) != t2.GetLength(1))
                return false;
            for (int i = 0; i < t1.GetLength(0); i++)
                for (int j = 0; j < t1.GetLength(1); j++)
                    if (!t1[i,j].Equals(t2[i,j]))
                    return false;
            return true;
        }


        [TestMethod]
        public void InsererTableauTest1()
        {
            Assert.IsTrue(ArrayEquals(InsererTableau(new int[] { }, new int[] { }, 0), new int[] { }));
        }

        [TestMethod]
        public void InsererTableauTest2()
        {
            int[] t1 = {4, 5, 3, 8, 9, 1, 2};
            int[] t2 = {11, 15, 13};
            int[] t3 = { 11, 15, 13, 4, 5, 3, 8, 9, 1, 2 };
            Assert.IsTrue(ArrayEquals(InsererTableau(t1, t2, 0), t3));
        }

        [TestMethod]
        public void InsererTableauTest3()
        {
            int[] t1 = { 4, 5, 3, 8, 9, 1, 2 };
            int[] t2 = { 11, 15, 13 };
            int[] t3 = { 4, 5, 3, 8, 9, 1, 2, 11, 15, 13};
            Assert.IsTrue(ArrayEquals(InsererTableau(t1, t2, 7), t3));
        }

        [TestMethod]
        public void InsererTableauTest4()
        {
            int[] t1 = { 4, 5, 3, 8, 9, 1, 2 };
            int[] t2 = { 11, 15, 13 };
            int[] t3 = { 4, 5, 3, 11, 15, 13, 8, 9, 1, 2 };
            Assert.IsTrue(ArrayEquals(InsererTableau(t1, t2, 3), t3));
        }


        [TestMethod]
        public void TransposerMatriceTest1()
        {
            double[,] t1 = { { } };
            double[,] t2 = { { } };
            TransposerMatrice(t1);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void TransposerMatriceTest2()
        {
            double[,] t1 = { {2} };
            double[,] t2 = { {2} };
            TransposerMatrice(t1);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void TransposerMatriceTest3()
        {
            double[,] t1 = {{1, 2}, {3, 4}};
            double[,] t2 = {{1, 3}, {2, 4}};
            TransposerMatrice(t1);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void TransposerMatriceTest4()
        {
            double[,] t1 = {{ 1,  2,  3,  4,  5},
                            { 6,  7,  8,  9, 10},
                            {11, 12, 13, 14, 15},
                            {16, 17, 18, 19, 20},
                            {21, 22, 23, 24, 25}};

            double[,] t2 = {{ 1,  6, 11, 16, 21},
                            { 2,  7, 12, 17, 22},
                            { 3,  8, 13, 18, 23},
                            { 4,  9, 14, 19, 24},
                            { 5, 10, 15, 20, 25}};
            TransposerMatrice(t1);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }


        [TestMethod]
        public void RemplirRectangleTest1()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            RemplirRectangle(t1, 2, 2, 0, 0);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void RemplirRectangleTest2()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            RemplirRectangle(t1, -20, -20, 5, 5);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void RemplirRectangleTest3()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            RemplirRectangle(t1, 20, 20, 5, 5);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void RemplirRectangleTest4()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = { {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 1, 0, 0, 0, 0},
                          {0, 0, 1, 0, 0, 0, 0}};

            RemplirRectangle(t1, 2, 3, 1, 2);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void RemplirRectangleTest5()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = { {1, 0, 0, 0, 0, 0, 0},
                          {1, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            RemplirRectangle(t1, -1, -1, 2, 3);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

        [TestMethod]
        public void RemplirRectangleTest6()
        {
            int[,] t1 = {{0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0}};

            int[,] t2 = { {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 0, 0},
                          {0, 0, 0, 0, 0, 1, 1},
                          {0, 0, 0, 0, 0, 1, 1},
                          {0, 0, 0, 0, 0, 1, 1}};

            RemplirRectangle(t1, 5, 2, 5, 5);
            Assert.IsTrue(ArrayEquals(t1, t2));
        }

 

       
        

    }
}
