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

        public void fillEllipse(int fills, bool player)
        {
          
            UniformGrid grid = this.pieceGrid as UniformGrid;

           
                for (int i = 0; i < fills; i++)
                {
                    Ellipse p = grid.Children[i] as Ellipse;
                    p.Stroke = Brushes.DarkSlateGray;
                    if (player)
                        p.Fill = Brushes.Black;
                    else
                        p.Fill = Brushes.Red;
                }
            }
            
            
        }
    }



