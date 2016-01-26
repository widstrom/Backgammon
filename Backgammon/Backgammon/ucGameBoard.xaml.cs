using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;


namespace Backgammon
{
    /// <summary>
    /// Interaction logic for ucGameBoard.xaml
    /// </summary>
    public partial class ucGameBoard : UserControl //UCGAMEBOARD ÄR ENDAST TILL FÖR ANIMATIONER, SKAPA EN NY KLASS FÖR ATT HÅLLA KOLL PÅ REGLER OCH ARRAYER
    {
        MatchResult mr = new MatchResult();
        Shape _shapeSelected = null;
        ucPiece[] uc = new ucPiece[24]; //EN array med alla pieces
        double cordfromX = 0;
        double cordfromY = 0;
        double cordToX = 0;
        double cordToY = 0;

        private DispatcherTimer timer = new DispatcherTimer(); //globalvariabel för dispatchertimern
        private int count = 0;
        int recentTriangel = 0;
        int dice1 = 0;
        int dice2 = 0;
        int dice3 = 0;
        int dice4 = 0;


        public ucGameBoard()
        {
            InitializeComponent();
            mr.startpositions(); //när gameborder öppnas fylls arraysen med start värdena.
            initialall(); //här itiallerar vi uc arrayen med dess gridar med children 1
            ritaPjäser();

            timer.Interval = TimeSpan.FromMilliseconds(50); //sätter rullhastigheten till 0,05sekunder
            timer.Tick += timer_Tick; //timer.tick sätts till funktionen timer_tick

        }





        public void initialall()
        {
            uc[0] = this.grid0.Children[1] as ucPiece;
            uc[1] = this.grid1.Children[1] as ucPiece;
            uc[2] = this.grid2.Children[1] as ucPiece;
            uc[3] = this.grid3.Children[1] as ucPiece;
            uc[4] = this.grid4.Children[1] as ucPiece;
            uc[5] = this.grid5.Children[1] as ucPiece;
            uc[6] = this.grid6.Children[1] as ucPiece;
            uc[7] = this.grid7.Children[1] as ucPiece;
            uc[8] = this.grid8.Children[1] as ucPiece;
            uc[9] = this.grid9.Children[1] as ucPiece;
            uc[10] = this.grid10.Children[1] as ucPiece;
            uc[11] = this.grid11.Children[1] as ucPiece;
            uc[12] = this.grid12.Children[1] as ucPiece;
            uc[13] = this.grid13.Children[1] as ucPiece;
            uc[14] = this.grid14.Children[1] as ucPiece;
            uc[15] = this.grid15.Children[1] as ucPiece;
            uc[16] = this.grid16.Children[1] as ucPiece;
            uc[17] = this.grid17.Children[1] as ucPiece;
            uc[18] = this.grid18.Children[1] as ucPiece;
            uc[19] = this.grid19.Children[1] as ucPiece;
            uc[20] = this.grid20.Children[1] as ucPiece;
            uc[21] = this.grid21.Children[1] as ucPiece;
            uc[22] = this.grid22.Children[1] as ucPiece;
            uc[23] = this.grid23.Children[1] as ucPiece;

        }

        private void btnDice_Click(object sender, RoutedEventArgs e)
        {
            image1.Opacity = 1;
            image2.Opacity = 1;
            if (mr.Player == 1)
            {
                mr.Player = 2;
                kastaTärning();
            }
            else
            {
                mr.Player = 1;
                kastaTärning();
            }
        }

        private void kastaTärning()
        {
            ritaPjäser();
            timer.Start();
            Random num = new Random();
            int number = num.Next(1, 7);
            int number2 = num.Next(1, 7);
            BitmapImage Img2 = new BitmapImage(new Uri(number2.ToString() + ".png", UriKind.Relative));
            image2.Source = Img2;
            BitmapImage Img = new BitmapImage(new Uri(number.ToString() + ".png", UriKind.Relative));
            image1.Source = Img;

            showalltop(mr.Player);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 40) //här ändrar vi hur länge den ska snurra
            {
                count = 0;
                timer.Stop();
            }
            Random num = new Random();
            int number = num.Next(1, 7);
            int number2 = num.Next(1, 7);
            BitmapImage Img2 = new BitmapImage(new Uri(number2.ToString() + ".png", UriKind.Relative));
            image2.Source = Img2;
            BitmapImage Img = new BitmapImage(new Uri(number.ToString() + ".png", UriKind.Relative));
            image1.Source = Img;
            dice1 = number;
            dice2 = number2;

        }


