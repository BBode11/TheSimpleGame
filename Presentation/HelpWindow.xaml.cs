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
using System.Windows.Shapes;

namespace TheSimpleGame.Presentation
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method for closing the help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
