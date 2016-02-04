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
        public bool playerturn;
        private struct Triangel
        {
            public int number;
            public bool color; //true = vit false = svart
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
        public bool returnColor(int arr)
        {
            return triangels[arr].color;
        }
        public void availableMove(int arr, out int z, out int x, out int c, out int v, out int b)
        {
            z = -1;
            x = -1;
            c = -1;
            v = -1;
            b = -1;

            if (!playerturn)
            {
                int first = arr + dice1;
                int second = arr + dice2;
                int third = arr + dice1 + dice2;
                int fourth = arr + dice1 + dice2 + dice3;
                int five = arr + dice1 + dice2 + dice3 + dice4;

                if (first < 24 && first != arr)
                {
                    if (triangels[first].color == playerturn || triangels[first].number <= 1)
                        z = first;
                }

                if (second < 24 && second != arr)
                {
                    if (triangels[second].color == playerturn || triangels[second].number <= 1)
                        x = second;
                }
                if (third < 24 && third != arr)
                {
                    if (z == -1 && x == -1)
                    {
                        c = -1;
                    }
                    else
                    {
                        if (triangels[third].color == playerturn || triangels[third].number <= 1)
                            c = third;
                    }
                }
                if (fourth < 24 && fourth != arr)
                {
                    if (c == -1)
                    {
                        v = -1;
                    }
                    else
                    {
                        if (triangels[fourth].color == playerturn || triangels[fourth].number <= 1)
                            v = fourth;
                    }
                }
                if (five < 24 && five != arr)
                {
                    if (v == -1)
                    {
                        c = -1;
                    }
                    else
                    {
                        if (triangels[five].color == playerturn || triangels[five].number <= 1)
                            b = five;
                    }
                }


            }
            else
            {
                int first = arr - dice1;
                int second = arr - dice2;
                int third = arr - dice1 - dice2;
                int fourth = arr - dice1 - dice2 - dice3;
                int five = arr - dice1 - dice2 - dice3 - dice4;

                if (first > -1 && first != arr)
                {
                    if (triangels[first].color == playerturn || triangels[first].number <= 1)
                        z = first;
                }
                if (second > -1 && second != arr)
                {
                    if (triangels[second].color == playerturn || triangels[second].number <= 1)
                        x = second;
                }
                if (third > -1 && third != arr)
                {
                    if (z == -1 && x == -1)
                    {
                        c = -1;
                    }
                    else
                    {
                        if (triangels[third].color == playerturn || triangels[third].number <= 1)
                            c = third;
                    }
                }
                if (fourth > -1 && fourth != arr)
                {
                    if (c == -1)
                    {
                        v = -1;
                    }
                    else
                    {
                        if (triangels[fourth].color == playerturn || triangels[fourth].number <= 1)
                            v = fourth;
                    }
                }
                if (five > -1 && five != arr)
                {
                    if (v == -1)
                    {
                        b = -1;
                    }
                    else
                    {
                        if (triangels[five].color == playerturn || triangels[five].number <= 1)
                            b = five;
                    }
                }

            }
        }
        public void controlMove(int moveFrom, int Moveto)
        {
            int move;
            if (moveFrom == -1)
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

        public void availableMoveout()
        {


        }
        public void controlOut()
        {

            if (playerturn)
            {
                int countplayer1 = 0;
                for (int i = 0; i < 18; i++)
                {
                    if (triangels[i].color == true && triangels[i].number > 0)
                        countplayer1++;
                }
                if (countplayer1 == 0)
                    player1out = true;
            }
            else
            {
                int countplayer2 = 0;
                for (int i = 23; i > 5; i--)
                {
                    if (triangels[i].color == false && triangels[i].number > 0)
                        countplayer2++;
                }
                if (countplayer2 == 0)
                    player2out = true;
            }

        }

        private void changeDices(int move)
        {
            if (dice4 == move) { dice4 = 0; }
            else if (dice4 + dice3 == move) { dice4 = 0; dice3 = 0; }
            else if (dice4 + dice3 + dice2 == move) { dice4 = 0; dice3 = 0; dice2 = 0; }
            else if (dice4 + dice3 + dice2 + dice1 == move) { dice4 = 0; dice3 = 0; dice2 = 0; dice1 = 0; }
            else if (dice3 == move) { dice3 = 0; }
            else if (dice3 + dice2 == move) { dice3 = 0; dice2 = 0; }
            else if (dice3 + dice2 + dice1 == move) { dice3 = 0; dice2 = 0; dice1 = 0; }
            else if (dice2 == move) { dice2 = 0; }
            else if (dice2 + dice1 == move) { dice2 = 0; dice1 = 0; }
            else if (dice1 == move) { dice1 = 0; }
        }

        public void rollDices()
        {
            dice3 = 0;
            dice4 = 0;
            Random num = new Random();
            int number = num.Next(1, 7);
            int number2 = num.Next(1, 7);
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

