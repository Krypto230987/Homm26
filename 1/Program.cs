using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homm26
{
    using System;

    class Lamp
    {
        public bool TurnedOn { get; set; }

        public string GetLampStatus()
        {
            return TurnedOn ? "Lamp|Лампа включена" : "Lamp|Лампа выключина";
        }
    }

    class Cat
    {
        public string WhatIdDoingNow()
        {
            return "Cat|Кошка играет";
        }
    }

    class Man
    {
        public string WhatHeIsDoingNow()
        {
            return "Man|Человек спит";
        }
    }

    class Program
    {
        delegate string GetStatusDelegate();


        static void Main()
        {
            Lamp lamp = new Lamp { TurnedOn = true };
            Cat cat = new Cat();
            Man man = new Man();

            ReadState(lamp.GetLampStatus);
            ReadState(cat.WhatIdDoingNow);
            ReadState(man.WhatHeIsDoingNow);
            Console.ReadLine();
        }

        static void ReadState(GetStatusDelegate del)
        {
            var status = del.GetInvocationList();
            foreach (GetStatusDelegate getStatus in status)
            {
                Console.WriteLine(getStatus());
            }
        }
    }
}
