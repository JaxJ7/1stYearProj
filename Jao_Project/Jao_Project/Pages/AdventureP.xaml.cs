using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jao_Project.Classes;
using Wpf.Ui.Controls;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for AdventureP.xaml
    /// </summary>
    public partial class AdventureP : Page
    {
        public Character Chara { get; set; }
        public AdventureP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
        }


        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void BattleB_Click(object sender, RoutedEventArgs e)
        {
            BattleP NewBattle = new BattleP(Chara);
            this.NavigationService.Navigate(NewBattle);
        }

        private void BossRaidB_Click(object sender, RoutedEventArgs e)
        {
            BossBattleP NewBattle = new BossBattleP(Chara);
            this.NavigationService.Navigate(NewBattle);
        }

        private void DemonLord_Click(object sender, RoutedEventArgs e)
        {
            DemonLordP NewBattle = new DemonLordP(Chara);
            this.NavigationService.Navigate(NewBattle);
        }

    }
}
