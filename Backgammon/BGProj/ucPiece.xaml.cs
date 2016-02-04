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
using System.Windows.Media.Effects;
namespace BGProj
{
    /// <summary>
    /// Interaction logic for ucPiece.xaml
    /// </summary>
    public partial class ucPiece : UserControl
    {

        public ucPiece()
        {
            InitializeComponent();
        }
        public void FillTriangel(int triangel, bool color, int number)
        {


            RadialGradientBrush myBrushWhite = new RadialGradientBrush();
            myBrushWhite.GradientOrigin = new Point(0.75, 0.25);
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.White, 0.3));
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.Wheat, 0.7));

            RadialGradientBrush myBrushBlack = new RadialGradientBrush();
            myBrushBlack.GradientOrigin = new Point(0.75, 0.25);
            myBrushBlack.GradientStops.Add(new GradientStop(Colors.Wheat, -0.2));
            myBrushBlack.GradientStops.Add(new GradientStop(Colors.Black, 0.4));


            UniformGrid grid = this.pieceGrid as UniformGrid;



            if (triangel > 5)
                triangel = 5;

            for (int i = 0; i < triangel; i++)
            {
                Grid cell = grid.Children[i] as Grid;
                Ellipse p = cell.Children[0] as Ellipse;

                p.Name = "E" + number;


                if (color == true)
                {
                    p.Fill = myBrushWhite;
                    //p.Stroke = Brushes.DarkSlateGray;
                    p.Opacity = 1;
                }
                else if (color == false)
                {
                    p.Fill = myBrushBlack;
                    //p.Stroke = Brushes.DarkSlateGray;
                    p.Opacity = 1;
                }
            }
            for (int k = triangel; k < 5; k++)
            {
                Grid cell = grid.Children[k] as Grid;
                Ellipse l = cell.Children[0] as Ellipse;
                l.Fill = null;
                l.Stroke = null;
            }
        }

        //Writing a number on pieces when number of pieces on one triangle excceeds 5
        public void WriteNumber(int index, bool playerturn)
        {
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Grid cell = grid.Children[4] as Grid;
            TextBlock t = cell.Children[1] as TextBlock;
            if (playerturn)
            {
                t.Text = index.ToString();
                t.Foreground = Brushes.Red;
            }
            else
            {
                t.Text = index.ToString();
                t.Foreground = Brushes.Red;
            }
        }

        //Erases number on stack
        public void eraseNumber(int index)
        {
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Grid cell = grid.Children[4] as Grid;
            TextBlock t = cell.Children[1] as TextBlock;

            t.Text = "";
            t.Foreground = Brushes.Transparent;
        }

        public void FillTop(int ellipse)
        {
            if (ellipse == 5)
                ellipse = 4;
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Grid cell = grid.Children[ellipse] as Grid;
            Ellipse p = cell.Children[0] as Ellipse;


            p.Stroke = Brushes.Gold;

        }
        public void FillMove(int highest, int number)
        {

            RadialGradientBrush myBrushWhite = new RadialGradientBrush();
            myBrushWhite.GradientOrigin = new Point(0.75, 0.25);
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.White, 0.3));
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.Wheat, 0.7));



            UniformGrid grid = this.pieceGrid as UniformGrid;
            Grid cell = grid.Children[highest] as Grid;
            Ellipse p = cell.Children[0] as Ellipse;
            p.Name = "M" + number;

            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(238, 234, 168, 80));
            p.Fill = brush;
            p.StrokeThickness = 0.5;
            p.Stroke = Brushes.SlateGray;
            p.Opacity = 1;
            //p.Stroke = Brushes.DarkSlateGray;




        }
    }
}
