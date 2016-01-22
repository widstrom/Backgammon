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
            if (i == 0)
            {
                p.Fill = null;
                p.Stroke = null;
            }
            if (i == 1)
            {
                p.Fill = Brushes.Black;
                p.Stroke = Brushes.DarkSlateGray;
            }
            else if (i == 2)
            {
                p.Fill = Brushes.Red;
                p.Stroke = Brushes.DarkSlateGray;
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