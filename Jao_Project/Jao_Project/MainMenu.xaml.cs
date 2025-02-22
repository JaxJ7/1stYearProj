using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.Xml;
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
using Jao_Project.Classes;
using Jao_Project.Pages;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private System.Media.SoundPlayer Click = new SoundPlayer("ButtonC.wav");
        private System.Media.SoundPlayer music = new SoundPlayer("Music/Ruins.wav");
        public Character Chara { get; set; }
        public MainMenu(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            music.PlayLooping();
        }


        private void Adventure_Click(object sender, RoutedEventArgs e)
        {
            AdventureP AdPage = new AdventureP(Chara);
            this.NavigationService.Navigate(AdPage);
        }

        void Button_Charainfo_Click(object sender, RoutedEventArgs e)
        {
            CharacterInfoP CIPage = new CharacterInfoP(Chara);
            this.NavigationService.Navigate(CIPage) ;
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            StoreP SPage = new StoreP(Chara);
            this.NavigationService.Navigate(SPage);
        }
        private void Gatcha_OnClick(object sender, RoutedEventArgs e)
        {
            GatchaP GaPage = new GatchaP(Chara);
            this.NavigationService.Navigate(GaPage);
        }
        private void Craft_Click(object sender, RoutedEventArgs e)
        {
            CraftP CrPage = new CraftP(Chara);
            this.NavigationService.Navigate(CrPage);
        }

        private void Hospital_Click(object sender, RoutedEventArgs e)
        {
            HospitalP HPage = new HospitalP(Chara);
            this.NavigationService.Navigate(HPage);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            var Main = (MainWindow)Application.Current.MainWindow;
            Main.Close();
        }
        private void MainMenu_OnLoaded(object sender, RoutedEventArgs e)
        {
            

        }


    }
}
