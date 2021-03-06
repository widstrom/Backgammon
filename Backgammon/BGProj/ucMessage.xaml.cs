﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BGProj
{  
    public partial class ucMessage : UserControl
    {
        public ucMessage()
        {
            InitializeComponent();
        }

        // Funktion för att skriva ut meddelande på skärmen  
        // Tack Grupp Blå för klassen!
        public void showMessage(string text)
        {
            Meddelande.Content = text;
            this.Visibility = System.Windows.Visibility.Visible;
            DoubleAnimation anim = new DoubleAnimation(3, 0, TimeSpan.FromSeconds(3));
            this.BeginAnimation(Canvas.OpacityProperty, anim);
        }
    }
}
