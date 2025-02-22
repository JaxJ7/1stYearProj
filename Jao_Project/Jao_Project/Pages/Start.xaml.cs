using Jao_Project.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
        }

        

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            string P = PlayerName.Text;

            var Player = new Character(P);

            var DefaultW = new Wepons("Stick", 1, 1, 0,  "Its better than nothing I guess", "Weapon");
            var DefaultA = new Armor("Shirt", 1, 1, 1000, "What? do you want to be naked?", "Armor");
            var DefaultItem = new Items("Pet Rock", 5, 1, "Item", "I just really Like this rock I carry it on my adventures every time");
            var ManaP = new Potions("Mana Potion", 0, 50, 0, "Potion");
            var HeathP = new Potions("Health Potion", 100, 0, 0, "Potion");
            Player.PotionInventoy.Add(ManaP); Player.PotionInventoy.Add(HeathP);
            Player.ArmorInventoy.Add(DefaultA); Player.WeponInventoy.Add(DefaultW); Player.ItemInventoy.Add(DefaultItem);
            Player.Health = 200; Player.MaxHealth = 200;
            Player.Pity4Count = 0; Player.Pity5Count = 0;
            Player.Mana = 50; Player.MaxMana = 50; Player.Level = 1;
            Player.MaxAttack = 25; Player.MinAttack = 10; Player.Defense = 5;
            Player.Expirence = 0; Player.MaxExpirence = 100;
            Player.Money = 100; Player.GatchaMoney = 1000;
            Player.Armor = DefaultA; Player.Wepon = DefaultW;

            MainMenu mainMenu = new MainMenu(Player);

            this.NavigationService.Navigate(mainMenu);
        }

        private void PlayerName_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (PlayerName.Text == "")
            {
                Continue.IsEnabled = false;
            }
            else
            {
                Continue.IsEnabled = true;
            }
        }

        private void Start_OnLoaded(object sender, RoutedEventArgs e)
        {
            Continue.IsEnabled = false;
        }

        private void PlayerName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (PlayerName.Text == "")
            {
                Continue.IsEnabled = false;
            }
            else
            {
                Continue.IsEnabled = true;
            }
        }
    }
}
