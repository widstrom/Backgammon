using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    
    class MatchResult
    {
        public  int Player = 1;
        public bool dicerolled = false;
        public int[,] Triangel = new int[24, 5];

        public void startpositions()
        {            
            for (int i = 0; i < 5; i++) //fylla med 5
            {
                Triangel[5, i] = 2;
                Triangel[11, i] = 1;
                Triangel[12, i] = 2;
                Triangel[18, i] = 1;
            }
            for (int i = 0; i < 3; i++)
            {
                Triangel[7, i] = 2;
                Triangel[16, i] = 1;

            }
            for (int i = 0; i < 2; i++)
            {
                Triangel[0, i] = 1;
                Triangel[23, i] = 2;
            }           
        }                
    }
}

