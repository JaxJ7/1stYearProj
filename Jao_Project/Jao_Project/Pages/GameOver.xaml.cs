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

namespace Jao_Project.Pages
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Page
    {

        public string Text;
        public GameOver(string text)
        {
            InitializeComponent();
            Text = text;
            this.DataContext = this;
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {

            Start start = new Start();

            this.NavigationService.Navigate(start);
        }

        private void GameOver_OnLoaded(object sender, RoutedEventArgs e)
        {
            EndInfo.Text = Text;
        }
    }
}
