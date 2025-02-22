using Jao_Project.Classes;
using Jao_Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using Wpf.Ui.Controls;

namespace Jao_Project
{
    /// <summary>
    /// Interaction logic for DemonLordP.xaml
    /// </summary>
    public partial class DemonLordP : Page
    {
        private System.Media.SoundPlayer music = new SoundPlayer("Music/TheFinalBattle.wav");
        public Character Chara { get; set; }
        public Monsters Monster { get; set; }
        public string Levelup;
        private List<Monsters> Monsters = new List<Monsters>();
        public string WhatAtk;
        private int MDamage;
        private int CDamage;

        public DemonLordP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            MonsterRandomizer();
            iniciate();
            DisableButtons();
            ButtonWorks();
        }
        private void DemonLordP_OnLoaded(object sender, RoutedEventArgs e)
        {
            music.Play();
        }



        void BattleInfo()
        {
            var BatInfo = new StringBuilder();
            BatInfo.AppendLine($"{Chara.Name} deals {CDamage}dmg to {Monster.Spices} ");
            BatInfo.AppendLine($"{Monster.Spices} deals {MDamage}dmg to {Chara.Name}");



            if (Monster.MinHealth == 0)
            {
                BatInfo.AppendLine($"Congratulations you defeated {Monster.Spices}");
                BatInfo.AppendLine("Rewards are:");
                BatInfo.AppendLine($"Money: {Monster.MoneyDrop}");
                BatInfo.AppendLine($"Gems: {Monster.GachaMoneyDrop}");
                BatInfo.AppendLine($"Press Continue...");
                if (Levelup == "Yes")
                {
                    BatInfo.AppendLine("Ooh neat I Leveled Up");
                }

            }
            string Infos = BatInfo.ToString();
            Info.Text = Infos;

        }

        void DisableButtons()
        {


            if (Monster.MinHealth == 0)
            {
                NormalAttackButton.IsEnabled = false;
                Skill1.IsEnabled = false;
                Skill2.IsEnabled = false;
                Skill3.IsEnabled = false;
            }
            else
            {
                if (Chara.Level >= 3 && Chara.Mana >= 40) Skill1.IsEnabled = true;
                else
                {
                    Skill1.IsEnabled = false;
                    if (Chara.Level < 3)
                    {
                        Skill1.Content = "Unlock at lvl 3";
                    }
                }
                if (Chara.Level >= 5 && Chara.Mana >= 80) Skill2.IsEnabled = true;
                else
                {
                    Skill2.IsEnabled = false;
                    if (Chara.Level < 5)
                    {
                        Skill2.Content = "Unlock at lvl 5";
                    }
                }
                if (Chara.Level >= 10 && Chara.Mana >= 200) Skill3.IsEnabled = true;
                else
                {
                    Skill3.IsEnabled = false;
                    if (Chara.Level < 5)
                    {
                        Skill3.Content = "Unlock at lvl 10";
                    }
                }
            }
        }


        void iniciate()
        {
            var info = new StringBuilder();
            info.AppendLine($"Name: {Chara.Name} ");
            info.AppendLine($"Character Level: {Chara.Level}");
            info.AppendLine($"Health: {Chara.Health} / {Chara.MaxHealth}");
            info.AppendLine($"Mana: {Chara.Mana} / {Chara.MaxMana}");
            info.AppendLine($"Expirence: {Chara.Expirence} / {Chara.MaxExpirence}");
            info.AppendLine($"");

            string InfoGet = info.ToString();
            CharacterInfo.Text = InfoGet;

            var infoM = new StringBuilder();
            infoM.AppendLine($"Enemy: {Monster.Spices} \n Health: {Monster.MinHealth} / {Monster.MaxHealth}");

            string InfoMGet = infoM.ToString();
            EnemyInfo.Text = InfoMGet;
            PotionBox.ItemsSource = Chara.PotionInventoy;
        }

