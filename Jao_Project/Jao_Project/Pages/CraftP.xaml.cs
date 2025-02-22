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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jao_Project.Classes;
using Wpf.Ui.Controls;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for CraftP.xaml
    /// </summary>
    public partial class CraftP : Page
    {
        public Character Chara { get; set; }

        public int Herb;
        public int Life;
        public int Mana;

        public CraftP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
        }

        private void CraftP_OnLoaded(object sender, RoutedEventArgs e)
        {
            Iniciate();
            ItemCounter();
            CraftButton.IsEnabled = false;
        }

        void Iniciate()
        {

            var Item1 = new Items("Herbal Leaf", 4 ,2,"Item", "Can be used to craft healing potions... because its an herb :)..right?");
            var Item2 = new Items("Mana plant", 4, 1, "Item", "Can be used to craft mana potions... because it has mana.. do I really have to explain this.");
            var Item3 = new Items("Life stone", 4, 3, "Item", "Its the base on making potions.. they say its the life of the monsters that we kill.. neat.");

            CraftPotion.ItemsSource = Chara.PotionInventoy.ToList();
            ItemList.ItemsSource = Chara.ItemInventoy.ToList();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void CraftButton_Click(object sender, RoutedEventArgs e)
        {
            var Potion = (Potions)CraftPotion.SelectedItem;
            if (Potion.Name == "Health Potion")
            {
                var resultH = Chara.ItemInventoy.Where(c => c.Name.Contains("Herbal Leaf")).ToList();
                var H = resultH[0];
                H.Qantity -= 2;

                if (H.Qantity == 0 )
                {
                    Chara.ItemInventoy.Remove(H);
                }

            }
            else if (Potion.Name == "Mana Potion")
            {
                var resultM = Chara.ItemInventoy.Where(c => c.Name.Contains("Mana plant")).ToList();
                var M = resultM[0]; 
                M.Qantity -= 2;

                if (M.Qantity == 0)
                {
                    Chara.ItemInventoy.Remove(M);
                }
            }
            var resultL = Chara.ItemInventoy.Where(c => c.Name.Contains("Life stone")).ToList();
            var L = resultL[0];
            L.Qantity -= 1;

            if (L.Qantity == 0)
            {
                Chara.ItemInventoy.Remove(L);
            }

            Potion.Quantity += 1;
            ItemList.ItemsSource = Chara.ItemInventoy.ToList();
            ItemCounter();
            ButtonWorks();
        }

        private void CraftPotion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CraftPotion.SelectedItem == null) return;

            var Potion = (Potions)CraftPotion.SelectedItem;
            var info = new StringBuilder();
            info.AppendLine($"Name: {Potion.Name}  ");
            info.AppendLine($"Heath add: {Potion.Healthadd} ");
            info.AppendLine($"Manna add: {Potion.Manaadd} ");
            info.AppendLine($"Quantity in inventory: {Potion.Quantity}");

            if (Potion.Name == "Health Potion")
            {
                info.AppendLine("Materials needed to craft: ");
                info.AppendLine("2 - Herbal Leaf");
                info.AppendLine("1 - Life stone");

                ButtonWorks();
            }
            else if (Potion.Name == "Mana Potion")
            {
                info.AppendLine("Materials needed to craft: ");
                info.AppendLine("2 - Mana Plant");
                info.AppendLine("1 - Life stone");

                ButtonWorks();
            }

            Details.Text = info.ToString();
        }

        void ButtonWorks()
        {
            var Potion = (Potions)CraftPotion.SelectedItem;
            if (Potion.Name == "Health Potion")
            {
                if (Herb >= 2 && Life >= 1)
                {
                    CraftButton.IsEnabled = true;
                }
                else
                {
                    CraftButton.IsEnabled = false;
                }
            }
            else if (Potion.Name == "Mana Potion")
            {
                if (Mana >= 2 && Life >= 1)
                {
                    CraftButton.IsEnabled = true;
                }
                else
                {
                    CraftButton.IsEnabled = false;
                }
            }
        }

        void ItemCounter()
        {

            string herbal = "Herbal Leaf";
            string life = "Life stone";
            string mana = "Mana plant";

            var resultH = Chara.ItemInventoy.Where(c => c.Name.Contains(herbal)).ToList();
            if (resultH.Count == 0) { Herb = 0; }
            else { Items P = resultH[0]; Herb = P.Qantity; }

            var resultL = Chara.ItemInventoy.Where(c => c.Name.Contains(life)).ToList();
            if (resultL.Count == 0) { Life = 0; }
            else { Items P = resultL[0]; Life = P.Qantity; }

            var resultM = Chara.ItemInventoy.Where(c => c.Name.Contains(mana)).ToList();
            if (resultM.Count == 0) { Mana = 0; }
            else { Items P = resultM[0]; Mana = P.Qantity; }

        }


    }
}
