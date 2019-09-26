using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Garden 
{
    class Program
    {
        static void Main()
        {
            Sun sun = new Sun();
            Plant plant = new Plant();
            // Plant.Show;
            GameDriver(sun, plant);

        }

        public static void GameDriver(Sun sun, Plant plant)
        {
            
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                plant.PlantLevels();
                plant.GameOver();
                plant.Action(' ', sun.YSun, sun.XSun);
                GameDriver(sun,plant);           
            }
            //ConsoleKeyInfo cki = Console.ReadKey(true);
            // Console.WriteLine((char)Console.In.Peek());
            if (Console.In.Peek() != -1)
            {
                char cki = (char)Console.Read();
                FlushKeyboard();
                plant.Action(cki, sun.YSun, sun.XSun);
            }
            Thread.Sleep(1000);
            GameDriver(sun,plant);
        }

        private static void FlushKeyboard()
        {
            while (Console.In.Peek() != -1)
            Console.In.Read();
         }
    }
    
}