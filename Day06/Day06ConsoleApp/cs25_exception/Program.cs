using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs25_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, };

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (Exception ex) // 모르겠다 싶으면 Exception
            {
                Console.WriteLine(ex.Message);
            }            
            finally
            {
                // file 객체 close
                // db 연결 close
                // 네트워크 소켓 close
                Console.WriteLine("계속");
            }

            DivideTest(array[2], array[0]);

            Console.WriteLine("프로그램 종료!!!");

            try
            {
                Console.WriteLine("Test Test");
                throw new Exception("커스텀 예외");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DivideTest(int v1, int v2)
        {
            try
            {
                Console.WriteLine(v1 / v2);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
