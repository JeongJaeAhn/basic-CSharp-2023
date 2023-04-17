using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_5_app
{
    internal class Program
    {
        public interface IAnimal
        {
            int Age { get; set; }
            string Name { get; set; }

            void Eat();
            void Sleep();
            void Sound();
        }
                
        public class Dog : IAnimal
        {
            public int Age { get; set; }
            public string Name { get; set; }

            public void Eat()
            {
                Console.WriteLine("개가 먹습니다");
            }

            public void Sleep()
            {
                Console.WriteLine("개가 잡니다");
            }

            public void Sound()
            {
                Console.WriteLine("개가 짖습니다");
            }
        }

        public class Cat : IAnimal
        {
            public int Age { get; set; }
            public string Name { get; set; }

            public void Eat()
            {
                Console.WriteLine("고양이가 먹습니다");
            }

            public void Sleep()
            {
                Console.WriteLine("고양이가 잡니다");
            }

            public void Sound()
            {
                Console.WriteLine("고양이가 짖습니다");
            }
        }

        public class Horse : IAnimal
        {
            public int Age { get; set; }
            public string Name { get; set; }

            public void Eat()
            {
                Console.WriteLine("말이 먹습니다");
            }

            public void Sleep()
            {
                Console.WriteLine("말이 잡니다");
            }

            public void Sound()
            {
                Console.WriteLine("말이 짖습니다");
            }
        }
        static void Main(string[] args)
        {            
        }
    }
}

/*
 5. IAnimal이라는 이름의 인터페이스를 사용해서 강아지, 고양이, 말로 구현한 클래스를 작성하세요. 
(Age와 Name은 프로퍼티로 Eat(), Sleep(), Sound()와 같은 메서드를 인터페이스에 선언하여 상속(구현)할 수 있습니다)
 */