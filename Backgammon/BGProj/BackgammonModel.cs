using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace BGProj
{
    class BackgammonModel
    {

        public int dice1 = 0;
        public int dice2 = 0;
        public int dice3 = 0;
        public int dice4 = 0;
        public int playerWhite = 0;
        public int playerBlack = 0;
        public bool player1out = false;
        public bool player2out = false;
        public int blackPiecesOut = 0;
        public int whitePiecesOut = 0;
        public bool playerturn;
        private struct Triangel
        {
            public int number;
            public bool? color; //true = vit false = svart null = null
        }
        private Triangel[] triangels = new Triangel[24];
        public bool Modeltests()
        {
            bool ok = false;
            startPositions();
            if (triangels[5].color == false && triangels[0].color == true && triangels[4].number == 0)
                ok = true;
            if (returnHighest(0) == 2)
                ok = true;

            return ok;
        }
        public void startPositions()
        {
            triangels[0].number = 2; triangels[0].color = false;
            triangels[5].number = 5; triangels[5].color = true;
            triangels[7].number = 3; triangels[7].color = true;
            triangels[11].number = 5; triangels[11].color = false;
            triangels[12].number = 5; triangels[12].color = true;
            triangels[16].number = 3; triangels[16].color = false;
            triangels[18].number = 5; triangels[18].color = false;
            triangels[23].number = 2; triangels[23].color = true;

            //triangels[0].number = 3; triangels[0].color = true;
            //triangels[5].number = 5; triangels[5].color = true;
            //triangels[2].number = 5; triangels[2].color = true;


            //triangels[16].number = 1; triangels[16].color = false;
            //triangels[18].number = 5; triangels[18].color = false;
            //triangels[23].number = 2; triangels[23].color = false;



        }

        public int returnHighest(int arr)
        {
            return triangels[arr].number;
        }
        public int returnFirstFree(int arr)
        {
            if (triangels[arr].number >= 5)
                return 4;
            else if (triangels[arr].number == 0)
                return 0;
            else
                return triangels[arr].number;
        }
        public bool? returnColor(int arr)
        {
            return triangels[arr].color;
        }


        public bool availableMove(int triangle, int dice)
        {
            //Left-Down-Right direction
            if (playerturn && (triangle - dice) > -1 && (triangle - dice) != triangle)
            {
                if (triangels[triangle - dice].color == true || triangels[triangle - dice].number <= 1)
                    return true;
            }

                //Left-up-right direction
            else if (!playerturn && (triangle + dice) < 24 && (triangle + dice) != triangle)
            {
                if (triangels[triangle + dice].color == false || triangels[triangle + dice].number <= 1)
                    return true;
            }
            return false;
        }

        public void controlMove(int moveFrom, int Moveto)
        {
            int move;
            if (Moveto > 23)
            {
                move = Moveto - moveFrom;
                blackPiecesOut += 1;
            }
            else if (Moveto < 0) {
                move = moveFrom - Moveto;
                whitePiecesOut += 1;               
            }
            else if (moveFrom == -1)
            {
                playerBlack -= 1;
                if (triangels[Moveto].number == 1 && triangels[Moveto].color != playerturn)
                {
                    playerWhite += 1;
                    triangels[Moveto].number = 1;
                    triangels[Moveto].color = false;
                }
                else
                {
                    triangels[Moveto].number += 1;
                    triangels[Moveto].color = playerturn;
                }
                move = Moveto - moveFrom;


            }
            else if (moveFrom == 24)
            {
                playerWhite -= 1;
                if (triangels[Moveto].number == 1 && triangels[Moveto].color != playerturn)
                {
                    playerBlack += 1;
                    triangels[Moveto].number = 1;
                    triangels[Moveto].color = true;
                }
                else
                {
                    triangels[Moveto].number += 1;
                    triangels[Moveto].color = playerturn;
                }
                move = moveFrom - Moveto;


            }
            else if (triangels[Moveto].number == 1 && triangels[Moveto].color != playerturn)
            {
                if (playerturn)
                {
                    playerBlack += 1;
                    triangels[Moveto].number = 1;
                    triangels[Moveto].color = true;
                    triangels[moveFrom].number -= 1;
                    move = moveFrom - Moveto;
                }
                else
                {
                    playerWhite += 1;
                    triangels[Moveto].number = 1;
                    triangels[Moveto].color = false;
                    triangels[moveFrom].number -= 1;
                    move = Moveto - moveFrom;

                }
            }
            else
            {
                if (playerturn)
                    move = moveFrom - Moveto;
                else
                    move = Moveto - moveFrom;
                triangels[moveFrom].number -= 1;
                triangels[Moveto].number += 1;
                triangels[Moveto].color = playerturn;
            }
            changeDices(move);
        }

        public void moveOut(int first)
        {
                controlOut();
                if (player1out)
                {
                    int a = first + dice1;
                    int b = first + dice2;
                    int c = first + dice1 + dice2;
                    int d = c + dice3;
                    int e = d + dice4;

                    if (a > 23 && b > 23)
                    {
                        if (a < b)
                            controlMove(first, a);
                        if(b < a)
                            controlMove(first , b);
                        triangels[first].number -= 1;
                    }
                    else if (a > 23)
                    {
                        controlMove(first, a);
                        triangels[first].number -= 1;
                    }
                    else if (b > 23)
                    {
                        controlMove(first, b);
                        triangels[first].number -= 1;
                    }
                    else if (c > 23)
                    {
                        controlMove(first, c);
                        triangels[first].number -= 1;
                    }
                    else if (d > 23)
                    {
                        controlMove(first, d);
                        triangels[first].number -= 1;
                    }
                    else if (e > 23)
                    {
                        controlMove(first, e);
                        triangels[first].number -= 1;
                    }                                                                           
                }
                if (player2out)
                {
                    int a = first - dice1;
                    int b = first - dice2;
                    int c = first - dice1 - dice2;
                    int d = c - dice3;
                    int e = d - dice4;

                    if (a < 0 && b < 0)
                    {
                        if (a > b)
                        {
                            controlMove(first, a);
                        }
                        else if (b > a)
                        {
                            controlMove(first, b);
                        }
                        else if (b == a)
                        {
                            controlMove(first, b);
                        }
                        triangels[first].number -= 1;
                    }
                    else if (a < 0)
                    {
                        controlMove(first, a);
                        triangels[first].number -= 1;
                    }
                    else if (b < 0)
                    {
                        controlMove(first, b);
                        triangels[first].number -= 1;
                    }
                    else if (c < 0)
                    {
                        controlMove(first, c);
                        triangels[first].number -= 1;
                    }
                    else if (d < 0)
                    {
                        controlMove(first, d);
                        triangels[first].number -= 1;
                    }
                    else if (e < 0)
                    {
                        controlMove(first, e);
                        triangels[first].number -= 1;
                    }    
                }
        }
        public void controlOut()
        {

            if (!playerturn)
            {
                int countplayer1 = 0;
                for (int i = 0; i < 18; i++)
                {
                    if (triangels[i].color == false && triangels[i].number > 0)
                        countplayer1++;
                }
                if (countplayer1 == 0)
                    player1out = true;
            }
            else if (playerturn)
            {
                int countplayer2 = 0;
                for (int i = 23; i > 5; i--)
                {
                    if (triangels[i].color == true && triangels[i].number > 0)
                        countplayer2++;
                }
                if (countplayer2 == 0)
                    player2out = true;
            }
        }


        private void changeDices(int move)
        {
            if (dice4 == move) 
            {
                dice4 = 0; 
            }
            else if(dice4 + dice3 == move) 
            { 
                dice4 = 0; dice3 = 0; 
            }
            else if(dice4 + dice3 + dice2 == move) 
            { 
                dice4 = 0; dice3 = 0; dice2 = 0; 
            }
            else if(dice4 + dice3 + dice2 + dice1 == move) 
            { 
                dice4 = 0; dice3 = 0; dice2 = 0; dice1 = 0;
            }
            else if(dice3 == move) 
            { 
                dice3 = 0; 
            }
            else if(dice3 + dice2 == move) 
            { 
                dice3 = 0; dice2 = 0; 
            }
            else if(dice3 + dice2 + dice1 == move) 
            { 
                dice3 = 0; dice2 = 0; dice1 = 0; 
            }
            else if(dice2 == move) 
            { 
                dice2 = 0; 
            }
            else if(dice2 + dice1 == move)
            { 
                dice2 = 0; dice1 = 0; 
            }
            else if(dice1 == move) 
            { 
                dice1 = 0; 
            }            
        }

        public void rollDices()
        {
            dice3 = 0;
            dice4 = 0;
            Random num = new Random();
            int number = num.Next(1, 7);
            int number2 = num.Next(1, 7);
            //int number = 3;
            //int number2 = 3;
            dice1 = number;
            dice2 = number2;
            if (dice1 == dice2)
            {
                dice3 = dice1;
                dice4 = dice3;
            }
        }
        //public void ShowMessage(string textIn)
        //{
        //    Text.Content = textIn;
        //    this.Visibility = System.Windows.Visibility.Visible;
        //    DoubleAnimation animation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(5));
        //    this.BeginAnimation(System.Windows.Controls.Canvas.OpacityProperty, animation);

        //}

    }
}

