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

namespace Backgammon
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

        public void fillEllipse(int i, int x, int z)
        {

            UniformGrid grid = this.pieceGrid as UniformGrid;
            Ellipse p = grid.Children[x] as Ellipse;
            p.Name = "E" + z;
            p.Opacity = 1;
            RadialGradientBrush myBrushWhite = new RadialGradientBrush();
            myBrushWhite.GradientOrigin = new Point(0.75, 0.25);
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.White, 0.3));
            myBrushWhite.GradientStops.Add(new GradientStop(Colors.Wheat, 0.7));
            
            RadialGradientBrush myBrushBlack = new RadialGradientBrush();
            myBrushBlack.GradientOrigin = new Point(0.75, 0.25);
            myBrushBlack.GradientStops.Add(new GradientStop(Colors.Wheat, -0.2));
            myBrushBlack.GradientStops.Add(new GradientStop(Colors.Black, 0.4));
            if (i == 0)
            {
                p.Fill = null;
                p.Stroke = null;
            }
            if (i == 1)
            {
                p.Fill = Brushes.Black;
                p.Stroke = Brushes.DarkSlateGray;
                p.Fill = myBrushBlack;
            }
            else if (i == 2)
            {
                p.Fill = Brushes.White;
                p.Stroke = Brushes.DarkSlateGray;
                p.Fill = myBrushWhite;
            }
        }

        public void fillEllipseGold(int x, int player)
        {
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Ellipse p = grid.Children[x] as Ellipse;
            bool black = false;
            bool white = false;
            if (x > 1)
            {
                Ellipse Pbefore = grid.Children[x - 1] as Ellipse;
                if (Pbefore.Fill == Brushes.White)
                    white = true;
                else
                    black = true;
            }

            if (player == 1 && p.Fill != Brushes.White && white == false)
            {

                p.Fill = Brushes.Gold;
                p.Stroke = Brushes.Black;
                p.Opacity = 0.5;
            }
            else if (player == 2 && p.Fill != Brushes.Black && black == false)
            {
                p.Fill = Brushes.Gold;
                p.Stroke = Brushes.Black;
                p.Opacity = 0.5;
            }



        }
        public void showstroke(int x)
        {
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Ellipse p = grid.Children[x] as Ellipse;

            p.Stroke = Brushes.Gold;
        }

    }
}