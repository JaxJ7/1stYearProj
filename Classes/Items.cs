using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jao_Project.Classes
{

    public interface IWearable
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
    }
    public class Items : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _qantity;
        public string Name { get; set; }
        public int Rarity { get; set; }
        public int Qantity
        {
            get => _qantity;
            set { _qantity = value; OnPropertyChanged("Qantity"); }
        }
        public string WhatInfo { get; set; }
        public string Discription { get; set; }

        public Items(string name, int rarity, int qantity, string whatInfo, string discription)
        {
            Name = name;
            Rarity = rarity;
            Qantity = qantity;
            WhatInfo = whatInfo;
            Discription = discription;
        }
    }
    public class Armor : IWearable
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public int DefAdd { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string WhatInfo { get; set; }

        public Armor(string name, int rarity, int defAdd, int price, string discription, string whatInfo)
        {
            Name = name;
            Rarity = rarity;
            DefAdd = defAdd;
            Price = price;
            Discription = discription;
            WhatInfo = whatInfo;
        }
    }
    public class Wepons : IWearable
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public int AtkAdd { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string WhatInfo { get; set; }
        public Wepons(string name, int rarity, int atkAdd, int price , string discription, string whatInfo)
        {
            Name = name;
            Rarity = rarity;
            AtkAdd = atkAdd;
            Price = price;
            Discription = discription;
            WhatInfo = whatInfo;
        }
    }
    public class Potions: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _qantity;
        public string Name { get; set; }
        public int Healthadd { get; set; }
        public int Manaadd { get; set; }
        public int Quantity
        {
            get => _qantity;
            set { _qantity = value; OnPropertyChanged("Quantity"); }
        }

        public string WhatInfo { get; set; }

        public Potions(string name, int healthadd, int manaadd, int quantity , string whatInfo)
        {
            Name = name;
            Healthadd = healthadd;
            Manaadd = manaadd;
            Quantity = quantity;
            WhatInfo = whatInfo;
        }
    }
}
