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
            {
                triangel = 5;
            }
            
                for (int i = 0; i < triangel; i++)
                {
                    Ellipse p = grid.Children[i] as Ellipse;
                    p.Name = "E" + number;
                    if (color == true)
                    {
                        p.Fill = myBrushBlack;
                        p.Stroke = Brushes.DarkSlateGray;
                        p.Opacity = 1;
                    }
                    else if (color == false)
                    {
                        p.Fill = myBrushWhite;
                        p.Stroke = Brushes.DarkSlateGray;
                        p.Opacity = 1;
                    }
                    
                    
                }
                for (int k = triangel; k < 5; k++)
                {
                    Ellipse l = grid.Children[k] as Ellipse;
                    l.Fill = null;
                    l.Stroke = null;

                }
                

                
        }
        public void FillTop(int ellipse)
        {
            if (ellipse == 5)
                ellipse = 4;
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Ellipse p = grid.Children[ellipse] as Ellipse;
            p.Stroke = Brushes.Gold;

        }
        public void FillMove(int highest, int number)
        {
             
            UniformGrid grid = this.pieceGrid as UniformGrid;
            Ellipse p = grid.Children[highest] as Ellipse;
            p.Name = "E" + number;
            p.Fill = Brushes.Gold;
            p.Stroke = Brushes.DarkSlateGray;
        }
    }
}
