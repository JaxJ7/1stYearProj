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
    /// Interaction logic for HospitalP.xaml
    /// </summary>
    public partial class HospitalP : Page
    {
        public Character Chara { get; set; }
        public HospitalP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            iniciate();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
                if (this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
        }


        void iniciate()
        {
            var Info = new StringBuilder();
            Info.AppendLine($"Health: {Chara.Health} / {Chara.MaxHealth}");
            Info.AppendLine($"Mana: {Chara.Mana} / {Chara.MaxMana}");
            Info.AppendLine($"Gold: {Chara.Money}");

            CharaInfo.Text = Info.ToString();

            var InfoBan = new StringBuilder();
            InfoBan.AppendLine("Welcome to the Hospital");
            InfoBan.AppendLine("We can Heal you and add mana and.. ummm yhe thats about It");
            InfoBan.AppendLine("");
            double Price = (double)(Chara.MaxHealth - Chara.Health) + (Chara.MaxMana - Chara.Mana);
            double HealPrice = Price + (Price * 0.1);
            int intHealSell = (int)HealPrice;
            InfoBan.AppendLine($"\nCost for Healing and Mana Add:  {intHealSell}");
            InfoBan.AppendLine("(Prices may vary depending on your health and mana)");

            Details.Text = InfoBan.ToString();
        }

        private void HealButton_Click(object sender, RoutedEventArgs e)
        {
            double Price = (double)(Chara.MaxHealth - Chara.Health) + (Chara.MaxMana - Chara.Mana);
            double HealPrice = Price + (Price * 0.1);
            int intHealSell = (int)HealPrice;
            if (intHealSell < Chara.Money)
            {
                Chara.Money -= intHealSell;
                Chara.Health = Chara.MaxHealth;
                iniciate();
            }
            else
            {
                Details.Text = "Im Broke, I cant afford to even heal myself... \n Welp guess I'll die or maybe I can still fight and save gold? Idk";
            }

        }
    }
}
