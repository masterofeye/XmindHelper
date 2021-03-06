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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMindHelper
{
   /// <summary>
   /// Interaktionslogik für ListItem.xaml
   /// </summary>
   public partial class ListItem : UserControl
   {
      public ListItem(int Index)
      {

         InitializeComponent();
         IndexLabel.Content = Index.ToString();
      }

      public String GetName()
      {
         return Name.Text;
      }
   }
}
