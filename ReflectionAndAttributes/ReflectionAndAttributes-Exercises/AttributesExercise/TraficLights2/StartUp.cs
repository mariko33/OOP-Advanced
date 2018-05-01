using System;
using System.Collections.Generic;


class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());
            
            List<TraficLights>ligts=new List<TraficLights>();

            foreach (var i in input)
            {
                Light targetLight = (Light) Enum.Parse(typeof(Light), i);
                ligts.Add(new TraficLights(targetLight));
            }

            for (int i = 0; i < count; i++)
            {
                foreach (var light in ligts)light.UpdateStatus();
                Console.WriteLine(string.Join(" ",ligts));
                
            }
        }
    }

