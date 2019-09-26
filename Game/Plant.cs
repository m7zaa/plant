using System;
using System.Threading;

namespace Garden
{

    class Plant
    {
        // NewGrowth
        // AmountOfBranches
        // 
        // Photosynthesis
        // WaterHealth
        // NutrientHealth
        // SunLocation

        //properties/fields
        private const int _Height = 30;
        private const int _Width = 70;
        private char[,] _Map;
        private const char _Sun = (char)9728;
        private const char _Sky = ' ';
        private const char _NightSky = (char)9617;
        private const char _Soil = (char)9619;

        public Plant()
        {
            char[,] newMap = new char[_Height,_Width];
            for (int i=0; i<_Height; i++)
            {
                //if height is less than 1/4
                if(i <= 3*(_Height / 4)) 
                { 
                    //make
                    for(int j=0;j<_Width - 5; j++)
                    {
                        newMap[i,j] = _Sky;
                    }
                    newMap[i,_Width - 5] = '\n';
                }
                else
                {
                    for(int j=0;j<_Width - 5; j++)
                    {
                        newMap[i,j] = _Soil;
                    }
                    newMap[i,_Width - 5] = '\n';
                }
            }
            _Map = newMap;

        }

        public void Action(char input)
        {
        //do the action

        //update plant

        //check water
            //if water is low
                //leaves lose health

        //check nutrients
            //update unhealthy leaves to healthy if nutritients are sufficient
            //if it is good be able to grow a leaf
                //success based on other conditions
        
        
        //check energy
            //attempt to grow branches
            //check if energy is sufficient
                //if it is grow on each terminal bud
                //if some other condition is true make new branches

            UpdatePlant();
            return;
        } 

        private void UpdatePlant()
        {
            //code to impllement
            DrawPlant();
            return;
        }
        private void DrawPlant()
        {
            Thread.Sleep(5);
            Console.Clear();
            string mapString = "\r";

            for(int i=0; i<_Height; i++)
            {
                for(int j=0; j< _Width; j++)
                {
                    mapString += _Map[i,j];
                } 
            }
            Console.WriteLine(mapString);
        }
    }
}
