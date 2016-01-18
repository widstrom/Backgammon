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
    /// Interaction logic for ucGameBoard.xaml
    /// </summary>
    public partial class ucGameBoard : UserControl
    {
        Shape _shapeSelected = null;
        
        public ucGameBoard()
        {
            InitializeComponent();
            StartPos();
        }
      

        private void grid11_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        public void StartPos()
        {
            ucPiece uc = this.grid11.Children[1] as ucPiece;
            uc.fillEllipse(5,true);

            ucPiece uc2 = this.grid7.Children[1] as ucPiece;
            uc2.fillEllipse(3, false);

            ucPiece uc3 = this.grid5.Children[1] as ucPiece;
            uc3.fillEllipse(5, false);

            ucPiece uc4 = this.grid0.Children[1] as ucPiece;
            uc4.fillEllipse(2, true);

            ucPiece uc5 = this.grid12.Children[1] as ucPiece;
            uc5.fillEllipse(5, false);

            ucPiece uc6 = this.grid16.Children[1] as ucPiece;
            uc6.fillEllipse(3, true);

            ucPiece uc7 = this.grid18.Children[1] as ucPiece;
            uc7.fillEllipse(5, true);

            ucPiece uc8 = this.grid23.Children[1] as ucPiece;
            uc8.fillEllipse(2, false);
 
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
            if (obj is Ellipse)
            {
                _shapeSelected = (Shape)obj;
                if (_shapeSelected.Name.Contains("")) //kolla närmre på detta
                {
                    _shapeSelected.Fill = Brushes.LightPink;
                    
                    
                }
                else
                {
                }
            }
            else
            {
            }
        }
    }
}
