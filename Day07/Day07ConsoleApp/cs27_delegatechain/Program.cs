using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs27_delegatechain
{
    delegate void ThereIsAfire(string location); // 불났을때 대신해주는 대리자

    delegate int Calc(int a, int b); //
    internal class Program
    {
        static void Call119(string location)
        {
            Console.WriteLine("소방서죠? {0}에 불났어요!!", location);
        }

        static void ShoutOut(string location)
        {
            Console.WriteLine("{0}에 불났어요!!", location);
        }

        static void Escape(string location)
        {
            Console.WriteLine("{0}에서 탈출합니다.", location);
        }
        static void Main(string[] args)
        {
            var loc = "우리집";
            Call119(loc);
            ShoutOut(loc);
            Escape(loc);

            // 불이 날수도 있으니까 미리 준비
            var otherloc = "경찰서";
            ThereIsAfire fire = new ThereIsAfire(Call119);
            fire += new ThereIsAfire(ShoutOut);
            fire += new ThereIsAfire(Escape); // 대리자에 메소드 추가

            fire(otherloc);

            fire -= new ThereIsAfire(ShoutOut); // 대리자에서 메소드를 제거

            fire("다른집");
        }
    }
}