        public void ritaPjäser()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int z = 0; z < 5; z++)
                    uc[i].fillEllipse(mr.Triangel[i, z], z, i);
            }
        }




        //|*********************************************************************|
        //| UPPGIFT: Hitta objekten som skall flyttas på brädet.                |
        //| NOTERA:  Gör en ifsats som hittar de rätta objekten.                |
        //|                                                                     |
        //|*********************************************************************|
        private void theCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (mr.Player == 0) //Player är 0, innan man rullat tärningarna första gången.
            {
                MessageBox.Show("Rulla tärningarna först!");
            }

            else
            {

                //showalltop(mr.Player);
                Point pt2 = e.GetPosition(theCanvas);
                HitTestResult hr2 = VisualTreeHelper.HitTest(theCanvas, pt2);
                Object obj2 = hr2.VisualHit;
                if (obj2 is Shape)
                {
                    _shapeSelected = (Shape)obj2;
                    showalltop(mr.Player);
                    if (_shapeSelected is Rectangle)
                    {

                    }
                    else
                    {
                        int valdTri = Int32.Parse(_shapeSelected.Name.Remove(0, 1));

                        if (_shapeSelected.Stroke == Brushes.Black)
                        {

                            mr.Triangel[valdTri, FirstEmpty(valdTri)] = mr.Player;
                            mr.Triangel[recentTriangel, FirstBrick(recentTriangel)] = 0;
                            kickPlayer(valdTri);
                            ritaPjäser();
                            showalltop(mr.Player);
                            changeDice(valdTri);

                        }
                        else if (mr.Triangel[valdTri, 0] == mr.Player && _shapeSelected.Stroke == Brushes.Gold)
                        {
                            cordfromX = pt2.X;
                            cordfromY = pt2.Y;
                            _shapeSelected.Stroke = Brushes.Green;
                            ritaPjäser();
                            showallmoves(valdTri);
                            showalltop(mr.Player);
                            recentTriangel = valdTri;


                        }



                    }
                }
            }
        }
        private void kickPlayer(int triangle)
        {
            int firstcolor = mr.Triangel[triangle, 0];
            int secondcolor = mr.Triangel[triangle, 1];

            if (firstcolor != secondcolor && secondcolor != 0)
            {
                if (mr.Triangel[triangle, 0] == 1)
                    MessageBox.Show("Svart mark utskickad!");
                else
                    MessageBox.Show("Vit Mark utskickad!");

                mr.Triangel[triangle, 0] = secondcolor;
                mr.Triangel[triangle, 1] = 0;


            }
        }
        private void changeDice(int triangle)
        {
            if (mr.Player == 1)
            {
                int step = triangle - recentTriangel;
                if (dice1 == step)
                {
                    dice1 = 0;
                    image1.Opacity = 0.25;
                }
                else
                {
                    image2.Opacity = 0.25;
                    dice2 = 0;
                    ritaPjäser();
                }
            }
            else
            {
                int step = recentTriangel - triangle;
                if (dice1 == step)
                {
                    dice1 = 0;
                    image1.Opacity = 0.25;
                }
                else
                {
                    image2.Opacity = 0.25;
                    dice2 = 0;

                }
            }
        }
        private void showallmoves(int triangelFrom)
        {


            if (mr.Player == 1)
            {
                int first = triangelFrom + dice1;
                int second = triangelFrom + dice2;
                int third = triangelFrom + dice3;
                int fourth = triangelFrom + dice4;

                if (first < 23 && first != triangelFrom)
                    uc[first].fillEllipseGold(FirstEmpty(first), mr.Player);
                if (second < 23 && second != triangelFrom)
                    uc[second].fillEllipseGold(FirstEmpty(second), mr.Player);


            }
            else
            {
                int first = triangelFrom - dice1;
                int second = triangelFrom - dice2;

                if (first >= 0 && first != triangelFrom)
                    uc[first].fillEllipseGold(FirstEmpty(first), mr.Player);
                if (second >= 0 && second != triangelFrom)
                    uc[second].fillEllipseGold(FirstEmpty(second), mr.Player);

            }

        }

        private int FirstEmpty(int triangelto)
        {

            for (int i = 0; i < 5; i++)
            {
                if (i == 4 && mr.Triangel[triangelto, i] == 0)
                {
                    return i;
                }
                else if (mr.Triangel[triangelto, i] == 0)
                {
                    return i;
                }

            }
            return 4; //kolla om den ritar?

        }
        private int FirstBrick(int recenttri)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (mr.Triangel[recenttri, i] != 0)
                {
                    return i;
                }

            }
            return 0;
        }

        private void showalltop(int x)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (z == 4 && mr.Triangel[i, z] == x)
                    {
                        uc[i].showstroke(z);
                    }
                    else if (mr.Triangel[i, z] == x && mr.Triangel[i, z + 1] == 0)
                    {
                        uc[i].showstroke(z);
                    }
                }
            }
        }
    }
}
