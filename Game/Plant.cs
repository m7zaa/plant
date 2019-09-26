using System;
using System.Threading;

namespace Garden
{
    class Sun
    {
        public int XSun { get; set; }
        public int YSun { get; set; }
        public Sun()
        {
            XSun = Plant.Width/2;
            YSun = 0;
        }
        public void MoveSun()
        {

        }
    }
    class Plant
    {
        private int[] _NewGrowth = {24,35};
        public static int Height = 30;
        public static int Width = 70;
        private int _ySun = 0;
        private int _xSun = 0;
        private char[,] _Map;
        private const char _Sun = (char)9728;
        private const char _Sky = ' ';
        private const char _NightSky = (char)9617;
        private const char _Soil = (char)9619;
        private const char _Stock = (char)9580;
        private const char _Seed = ',';

        public Plant()
        {
            // Width = 70;
            // Height = 30;
            char[,] newMap = new char[Height,Width];
            for (int i=0; i<Height; i++)
            {
                //if height is less than 1/4
                if(i <= 3*(Height / 4)) 
                { 
                    //make
                    for(int j=0;j<Width - 2; j++)
                    {
                        newMap[i,j] = _Sky;
                    }
                    newMap[i,Width - 1] = '\n';
                }
                else
                {
                    for(int j=0;j<Width - 2; j++)
                    {
                        newMap[i,j] = _Soil;
                    }
                    newMap[i,Width - 1] = '\n';
                }
            }
            _Map = newMap;

        }

        public void Action(char input, int ySun, int xSun)
        {
            //capture sun coordinates and set to fields
            _ySun = ySun;
            _xSun = xSun;
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
            GrowBranches();
            DrawPlant();
            return;
        }

        private void GrowBranches()
        {
            //figure out how far to grow
                int growStocks = 1;
            //figure out what direction to grow
                //grow relative to moving sun
                int xDirection = 0;
            //loop through and place stock characters
            for (int i=0; i<growStocks; i++)
            {
                int [] newPos = {_NewGrowth[0]-1, _NewGrowth[1]-xDirection};
                if(InBounds(newPos))
                {
                    //place a new piece
                    _Map[_NewGrowth[0]-1, _NewGrowth[1]-xDirection] = _Stock;
                    //update newgrowth
                    _NewGrowth = newPos;
                }
            }
        }
        private bool InBounds(int [] newPos)
        {
            bool inBounds = false; 
            //if not in bounds
            if (newPos[0] < Height && newPos[0] >= 0 && newPos[1] >= 0 && newPos[1] < Width)
            {
            inBounds = true;
            }
            return inBounds;

        }

        private void DrawPlant()
        {
            Thread.Sleep(5);
            Console.Clear();
            string mapString = "\r";
            _Map[_ySun,_xSun] = _Sun;

            for(int i=0; i<Height; i++)
            {
                for(int j=0; j < Width; j++)
                {
                    mapString += _Map[i,j];
                } 
            }
            Console.WriteLine(mapString);
        }
    }
}
