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

        private DispatcherTimer timer = new DispatcherTimer(); //globalvariabel för dispatchertimern
        private int count = 0;

        public ucGameBoard()
        {
            InitializeComponent();

            mr.startpositions(); //när gameborder öppnas fylls arraysen med start värdena.
            initialall(); //här iitiallerar vi uc arrayen med dess gridar med children 1
            StartPos(); //här målar vi ut utifrån alla arrayer. OBS BYT NAMN

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            timer.Start();
            Random num = new Random();
            int Number = num.Next(1, 7);
            int Number2 = num.Next(1, 7);
            BitmapImage Img2 = new BitmapImage(new Uri(Number2.ToString() + ".png", UriKind.Relative));
            image2.Source = Img2;
            BitmapImage Img = new BitmapImage(new Uri(Number.ToString() + ".png", UriKind.Relative));
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
            int Number = num.Next(1, 7);
            int Number2 = num.Next(1, 7);
            BitmapImage Img2 = new BitmapImage(new Uri(Number2.ToString() + ".png", UriKind.Relative));
            image2.Source = Img2;
            BitmapImage Img = new BitmapImage(new Uri(Number.ToString() + ".png", UriKind.Relative));
            image1.Source = Img;


        }


        public void StartPos()
        {
            if (mr.Player == 1)
            {
                turn2.Stroke = Brushes.Gray;
                turn1.Stroke = Brushes.Gold;
            }
            if (mr.Player == 2)
            {
                turn1.Stroke = Brushes.Gray;
                turn2.Stroke = Brushes.Gold;
            }


            //for (int i = 0; i < 24; i++)
            //{
            //    for (int z = 0; z < 5; z++)
            //        uc[i].fillEllipse(mr.Triangel[i, z, 0], z, i);
            //}

        }




        //|*********************************************************************|
        //| UPPGIFT: Hitta objekten som skall flyttas på brädet.                |
        //| NOTERA:  Gör en ifsats som hittar de rätta objekten.                |
        //|                                                                     |
        //|*********************************************************************|
        private void theCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(theCanvas);
            HitTestResult hr = VisualTreeHelper.HitTest(theCanvas, pt);
            Object obj = hr.VisualHit;
            if (obj is Shape)
            {
                _shapeSelected = (Shape)obj;
                if (_shapeSelected.Name.Contains("E")) //kolla närmre på detta
                {
                    MessageBox.Show(_shapeSelected.Name);


                    if (mr.Player == 1)
                        mr.Player = 2;
                    else
                        mr.Player = 1;
                    StartPos();
                }





            }
        }
        private void showalltop(int x)
        {

            //for (int i = 0; i < 24; i++)
            //{
            //    for (int z = 0; z < 5; z++)
            //    {
            //        if (z == 4 && mr.Triangel[i, z - 1, 0] == x)
            //        {
            //            uc[i].showstroke(z);
            //        }
            //        else if (mr.Triangel[i, z, 0] == x && mr.Triangel[i, z + 1, 0] == 0)
            //        {

            //            uc[i].showstroke(z);

            //        }
            //    }
            //}

        }

    }
}
