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
using System.Windows.Threading;



namespace BGProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ScaleTransform scale;
        BackgammonModel Bmodel = new BackgammonModel();
        Shape _shapeSelected = null;
        ucPiece[] uc = new ucPiece[24]; //EN array med alla pieces
        private DispatcherTimer timer = new DispatcherTimer();
        int firstClicked;
        int secondClick;
        bool rolled = false;
        bool firstTimeRolled = true;

        public MainWindow()
        {
            InitializeComponent();


            //bool ok = Bmodel.Modeltests();
            //if (ok)
            //    MessageBox.Show("Självtest lyckades!");
            //else
            //    MessageBox.Show("Självtest misslyckades!");

            timer.Interval = TimeSpan.FromMilliseconds(75); //sätter rullhastigheten till 0,05sekunder
            timer.Tick += timer_Tick; //timer.tick sätts till funktionen timer_tick
            Bmodel.startPositions();
            initialall();

            //drawBoard();


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

        private void Image4_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            scale = new ScaleTransform(1.5, 1.5);
            image4.RenderTransform = scale;
        }
        private void image4_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            scale = new ScaleTransform(1, 1);
            image4.RenderTransform = scale;
        }
        private void image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void image5_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            scale = new ScaleTransform(1.5, 1.5);
            image5.RenderTransform = scale;
        }
        private void image5_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            scale = new ScaleTransform(1, 1);
            image5.RenderTransform = scale;
        }
        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                //Width = 1280;
                //Height = 720;
            }
            else
                WindowState = WindowState.Maximized;
            //MessageBox.Show("Här ska det vara settings!");
        }
        private void Image6_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            scale = new ScaleTransform(1.5, 1.5);
            Image6.RenderTransform = scale;
        }
        private void Image6_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            scale = new ScaleTransform(1, 1);
            Image6.RenderTransform = scale;
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!firstTimeRolled)
            {
                Dice3.Source = null;
                Dice4.Source = null;
                if (!rolled)
                {
                    Mouse.OverrideCursor = Cursors.Hand;
                    scale = new ScaleTransform(1.2, 1.2);
                    Border1.RenderTransform = scale;
                    timer.Start();
                }
            }

        }
        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!firstTimeRolled)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                scale = new ScaleTransform(1, 1);
                Border1.RenderTransform = scale;

                if (!rolled)
                {
                    Dice1.Source = null;
                    Dice2.Source = null;
                    Dice3.Source = null;
                    Dice4.Source = null;
                    timer.Stop();
                }
            }

        }

        private bool RollTurn()
        {
            Random p = new Random();
            int first, second;

            while (true)
            {
                first = p.Next(1, 7) + p.Next(1, 7);
                second = p.Next(1, 7) + p.Next(1, 7);

                Player_One_Roll.Content = first;
                Player_Two_Roll.Content = second;

                if (first > second)
                    return false;

                else if (second > first)
                    return true;
            }
        }

        private void Border1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rolled = true;
            Border1.Visibility = Visibility.Hidden;
            Border2.Visibility = Visibility.Visible;
            scale = new ScaleTransform(1, 1);
            Border1.RenderTransform = scale;
            
            timer.Stop();

            if (firstTimeRolled)
            {
                Bmodel.playerturn = RollTurn();
                firstTimeRolled = false;
            }

            else
            {
                Player_One_Roll.Content = "";
                Player_Two_Roll.Content = "";

                Bmodel.rollDices();
                drawBoard();
                showalltop();
                BitmapImage Img1 = new BitmapImage(new Uri(Bmodel.dice1.ToString() + ".png", UriKind.Relative));
                BitmapImage Img2 = new BitmapImage(new Uri(Bmodel.dice2.ToString() + ".png", UriKind.Relative));
                BitmapImage Img3 = new BitmapImage(new Uri(Bmodel.dice3.ToString() + ".png", UriKind.Relative));
                BitmapImage Img4 = new BitmapImage(new Uri(Bmodel.dice4.ToString() + ".png", UriKind.Relative));
                Dice1.Source = Img1;
                Dice2.Source = Img2;
                Dice3.Source = Img3;
                Dice4.Source = Img4;
            }



        }
        private void Image6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Border2_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            scale = new ScaleTransform(1.2, 1.2);
            Border2.RenderTransform = scale;
        }
        private void Border2_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            scale = new ScaleTransform(1, 1);
            Border2.RenderTransform = scale;
        }
        private void Border2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border2.Visibility = Visibility.Hidden;
            drawBoard();
            if (Bmodel.playerturn)
                Bmodel.playerturn = false;
            else
                Bmodel.playerturn = true;
            Border1.Visibility = Visibility.Visible;
            rolled = false;



        }
        private void drawBoard()
        {
            if (Bmodel.playerWhite == 0)
            {
                P2.Fill = null;
                P2.Stroke = null;
            }
            if (Bmodel.playerBlack == 0)
            {
                P1.Fill = null;
                P1.Stroke = null;
            }
            if (Bmodel.playerWhite > 0 && Bmodel.playerturn)
            {
                P2.Fill = Brushes.Wheat;
                P2.Stroke = Brushes.Gold;
            }
            else if (Bmodel.playerBlack > 0 && !Bmodel.playerturn)
            {
                P1.Fill = Brushes.Black;
                P1.Stroke = Brushes.Gold;
            }
            for (int i = 0; i < 24; i++)
                uc[i].FillTriangel(Bmodel.returnHighest(i), Bmodel.returnColor(i), i);

        }
        private void showalltop()
        {
            if (Bmodel.playerWhite > 0 && Bmodel.playerturn)
            {
                P2.Fill = Brushes.Wheat;
                P2.Stroke = Brushes.Gold;
            }
            else if (Bmodel.playerBlack > 0 && !Bmodel.playerturn)
            {
                P1.Fill = Brushes.Black;
                P1.Stroke = Brushes.Gold;
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    int high = Bmodel.returnHighest(i);
                    bool turn = Bmodel.returnColor(i);
                    uc[i].resetFillTop(Bmodel.returnHighest(i)); //temporär lösning

                    if (turn == Bmodel.playerturn && high > 0)
                    {
                        int z, x, c, v, b;
                        Bmodel.availableMove(i, out z, out x, out c, out v, out b);
                        

                        if (z >= 0 || x >= 0 || c >= 0 || v >= 0 || b >= 0)
                            uc[i].FillTop(Bmodel.returnHighest(i) - 1, i);
                    }

                    //Print number on piece
                    if (high > 5)
                        uc[i].WriteNumber(high, i);
                    //Erase number on piece
                    else if (high == 5)
                        uc[i].eraseNumber(high, i);
                    
                }
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {

            Random num = new Random();
            int number = num.Next(1, 7);
            int number2 = num.Next(1, 7);
            BitmapImage Img2 = new BitmapImage(new Uri(number2.ToString() + ".png", UriKind.Relative));
            Dice1.Source = Img2;
            BitmapImage Img = new BitmapImage(new Uri(number.ToString() + ".png", UriKind.Relative));
            Dice2.Source = Img;
        }

        private void theCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rolled)
            {
                HitTestResult target = VisualTreeHelper.HitTest(theCanvas, e.GetPosition(theCanvas));
                Point pt = e.GetPosition(theCanvas);
                HitTestResult hr2 = VisualTreeHelper.HitTest(theCanvas, pt);
                try
                {
                    Object obj = hr2.VisualHit;
                    _shapeSelected = (Shape)obj;


                    if (_shapeSelected.Stroke == Brushes.Gold)
                    {

                        Bmodel.controlOut();
                        if (_shapeSelected.Name == "P1")
                            firstClicked = -1;
                        else if (_shapeSelected.Name == "P2")
                            firstClicked = 24;
                        else
                            firstClicked = Int32.Parse(_shapeSelected.Name.Remove(0, 1));
                        int z, x, c, v, b;
                        Bmodel.availableMove(firstClicked, out z, out x, out c, out v, out b);
                        drawBoard();
                        showalltop();//ritar ut pjäserna 

                        //_shapeSelected.Stroke = Brushes.Green;
                        if (z >= 0)
                            uc[z].FillMove(Bmodel.returnFirstFree(z), z);
                        if (x >= 0)
                            uc[x].FillMove(Bmodel.returnFirstFree(x), x);
                        if (c >= 0)
                            uc[c].FillMove(Bmodel.returnFirstFree(c), c);
                        if (v >= 0)
                            uc[v].FillMove(Bmodel.returnFirstFree(v), v);
                        if (b >= 0)
                            uc[b].FillMove(Bmodel.returnFirstFree(b), b);

                        //gå ut?
                    }
                    else if (_shapeSelected.Name.Contains("M"))
                    {
                        secondClick = Int32.Parse(_shapeSelected.Name.Remove(0, 1));
                        Bmodel.controlMove(firstClicked, secondClick);
                        BitmapImage Img1 = new BitmapImage(new Uri(Bmodel.dice1.ToString() + ".png", UriKind.Relative));
                        Dice1.Source = Img1;
                        BitmapImage Img2 = new BitmapImage(new Uri(Bmodel.dice2.ToString() + ".png", UriKind.Relative));
                        Dice2.Source = Img2;
                        BitmapImage Img3 = new BitmapImage(new Uri(Bmodel.dice3.ToString() + ".png", UriKind.Relative));
                        Dice3.Source = Img3;
                        BitmapImage Img4 = new BitmapImage(new Uri(Bmodel.dice4.ToString() + ".png", UriKind.Relative));
                        Dice4.Source = Img4;
                        drawBoard();
                        showalltop();
                        //Bmodel.returnFirstFree(secondClick));

                    }
                    else if (_shapeSelected is Ellipse)
                    {
                        MessageBox.Show("NEJ!");

                    }

                }
                catch (Exception ex)
                {

                }
            }

        }

        
    }
}