        void MonsterRandomizer()
        {
            var monster1 = new Monsters("Jaxie Jao(The Creator)", 100, 500, 5000, 5000, 10000, 5000, 7000);

            Monster = monster1;
        }

        void Attacks()
        {
            Random r = new Random();
            CDamage = r.Next(Chara.MinAttack, Chara.MaxAttack);
            MDamage = r.Next(Monster.MinAttack, Monster.MaxAttack);
            CDamage += Chara.Wepon.AtkAdd;
            MDamage -= Chara.Defense + Chara.Armor.DefAdd;

            if (MDamage <= 0)
            {
                MDamage = 0;
            }

            if (WhatAtk == "Skill1")
            {
                CDamage += 20;
            }
            if (WhatAtk == "Skill3")
            {
                CDamage += 100;
            }

            Monster.MinHealth -= CDamage;
            Chara.Health -= MDamage;

            if (Monster.MinHealth <= 0)
            {
                GameOver end = new GameOver("You Won!! Yay \n that all");

                    this.NavigationService.Navigate(end);
            }
            if (Chara.Health <= 0)
            {
                GameOver end = new GameOver("Game Over...");

                this.NavigationService.Navigate(end);
            }

            if (Chara.Expirence >= Chara.MaxExpirence)
            {
                LevelUp();
            }
        }


        void ButtonWorks()
        {
            var Potion = (Potions)PotionBox.SelectedItem;
            UseButton.IsEnabled = false;
            if (Potion == null) return;
            if (Potion.Quantity > 0)
            {
                UseButton.IsEnabled = true;
            }
            else
            {
                UseButton.IsEnabled = false;
            }
        }
        void LevelUp()
        {
            Levelup = "Yes";
            Chara.Level += 1;
            Chara.MaxHealth += 60;
            Chara.Health = Chara.MaxHealth;
            Chara.MinAttack += 3;
            Chara.MaxAttack += 5;
            Chara.MaxMana += 30;
            Chara.Mana = Chara.MaxMana;
            Chara.Expirence -= Chara.MaxExpirence;
            Chara.MaxExpirence += 350;
        }

        private void NormalAttackButton_OnClick(object sender, RoutedEventArgs e)
        {
            WhatAtk = "NormalAtk";
            Attacks();
            BattleInfo();
            iniciate();
            DisableButtons();
        }

        private void Skill1_OnClick(object sender, RoutedEventArgs e)
        {
            WhatAtk = "Skill1";
            Chara.Mana -= 40;
            Attacks();
            BattleInfo();
            iniciate();
            DisableButtons();
        }

        private void Skill2_OnClick(object sender, RoutedEventArgs e)
        {
            Chara.Mana -= 80;
            double DubleHeath = (double)Chara.MaxHealth;
            double HealthAdd = (DubleHeath * 0.3);
            int intHealthAdd = (int)HealthAdd;
            Chara.Health += intHealthAdd;


            var info = new StringBuilder();
            info.AppendLine($"{Chara.Name} is healed by {intHealthAdd}");

            iniciate();
            DisableButtons();

        }

        private void Skill3_OnClick(object sender, RoutedEventArgs e)
        {
            WhatAtk = "Skill3";
            Chara.Mana -= 200;
            Attacks();
            BattleInfo();
            iniciate();
            DisableButtons();
        }

        private void PotionBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonWorks();
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            var Potion = (Potions)PotionBox.SelectedItem;
            if (Potion.Name == "Health Potion")
            {
                Chara.Health += Potion.Healthadd;
                if (Chara.Health > Chara.MaxHealth)
                {
                    Chara.Health = Chara.MaxHealth;
                }
            }
            else if (Potion.Name == "Mana Potion")
            {
                Chara.Mana += Potion.Manaadd;
                if (Chara.Mana > Chara.MaxMana)
                {
                    Chara.Mana = Chara.MaxMana;
                }
            }
            ButtonWorks();
        }


    }
}
