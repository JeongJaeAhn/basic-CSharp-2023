using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Number_1_app
{
    class Boiler
    {
        private byte voltage;
        private int temperature;
        public string Brand;

        public byte Voltage
        {
            get { return this.voltage; }
            set 
            {
                if (value == 110 || value == 220)
                {
                    this.voltage = value;
                }
                // 110V와 220V만 저장할 수 있도록 처리
            }
        }

        public int Temperature
        {
            get { return this.temperature; }
            set 
            {
                if (value <= 5)
                {
                    this.temperature = 5;
                }
                else if (value >= 70)
                {
                    this.temperature = 70;
                }
                else
                {
                    this.temperature = value;
                }
                // 물온도는 5도 이하면 5도로, 70도 이상이면 70도로 제한
            }
        }

        public void PrintAll()
        {
            Console.WriteLine($"브랜드명 : {Brand}", Brand);
            Console.WriteLine($"전압 : {Voltage} V" , Voltage);
            Console.WriteLine($"물온도 : {Temperature} ℃", Temperature);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();            
        }
    }
}
