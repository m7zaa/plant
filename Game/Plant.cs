using System;
using System.Threading;
using System.Collections.Generic;

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
        private int[] _Seed = {(3*(Height/4)) +2,Width/2};
        List<int []> growthList = new List<int []> {};
        public int nutrientLevel { get; set; }
        public int moistureLevel { get; set; }
        public int energyLevel { get; set; }
        private int branchTimer = 0;
        public static int Height = 60;
        public static int Width = 60;
        private int _ySun = 0;
        private int _xSun = 0;
        private char[,] _Map;
        private const char _Sun = (char)9728;
        private const char _Sky = ' ';
        private const char _NightSky = (char)9617;
        private const char _Soil = (char)9619;
        private const char _Stock = (char)9580;
        private const char _SeedChar = (char)8859;

        public Plant()
        {
            nutrientLevel = 10;
            moistureLevel = 10;
            energyLevel = 10;
            

            growthList.Add(_Seed);
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
            newMap[(3*(Height/4)) +2,Width/2] = _SeedChar;
            
            _Map = newMap;

        }

        public void PlantLevels()
        {
            energyLevel--;
            moistureLevel--;
            nutrientLevel--;
            Draw();


        }

        public void GameOver()
        {
            if (energyLevel == 0 || moistureLevel == 0 || nutrientLevel == 0)
            {
                Console.WriteLine("Game Over!");
                System.Environment.Exit(1);                
            }
        }


        public void Action(char input, int ySun, int xSun)
        {
            //capture sun coordinates and set to fields
            _ySun = ySun;
            _xSun = xSun;
            //do the action
            if (input == 'w')
            {
                moistureLevel++;
                energyLevel++;

            }
            else if (input == 'n')
            {
                nutrientLevel++;
                energyLevel++;
            }

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
            branchTimer++;
            int length = growthList.Count;
            for (int i=0; i < length; i++)
            {
                growthList[i] = GrowBranches(growthList[i]);
            }
            Draw();
            return;
        }

        private int[] GrowBranches(int [] branch)
        {
            Random rand = new Random();
            //figure out how far to grow
                int growStocks = 1;
            //figure out what direction to grow
                //grow relative to moving sun
                int xDirection = rand.Next(-1,2);
            //loop through and place stock characters
            for (int i=0; i<growStocks; i++)
            {
                int [] newPos = {branch[0]-1, branch[1]-(2*xDirection)};
                if(InBounds(newPos))
                {
                    if (xDirection > 0) 
                    {

                    _Map[newPos[0], newPos[1]+1] = _Stock;

                    }
                    else if (xDirection < 0)
                    {
                    _Map[newPos[0], newPos[1]-1] = _Stock;
                    }
                    _Map[newPos[0], newPos[1]] = _Stock;
                    //update newgrowth
                    branch = newPos;
                    if(branchTimer % 6 == 0)
                    {
                        int[] newLeft = {newPos[0],newPos[1]};
                        int[] newRight = {newPos[0],newPos[1]+1};
                        if (InBounds(newLeft))
                        {
                            // growthList.Add(newLeft);
                        }
                        // if (InBounds(newRight))
                        // {
                        //     growthList.Add(newRight);
                        // }
                    }
                        
                } 
            }
            return branch;
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

        private void Draw()
        {
            Thread.Sleep(20);
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
            for(int i=0; i<Width - 2; i++)
            {
                mapString += (char)9552;
            }
            mapString += '\n';
            mapString += "Nutrient Level: " + nutrientLevel + '\n';
            mapString += "Soil Moisture Level: " + moistureLevel + '\n';
            mapString += "Energy Level: " + energyLevel + '\n';

            Console.WriteLine(mapString);
        }
    }
}
