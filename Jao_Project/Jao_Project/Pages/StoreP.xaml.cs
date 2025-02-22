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
using Jao_Project.Classes;
using Wpf.Ui.Controls;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for StoreP.xaml
    /// </summary>
    public partial class StoreP : Page
    {
        public Character Chara { get; set; }

        public List<Armor> StoreArmorLists = new List<Armor>();
        public List<Wepons> StoreWeponsLists = new List<Wepons>();
        public List<Items> ItemsLists = new List<Items>();
        public List<Potions> PotionsList = new List<Potions>();

        private List<string> CmdSellBuy = new List<string>();


        public string WhatInfo = "Weapon";
        public StoreP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
        }

        void iniciate()
        {
            //Weapons
            var Weapon1 = new Wepons("Dull Sword", 2, 5,  350, "Man, even a kitchen knife is sharper than this", "Weapon");
            var Weapon2 = new Wepons("Black Sword", 2, 6, 500, "Its really just a dull sword painted black... bruh", "Weapon");
            var Weapon3 = new Wepons("Small Dagger", 3, 11,   1000, "Wait.. A dagger is not a sword.. Ah well", "Weapon");
            var Weapon4 = new Wepons("Kitchen Knife", 3, 15,   1500,"Huh so they also use this for killing monsters.. ok then", "Weapon");
            var Weapon5 = new Wepons("Katana", 4, 27, 6500, "Wait arent we in a western style game? why is this here?", "Weapon");
            var Weapon6 = new Wepons("Sword Slasher", 4, 30,  7000, "Bro who named this sword.. They probably lack imagination..", "Weapon");
            StoreWeponsLists.Add(Weapon1); StoreWeponsLists.Add(Weapon2);
            StoreWeponsLists.Add(Weapon3); StoreWeponsLists.Add(Weapon4);
            StoreWeponsLists.Add(Weapon5); StoreWeponsLists.Add(Weapon6);

            //Armor
            var Armor1 = new Armor("Leather Armor", 2, 6, 550,"It protects me better that my shirt", "Armor");
            var Armor2 = new Armor("Wooden Armor", 2, 7, 700, "Yhe it protects me but Its really not that flexible", "Armor");
            var Armor3 = new Armor("Nameless Armor", 3, 9,900, "Bruh just say its material and say armor or somethin", "Armor");
            var Armor4 = new Armor("Chain mail", 3, 10, 1000,"Well its a chain mail.. ", "Armor");
            var Armor5 = new Armor("Iron Armor", 4, 25, 6500,"Its a good armor", "Armor");
            var Armor6 = new Armor("Death-walker's Plate", 4, 30, 7000,"Lol the creator must have Googled this name.. Wait what is Google", "Armor");
            StoreArmorLists.Add(Armor1); StoreArmorLists.Add(Armor2);
            StoreArmorLists.Add(Armor3); StoreArmorLists.Add(Armor4);
            StoreArmorLists.Add(Armor5); StoreArmorLists.Add(Armor6);

            CmdSellBuy= new List<string>
            {
                "Buy", "Sell"
            };

            CmB.ItemsSource = CmdSellBuy;
            CmB.SelectedItem = CmB.Items[0];

            ListBox.ItemsSource = StoreWeponsLists.OrderByDescending(c => c.Rarity);
            BuySellButton.Content = "Buy";
            CharacterDetails.Text = $"Gold: {Chara.Money}";


        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void StoreP_OnLoaded(object sender, RoutedEventArgs e)
        {
            iniciate();
        }

        private void BuySellButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WhatInfo == "Weapon")
            {
                if (CmB.SelectedItem.ToString() == "Buy")
                {
                    Wepons p = (Wepons)ListBox.SelectedItem;
                    if (p.Price < Chara.Money)
                    {
                        Chara.WeponInventoy.Add(p);
                        var wep = Chara.WeponInventoy.IndexOf(p);
                        Chara.Money -= p.Price;
                        Details.Text = $"I bought {p.Name} for {p.Price}";
                    }
                    else
                    {
                        Details.Text = "Im Broke, I cant Afford to buy this yet.. Better save up some gold ";
                    }
                }
                else if (CmB.SelectedItem.ToString() == "Sell")
                {
                    Wepons p = (Wepons)ListBox.SelectedItem;

                    if (p.Name == Chara.Wepon.Name)
                    {
                        Details.Text = "Better not sell it if Im equipping it";
                    }
                    else if (p.Name == "Stick")
                    {
                        Details.Text = "Nooo I aint selling my stick Its a good stick... They wont give me anything for it anyway ";
                    }
                    else
                    {
                        double Price = (double)p.Price;
                        double SellPrice = Price - (Price * 0.5);
                        int intSellP = (int)SellPrice;
                        Chara.Money += intSellP;
                        Details.Text = $"I sold my {p.Name} for {intSellP}";
                        Chara.WeponInventoy.Remove(p);
                    }
                    ListBox.ItemsSource = Chara.WeponInventoy.OrderByDescending(c => c.Rarity); ;
                }
            }
            else if (WhatInfo == "Armor")
            {
                if (CmB.SelectedItem.ToString() == "Buy")
                {
                    Armor p = (Armor)ListBox.SelectedItem;
                    if (p.Price < Chara.Money)
                    {
                        Chara.ArmorInventoy.Add(p);
                        Chara.Money -= p.Price;
                        Details.Text = $"I bought {p.Name} for {p.Price}";
                    }
                    else
                    {
                        Details.Text = "Im Broke, I cant Afford to buy this yet.. Better save up some gold ";
                    }
                }
                else if (CmB.SelectedItem.ToString() == "Sell")
                {
                    Armor p = (Armor)ListBox.SelectedItem;
                    if (p == Chara.Armor)
                    {
                        Details.Text = "Better not sell it if Im equipping it";
                    }
                    else if (p.Name == "Shirt")
                    {
                        Details.Text = "Nooo I ain't selling my shirt.. I ain't wearing an armor when i sleep";
                    }
                    else
                    {
                        double Price = (double)p.Price;
                        double SellPrice = Price - (Price * 0.5);
                        int intSellP = (int)SellPrice;
                        Chara.Money += intSellP;
                        Details.Text = $"I sold my {p.Name} for {intSellP}";
                        int I = Chara.ArmorInventoy.IndexOf(p);
                        Chara.ArmorInventoy.RemoveAt(I);
                    }

                    ListBox.ItemsSource = Chara.ArmorInventoy.OrderByDescending(c => c.Rarity); ;
                }
            }
            CharacterDetails.Text = $"Gold: {Chara.Money}";
        }

        private void WeopenButton_Click(object sender, RoutedEventArgs e)
        {
            WhatInfo = "Weapon";
            if (CmB.SelectedItem.ToString() == "Buy")
            {
                ListBox.ItemsSource = StoreWeponsLists.OrderByDescending(c => c.Rarity);
            }
            else if (CmB.SelectedItem.ToString() == "Sell")
            {
                ListBox.ItemsSource = Chara.WeponInventoy.OrderByDescending(c => c.Rarity);
            }
        }
        private void ArmorButton_OnClick(object sender, RoutedEventArgs e)
        {
            WhatInfo = "Armor";
            if (CmB.SelectedItem.ToString() == "Buy")
            {
                ListBox.ItemsSource = StoreArmorLists.OrderByDescending(c => c.Rarity);
            }
            else if (CmB.SelectedItem.ToString() == "Sell")
            {
                ListBox.ItemsSource = Chara.ArmorInventoy.OrderByDescending(c => c.Rarity); ;
            }
        }


        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem == null) return;

            if (WhatInfo == "Weapon")
            {
                Wepons p = (Wepons)ListBox.SelectedItem;
                var infoW = new StringBuilder();
                infoW.AppendLine($"Name: {p.Name}");
                infoW.AppendLine($"Rarity: {p.Rarity}");
                infoW.AppendLine($"Attack: {p.AtkAdd}");
                infoW.AppendLine($"Description : \n\t{p.Discription}");
                infoW.AppendLine($"\n Buying Price: {p.Price}");
                double Price = (double)p.Price;
                double SellPrice = Price - (Price * 0.5);
                int intSellP = (int)SellPrice;
                infoW.AppendLine($" Selling Price: {intSellP}");


                string InfowGet = infoW.ToString();
                Details.Text = InfowGet;
            }
            else if (WhatInfo == "Armor")
            {
                Armor p = (Armor)ListBox.SelectedItem;
                var infoA = new StringBuilder();
                infoA.AppendLine($"Name: {p.Name}");
                infoA.AppendLine($"Rarity: {p.Rarity}");
                infoA.AppendLine($"Attack: {p.DefAdd}");
                infoA.AppendLine($"Description : \n{p.Discription}");
                infoA.AppendLine($"\n Price: {p.Price}");
                double Price = (double)p.Price;
                double SellPrice = Price - (Price * 0.5);
                int intSellP = (int)SellPrice;
                infoA.AppendLine($" Selling Price: {intSellP}");

                string InfoA = infoA.ToString();
                Details.Text = InfoA;
            }
        }

        private void CmB_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WhatInfo == "Weapon")
            {
                if (CmB.SelectedItem.ToString() == "Buy")
                {
                    BuySellButton.Content = "Buy";
                    ListBox.ItemsSource = StoreWeponsLists.OrderByDescending(c => c.Rarity);
                }
                else if (CmB.SelectedItem.ToString() == "Sell")
                {
                    BuySellButton.Content = "Sell";
                    ListBox.ItemsSource = Chara.WeponInventoy.OrderByDescending(c => c.Rarity); ;
                }
            }
            else if (WhatInfo == "Armor")
            {
                if (CmB.SelectedItem.ToString() == "Buy")
                {
                    BuySellButton.Content = "Buy";
                    ListBox.ItemsSource = StoreArmorLists.OrderByDescending(c => c.Rarity);
                }
                else if (CmB.SelectedItem.ToString() == "Sell")
                {
                    BuySellButton.Content = "Sell";
                    ListBox.ItemsSource = Chara.ArmorInventoy.OrderByDescending(c => c.Rarity); ;
                }
            }
        }
    }
}
