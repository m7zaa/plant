using System;
using System.Collections.Generic;


namespace Garden 
{
    class Program
    {
    static void Main()
    {
        Sun sun = new Sun();
        Plant plant = new Plant();
        // Plant.Show;
        ConsoleKeyInfo cki = Console.ReadKey(true);
        while (cki.KeyChar != 'q')
        {
            cki = Console.ReadKey(true);
            if(!Console.KeyAvailable)
            {
                plant.Action(cki.KeyChar, sun.YSun, sun.XSun);
            }
        }

    // program code goes here
    }
    }
}