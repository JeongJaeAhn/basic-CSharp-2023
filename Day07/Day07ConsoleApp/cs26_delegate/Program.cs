﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs26_delegate
{
    // 대리자 사용하겠다는 서언
    delegate int CalcDelegate(int a, int b);

    delegate int Compare(int a, int b); // a, b중에 머가 큰지(작은지) 비교

    #region < 대리자 기본예 >
    class Calc
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        // static이 붙으면 무조건 실행될때 최초 메모리에 올라감
        // 프로그램 실행중에는 언제든지 접근가능
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }
    #endregion

    internal class Program
    {
        // 오름차순 비교
        static int AscendCompare(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b ) return 0;
            else return -1;
        }

        // 내림차순 비교
        static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b ) return 0;
            else return -1;
        }

        static void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0, j = 0, temp = 0;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i+1); j++)
                {
                    if (comparer(DataSet[j], DataSet[j+1]) > 0) // 대리자 사용
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp; // Swap
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            #region < 대리자 기본예 >
            // 일반적으로 클래스 사용방식 - 직접호출
            Calc normalCalc = new Calc();
            int x = 10, y = 15;
            int res = normalCalc.Plus(x, y);
            Console.WriteLine(res);

            Console.WriteLine(normalCalc.Plus(x, y));

            res = Calc.Minus(x, y);

            // 대리자를 사용하는 방식 - 대리자 대신 실행
            x = 30; y = 20;
            Calc delCalc = new Calc();
            CalcDelegate Callback;

            Callback = new CalcDelegate(delCalc.Plus);
            int res2 = Callback(x, y); // = Calc.Plus() 대신 호출
            Console.WriteLine(res2);
            #endregion

            int[] origin = { 4, 7, 8, 2, 9, 1 };

            Console.WriteLine("오름차순 버블정렬");
            BubbleSort(origin, new Compare(AscendCompare));

            foreach (var item in origin)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 버블정렬");
            BubbleSort(origin, new Compare(DescendCompare));

            foreach (var item in origin)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
