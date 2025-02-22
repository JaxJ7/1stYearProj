using Jao_Project.Classes;
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
using Wpf.Ui.Controls;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for InventoryP.xaml
    /// </summary>
    public partial class InventoryP : Page
    {
        public Character Chara { get; set; }
        public List<Armor> ArmorLists = new List<Armor>();
        public List<Wepons> WeponsLists = new List<Wepons>();
        public List<Items> ItemsLists = new List<Items>();
        public List<Potions> PotionsList = new List<Potions>();
        public string WhatList = "Weapons";

        public InventoryP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            Iniciate();
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        void Iniciate()
        {
            ArmorLists = Chara.ArmorInventoy.OrderByDescending(c => c.Rarity).ToList();
            WeponsLists = Chara.WeponInventoy.OrderByDescending(c => c.Rarity).ToList();
            ItemsLists = Chara.ItemInventoy.ToList();
            PotionsList = Chara.PotionInventoy.ToList();

            ListBox.ItemsSource = WeponsLists;
            PotionBox.ItemsSource = PotionsList;

        }

        private void WeoponLists_Click(object sender, RoutedEventArgs e)
        {
            WhatList = "Weapons";

            ListBox.ItemsSource = WeponsLists;
            EquipButton.IsEnabled = true;
        }

        private void Armorbotton_Click(object sender, RoutedEventArgs e)
        {
            WhatList = "Armor";

            ListBox.ItemsSource = ArmorLists;
            EquipButton.IsEnabled = true;
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            WhatList = "Item";

            ListBox.ItemsSource = ItemsLists;
            EquipButton.IsEnabled = false;
        }


        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem == null) return;

            if (WhatList == "Weapons")
            {
                Wepons p = (Wepons)ListBox.SelectedItem;
                var infoW = new StringBuilder();
                infoW.AppendLine($"Name: {p.Name}");
                infoW.AppendLine($"Rarity: {p.Rarity}");
                infoW.AppendLine($"Attack: {p.AtkAdd}");
                infoW.AppendLine($"Description : \n{p.Discription}");


                string InfowGet = infoW.ToString();
                Details.Text = InfowGet;
            }
            else if (WhatList == "Armor")
            {
                Armor p = (Armor)ListBox.SelectedItem;
                var infoA = new StringBuilder();
                infoA.AppendLine($"Name: {p.Name}");
                infoA.AppendLine($"Rarity: {p.Rarity}");
                infoA.AppendLine($"Defense: {p.DefAdd}");
                infoA.AppendLine($"Description : \n{p.Discription}");

                string InfoA = infoA.ToString();
                Details.Text = InfoA;
            }
            else if (WhatList == "Item")
            {
                Items p = (Items)ListBox.SelectedItem;
                var infoA = new StringBuilder();
                infoA.AppendLine($"Name: {p.Name}");
                infoA.AppendLine($"Rarity: {p.Rarity}");
                infoA.AppendLine($"Quantity: {p.Qantity}");
                infoA.AppendLine($"Description : \n{p.Discription}");


                string InfoA = infoA.ToString();
                Details.Text = InfoA;
            }
        }

        private void EquipButton_Click(object sender, RoutedEventArgs e)
        {
            if (WhatList == "Weapons")
            {
                Wepons p = (Wepons)ListBox.SelectedItem;
                if (p != Chara.Wepon)
                {
                    Chara.Wepon = p;
                    Details.Text = $"So I equipped {p.Name}... ok neat";
                }
                else if (p == Chara.Wepon)
                {
                    Details.Text = "I already equipped this thing man";
                }
            }
            else if (WhatList == "Armor")
            {
                Armor p = (Armor)ListBox.SelectedItem;
                if (p != Chara.Armor)
                {
                    Chara.Armor = p;
                    Details.Text = $"So I equipped {p.Name}... ok neat";
                }
                else if (p == Chara.Armor)
                {
                    Details.Text = "I already equipped this thing man";
                }
            }
        }
    }
}
