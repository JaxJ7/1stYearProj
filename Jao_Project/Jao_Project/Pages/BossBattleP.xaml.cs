using Jao_Project.Classes;
using Jao_Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for BossBattleP.xaml
    /// </summary>
    public partial class BossBattleP : Page
    {
        private System.Media.SoundPlayer Bmusic = new SoundPlayer("Music/Ruins.wav");
        private System.Media.SoundPlayer music = new SoundPlayer("Music/DestroytheMechas.wav");

        public Character Chara { get; set; }
        public Monsters Monster { get; set; }
        public Items Drop { get; set; }
        public string Levelup;
        private List<Monsters> Monsters = new List<Monsters>();
        private List<Items> items = new List<Items>();
        public string WhatAtk;
        private int MDamage;
        private int CDamage;
        public BossBattleP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            music.PlayLooping();
            MonsterRandomizer();
            ItemDrops();
            iniciate();
            DisableButtons();
            ButtonWorks();
        }


        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            Bmusic.PlayLooping();
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
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
                BatInfo.AppendLine($"Items Droped: {Drop.Name} x {Drop.Qantity}");
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
                BackB.Content = "Continue";
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
            infoM.AppendLine($"Enemy: {Monster.Spices}  \n Health: {Monster.MinHealth} / {Monster.MaxHealth}");

            string InfoMGet = infoM.ToString();
            EnemyInfo.Text = InfoMGet;
            PotionBox.ItemsSource = Chara.PotionInventoy;
        }

        void MonsterRandomizer()
        {
            int ChossenM;
            var monster1 = new Monsters("Green Dragon", 40, 80, 650, 650, 1000, 150, 500);
            Monsters.Add(monster1);
            if (Chara.Level >= 8)
            {
                var monster2 = new Monsters("Red Dragon", 40, 100, 1000, 1000, 1500, 200, 800);
                Monsters.Add(monster2);
            }
            if (Chara.Level >= 10)
            {
                var monster3 = new Monsters("Black Dragon", 50, 200, 1500, 1500, 2000, 300, 1000);
                Monsters.Add(monster3);
            }
            
            Random r = new Random();
            ChossenM = r.Next(0, Monsters.Count);

            Monster = Monsters[ChossenM];
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
                Monster.MinHealth = 0;
                Chara.Money += Monster.MoneyDrop;
                Chara.GatchaMoney += Monster.GachaMoneyDrop;
                Chara.Expirence += Monster.ExpDrop;

                var resultM = Chara.ItemInventoy.Where(c => c.Name.Contains(Drop.Name)).ToList();
                if (resultM.Count == 0)
                {
                    Chara.ItemInventoy.Add(Drop);
                }
                else
                {
                    var M = resultM[0];
                    M.Qantity += Drop.Qantity;
                }
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

        void ItemDrops()
        {
            var Item1 = new Items("Herbal Leaf", 4, 3, "Item", "Can be used to craft healing potions... because its an herb :)..right?");
            var Item2 = new Items("Mana plant", 4, 3, "Item", "Can be used to craft mana potions... because it has mana.. do I really have to explain this.");
            var Item3 = new Items("Life stone", 4, 2, "Item", "Its the base on making potions.. they say its the life of the monsters that we kill.. neat.");

            int ChossenI;

            items.Add(Item1); items.Add(Item2); items.Add(Item3);
            int Quantityadd;

            Random r = new Random();
            Random Q = new Random();

            Quantityadd = Q.Next(1, 8);
            ChossenI = r.Next(0, items.Count);
            Drop = items[ChossenI];
            if (Quantityadd == 8)
            {
                Drop.Qantity += 2;
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
