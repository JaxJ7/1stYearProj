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

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for CharacterInfoP.xaml
    /// </summary>
    public partial class CharacterInfoP : Page
    {
        public Character Chara { get; set; }
        public CharacterInfoP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;            
            iniciate();
        }


        public string st { get; set;}
        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryP Inventory = new InventoryP(Chara);
            this.NavigationService.Navigate(Inventory);
        }

        private void Backtomain_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        void iniciate()
        {
            var info = new StringBuilder();
            info.AppendLine($"Name: {Chara.Name} ");
            info.AppendLine($"Character Level: {Chara.Level}");
            info.AppendLine($"Health: {Chara.Health} / {Chara.MaxHealth}");
            info.AppendLine($"Mana: {Chara.Mana} / {Chara.MaxMana}");
            info.AppendLine($"Attack: {Chara.MinAttack}-{Chara.MaxAttack}  + {Chara.Wepon.AtkAdd}");
            info.AppendLine($"Deference: {Chara.Defense} + {Chara.Armor.DefAdd}");
            info.AppendLine($"Experience: {Chara.Expirence} / {Chara.MaxExpirence}");
            info.AppendLine($"");
            info.AppendLine($"Gold: {Chara.Money}");
            info.AppendLine($"Gem: {Chara.GatchaMoney}");

            string InfoGet = info.ToString();
            CharacterStats.Text = InfoGet;

            var infoW = new StringBuilder();
            infoW.AppendLine($"Weapon Equipped: ");
            infoW.AppendLine($"Name: {Chara.Wepon.Name}");
            infoW.AppendLine($"Rarity: {Chara.Wepon.Rarity}");
            infoW.AppendLine($"Attack: {Chara.Wepon.AtkAdd}");
            infoW.AppendLine($"Description : \n{Chara.Wepon.Discription}");

            string InfowGet = infoW.ToString();
            WeponInfo.Text = InfowGet;

            var infoA = new StringBuilder();
            infoA.AppendLine($"Armor Equipped: ");
            infoA.AppendLine($"Name: {Chara.Armor.Name}");
            infoA.AppendLine($"Rarity: {Chara.Armor.Rarity}");
            infoA.AppendLine($"Defense: {Chara.Armor.DefAdd}");
            infoA.AppendLine($"Description : \n{Chara.Armor.Discription}");

            string InfoA = infoA.ToString();
            ArmorInfo.Text = InfoA;


            var Skillinfo = new StringBuilder();
            Skillinfo.AppendLine("---------------------------------------");
            Skillinfo.AppendLine("Skill: Normal Attack");
            Skillinfo.AppendLine($"Mana usage: 0  Dmg: {Chara.MinAttack}-{Chara.MaxAttack}  + {Chara.Wepon.AtkAdd} ");
            Skillinfo.AppendLine("---------------------------------------");
            if (Chara.Level >= 3)
            {
                Skillinfo.AppendLine("---------------------------------------");
                Skillinfo.AppendLine("Skill: Normal Attack");
                Skillinfo.AppendLine($"Mana usage: 40  Dmg:{Chara.MinAttack}-{Chara.MaxAttack}  + {Chara.Wepon.AtkAdd}+20");
                Skillinfo.AppendLine("---------------------------------------");
            }

            if (Chara.Level >= 4)
            {
                Skillinfo.AppendLine("---------------------------------------");
                Skillinfo.AppendLine("Skill: Normal Attack");
                Skillinfo.AppendLine($"Mana usage: 80  Heals 30% of Health");
                Skillinfo.AppendLine("---------------------------------------");
            }

            if (Chara.Level >= 5)
            {
                Skillinfo.AppendLine("---------------------------------------");
                Skillinfo.AppendLine("Skill: Normal Attack");
                Skillinfo.AppendLine($"Mana usage: 200  Dmg: {Chara.MinAttack}-{Chara.MaxAttack}  + {Chara.Wepon.AtkAdd}+100");
                Skillinfo.AppendLine("---------------------------------------");
            }
            string infoS = Skillinfo.ToString();
            skill_info.Text = infoS;

        }

        private void CharacterInfoP_OnLoaded(object sender, RoutedEventArgs e)
        {
            iniciate();
        }
    }
}
