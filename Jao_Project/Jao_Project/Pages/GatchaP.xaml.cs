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

namespace Jao_Project.Pages
{
    /// <summary>
    /// Interaction logic for GatchaP.xaml
    /// </summary>
    public partial class GatchaP : Page
    {
        public List<Wepons> Weponlist = new List<Wepons>();
        public List<Wepons> WeponlistPulled = new List<Wepons>();
        public List<Wepons> Weponlist3 = new List<Wepons>();
        public List<Wepons> Weponlist4 = new List<Wepons>();
        public List<Wepons> Weponlist5 = new List<Wepons>();

        public List<Armor> Armorlist = new List<Armor>();
        public List<Armor> ArmorlistPulled = new List<Armor>();
        public List<Armor> Armorlist3 = new List<Armor>();
        public List<Armor> Armorlist4 = new List<Armor>();
        public List<Armor> Armorlist5 = new List<Armor>();

        private string WhatBanner;
        public Character Chara { get; set; }
        public GatchaP(Character chara)
        {
            InitializeComponent();
            Chara = chara;
            this.DataContext = this;
            ButtonWorks();
        }



        private void GatchaP_OnLoaded(object sender, RoutedEventArgs e)
        {
            ArmorWeponList();
            Iniciate();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        void Iniciate()
        {
            var infoC = new StringBuilder();
            infoC.AppendLine($"Gems: {Chara.GatchaMoney}  ");
            infoC.AppendLine($"4 rarity pity: {Chara.Pity4Count} ");
            infoC.AppendLine($"5 rarity pity: {Chara.Pity5Count} ");

            Info_Chara.Text = infoC.ToString();

            var info = new StringBuilder();
            info.AppendLine($"pullx1 cost 100 gems ");
            info.AppendLine($"Guaranteed 4 rarity every x10");
            info.AppendLine($"Guaranteed 5 rarity every x100");

            Infothingy.Text = info.ToString();


        }

        void ArmorWeponList()
        {

            //Weapons3*
            var Weapon31 = new Wepons("Sword", 3, 5, 350, "Its sword nothing special about it", "Weapon");
            var Weapon32 = new Wepons("Broken Sword", 3, 4,  300, "Its really just a Broken sword.. how do I even use this", "Weapon");
            var Weapon33 = new Wepons("Basta Sword", 3, 8,  300, "Basta, Basta sword lagi daw ni siya whahaha", "Weapon");
            var Weapon34 = new Wepons("Wooden Sword", 3, 6,  350, "Well at least its an upgrade of the sword", "Weapon");

            Weponlist3.Add(Weapon31); Weponlist3.Add(Weapon32); Weponlist3.Add(Weapon33); Weponlist3.Add(Weapon34);
            //Weapons4*
            var Weapon41 = new Wepons("awqle5$#% Sword", 4, 17, 1050, "What? man the creator really just slammed thier keyboard.. wait whats a keyboard", "Weapon");
            var Weapon42 = new Wepons("red born sword", 4, 20,  1000, "Red born? what doses that even mean?", "Weapon");
            var Weapon43 = new Wepons("Starkes Schwert", 4, 20,  1300, "Umm... who named this? btw it means strong sword ", "Weapon");
            var Weapon44 = new Wepons("life reaper", 4, 21,  1550, "Umm.. nice sword I guess?", "Weapon");

            Weponlist4.Add(Weapon41); Weponlist4.Add(Weapon42); Weponlist4.Add(Weapon43); Weponlist4.Add(Weapon44);
            //Weapons5*
            var Weapon51 = new Wepons("Demon Lord Slayer", 5, 400,  5350, "This is it.. a sure win sword.. hell yhe.. leveling up?? what even is that", "Weapon");
            var Weapon52 = new Wepons("BROKEN Sword", 5, 350,  4300, "A BROKEN sword.. Its soo strong Its Broken... not broken that is broken.. its.. ahh you know what I mean", "Weapon");

            Weponlist5.Add(Weapon51); Weponlist5.Add(Weapon52);

            Weponlist.AddRange(Weponlist3); Weponlist.AddRange(Weponlist4); Weponlist.AddRange(Weponlist5);

            //Armor4*
            var Armor31 = new Armor("Armor?", 3, 5, 350, "Huh? why..why is there a question mark.. what is this then", "Armor");
            var Armor32 = new Armor("Wooden Armor", 3, 4, 300, "Yhe it protects me but Its really not that flexible", "Armor");
            var Armor33 = new Armor("Just armor", 3, 4, 350, "Its just an aromor.. what more do you want", "Armor");
            var Armor34 = new Armor("Fur armor", 3, 3, 700, "Yhe it cant really protect me much but its FANCY", "Armor");

            Armorlist3.Add(Armor31); Armorlist3.Add(Armor32); Armorlist3.Add(Armor33); Armorlist3.Add(Armor34);
            //Armor4*
            var Armor41 = new Armor("s^&;vlk2 Armor", 4, 15, 1350, "What? man the creator really just slammed thier keyboard.. wait whats a keyboard", "Armor");
            var Armor42 = new Armor("Black born Armor", 4, 11, 1300, "Black born ? what doses that even mean ? ", "Armor");
            var Armor43 = new Armor("Starke Rüstung", 4, 15, 1950, "Umm... who named this? btw it means strong armor ", "Armor");
            var Armor44 = new Armor("Furry armor", 4, 25, 1500, "Umm nope.. pls don't let me wear this even if it has good def pls i beg you", "Armor");

            Armorlist4.Add(Armor41); Armorlist4.Add(Armor42); Armorlist4.Add(Armor43); Armorlist4.Add(Armor44);
            //Armor5*
            var Armor51 = new Armor("Dragon Scale armor", 5, 250, 5500, "Its made with the scales of a dragon that is said to withstand blows of gods.. but.. how did that like.. Mold it? ", "Armor");
            var Armor52 = new Armor("BROKEN Armor", 5, 200, 4500, "A BROKEN armor.. Its soo strong Its Broken... not broken that is broken.. its.. ahh you know what I mean", "Armor");

            Armorlist5.Add(Armor51); Armorlist5.Add(Armor52);

            Armorlist.AddRange(Armorlist3); Armorlist.AddRange(Armorlist4); Armorlist.AddRange(Armorlist5);

            WhatBanner = "Armor";
            PossibleList.ItemsSource = Armorlist.OrderByDescending(c => c.Rarity);
        }


        void Gatcha()
        {

                if (Chara.Pity5Count == 99)
                {
                    Chara.Pity5Count = 0;
                    FiveStarRandomizer();
                }
                else if (Chara.Pity4Count == 9)
                {
                    Chara.Pity4Count = 0;
                    Chara.Pity5Count += 1;
                    FourStarRandomizer();
                }
                else
                {
                    Random rnd = new Random();
                    int chance = rnd.Next(0, 200);

                    if (chance <= 178)
                    {
                        Chara.Pity4Count += 1;
                        Chara.Pity5Count += 1;
                        ThreeStarRandomizer();
                    }
                    else if (chance <= 198)
                    {
                        Chara.Pity4Count = 0;
                        Chara.Pity5Count += 1;
                        FourStarRandomizer();
                    }
                    else if (chance == 200 || chance == 199)
                    {
                        Chara.Pity4Count += 1;
                        Chara.Pity5Count = 0;
                       FiveStarRandomizer();
                    }
                }
        }
        

        void ThreeStarRandomizer()
        {
            int ChossenW;
            int ChossenA;

            Random r = new Random();

            if (WhatBanner == "Armor")
            {

                ChossenA = r.Next(0, Armorlist3.Count);

                ArmorlistPulled.Add(Armorlist3[ChossenA]);
            }
            else if (WhatBanner == "Weapon")
            {

                ChossenW = r.Next(0, Weponlist3.Count);

                WeponlistPulled.Add(Weponlist3[ChossenW]);
            }

        }

        void FourStarRandomizer()
        {
            int ChossenW;
            int ChossenA;

            Random r = new Random();

            if (WhatBanner == "Armor")
            {

                ChossenA = r.Next(0, Armorlist4.Count);

                ArmorlistPulled.Add(Armorlist4[ChossenA]);
            }
            else if (WhatBanner == "Weapon")
            {

                ChossenW = r.Next(0, Weponlist4.Count);

                WeponlistPulled.Add(Weponlist4[ChossenW]);
            }
        }

        void FiveStarRandomizer()
        {
            int ChossenW;
            int ChossenA;

            Random r = new Random();

            if (WhatBanner == "Armor")
            {

                ChossenA = r.Next(0, Armorlist5.Count);

                ArmorlistPulled.Add(Armorlist5[ChossenA]);
            }
            else if (WhatBanner == "Weapon")
            {

                ChossenW = r.Next(0, Weponlist5.Count);

                WeponlistPulled.Add(Weponlist5[ChossenW]);
            }
        }

        private void Pullx1_Click(object sender, RoutedEventArgs e)
        {
            GatchaList.ItemsSource = null;
            ArmorlistPulled.Clear();
            WeponlistPulled.Clear();
            Chara.GatchaMoney -= 100;

            Gatcha();

            if (WhatBanner == "Armor")
            {
                GatchaList.ItemsSource = ArmorlistPulled;
                foreach (var armor in ArmorlistPulled) Chara.ArmorInventoy.Add(armor);
            }
            else if (WhatBanner == "Weapon")
            {
                GatchaList.ItemsSource = WeponlistPulled;
                foreach (var wepons in WeponlistPulled) Chara.WeponInventoy.Add(wepons);
            }
            Iniciate();
            ButtonWorks();
        }

        private void Pullx10_Click(object sender, RoutedEventArgs e)
        {
            GatchaList.ItemsSource = null;
            ArmorlistPulled.Clear();
            WeponlistPulled.Clear();
            Chara.GatchaMoney -= 1000;

            for (int i = 1; i <= 10; i++)
            {
                Gatcha();
            }

            if (WhatBanner == "Armor")
            {
                GatchaList.ItemsSource = ArmorlistPulled.OrderByDescending(c => c.Rarity);
                foreach (var armor in ArmorlistPulled) Chara.ArmorInventoy.Add(armor);
            }
            else if (WhatBanner == "Weapon")
            {
                GatchaList.ItemsSource = WeponlistPulled.OrderByDescending(c => c.Rarity);
                foreach (var wepons in WeponlistPulled) Chara.WeponInventoy.Add(wepons);
            }
            Iniciate();
            ButtonWorks();

        }

        void ButtonWorks()
        {
            if (Chara.GatchaMoney >= 100)
            {
                Pullx1.IsEnabled = true;
            }
            else if (Chara.GatchaMoney < 100)
            {
                Pullx1.IsEnabled = false;
            }

            if (Chara.GatchaMoney >= 1000)
            {
                Pullx10.IsEnabled = true;
            }
            else if (Chara.GatchaMoney < 1000)
            {
                Pullx10.IsEnabled = false;
            }
        }

        private void ArmorButton_Click(object sender, RoutedEventArgs e)
        {
            GatchaList.ItemsSource = null;
            WhatBanner = "Armor";
            Banner.Text = "Armor Banner";

            PossibleList.ItemsSource = Armorlist.OrderByDescending(c => c.Rarity);
        }

        private void WeopenButton_Click(object sender, RoutedEventArgs e)
        {
            GatchaList.ItemsSource = null;
            WhatBanner = "Weapon";
            Banner.Text = "Weapon Banner";

            PossibleList.ItemsSource = Weponlist.OrderByDescending(c => c.Rarity);
        }


        // <Image x:Name="BannerImage" Grid.Column="1"></Image>
        //BannerImage.Source = new BitmapImage(new Uri("/pics/Working-With-Hexels-for-Drawing-Tiled-Pixel-Art.jpg", UriKind.Relative));

    }
}
