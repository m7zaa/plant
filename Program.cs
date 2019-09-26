using System;
using System.Collections.Generic;


namespace Garden 
{
    class Program
    {
    static void Main()
    {

        Plant plant = new Plant();

        ConsoleKeyInfo cki = Console.ReadKey(true);
        while (cki.KeyChar != 'q')
        {
            cki = Console.ReadKey(true);
            if(!Console.KeyAvailable)
            {
                plant.Action(cki.KeyChar);
            }
        }

    // program code goes here
    }
    }
}