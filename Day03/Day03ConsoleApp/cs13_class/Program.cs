﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{
    class Cat   // private 이라도 같은 cs13_class 안에 있기때문에 접근가능
    {
        #region < 생성자 >

        // 기본 생성자
        public Cat()
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }

        // 사용자 지정생성자
        public Cat(string name, string color, sbyte age = 1)
        {
            Name = name;
            Color = color;
            Age = age;
        }



        #endregion

        #region < 멤버변수 - 속성 >
        public string Name; // 고양이 이름
        public string Color; // 색상
        public sbyte Age; // 고양이 나이
        #endregion

        #region < 멤버메소드 - 기능 >
        public void Meow()
        {
            Console.WriteLine("{0} ~ 야옹~!!", Name);
        }

        public void Run()
        {
            Console.WriteLine("{0} 달린다.", Name);
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cat helloKitty = new Cat(); // helloKitty라는 이름의 객체를 생성한다
            helloKitty.Name = "헬로키티";
            helloKitty.Color = "흰색";
            helloKitty.Age = 50;
            helloKitty.Meow();
            helloKitty.Run();

            // 객체를 생성하면서 속성 초기화
            Cat nero = new Cat()
            {
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27      
            };
            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.",  helloKitty.Name, helloKitty.Color,                        helloKitty.Age);
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.", nero.Name, nero.Color, nero.Age);

            Cat Yaongi = new Cat();
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.", Yaongi.Name, Yaongi.Color, Yaongi.Age);

            Cat norangi = new Cat("노랑이", "노란색");
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세입니다.", norangi.Name, norangi.Color, norangi.Age);
        }
    }
}