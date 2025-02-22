using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jao_Project.Classes
{
    public class Character : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        private float _money;
        private int _gatchaMoney;
        private int _pity4Count;
        private int _pity5Count;
        private int _health;
        private int _mana;
        private int _maxHealth;
        private int _maxMana;
        private int _level;
        private int _expirence;
        private int _maxExpirence;
        private Wepons _wepon;
        private Armor _armor;
        private int _defense;
        private int _minAttack;
        private int _maxAttack;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public float Money
        {
            get => _money;
            set { _money = value; OnPropertyChanged("Money"); }
        }
        public int GatchaMoney
        {
            get => _gatchaMoney;
            set { _gatchaMoney = value; OnPropertyChanged("GatchaMoney"); }
        }
        public int Pity4Count
        {
            get => _pity4Count;
            set { _pity4Count = value; OnPropertyChanged("Pity4Count"); }
        }
        public int Pity5Count
        {
            get => _pity5Count;
            set { _pity5Count = value; OnPropertyChanged("Pity5Count"); }
        }


        public int Health
        {
            get => _health;
            set { _health = value; OnPropertyChanged("MinHealth"); }
        }
        public int Mana
        {
            get => _mana;
            set { _mana = value; OnPropertyChanged("Mana"); }
        }
        public int MaxHealth
        {
            get => _maxHealth;
            set { _maxHealth = value; OnPropertyChanged("MaxHealth"); }
        }
        public int MaxMana
        {
            get => _maxMana;
            set { _maxMana = value; OnPropertyChanged("MaxMana"); }
        }
        public int Level
        {
            get => _level;
            set { _level = value; OnPropertyChanged("Level"); }
        }
        public int Expirence
        {
            get => _expirence;
            set { _expirence = value; OnPropertyChanged("Expirence"); }
        }
        public int MaxExpirence
        {
            get => _maxExpirence;
            set { _maxExpirence = value; OnPropertyChanged("MaxExpirence "); }
        }
        public int MinAttack
        {
            get => _minAttack;
            set { _minAttack = value; OnPropertyChanged("MinAttack"); }
        }
        public int MaxAttack
        {
            get => _maxAttack;
            set { _maxAttack = value; OnPropertyChanged("MaxAttack"); }
        }
        public int Skill { get; set; }
        public int Defense
        {
            get => _defense;
            set { _defense = value; OnPropertyChanged("Defense"); }
        }


        public Armor Armor
        {
            get => _armor;
            set { _armor = value; OnPropertyChanged("Armor"); }
        }
        public Wepons Wepon
        {
            get => _wepon;
            set { _wepon = value; OnPropertyChanged("Wepon"); }
        }

        public ObservableCollection<Items> ItemInventoy { get; set;  } = new ObservableCollection<Items>();
        public ObservableCollection<Armor> ArmorInventoy { get; set; } = new ObservableCollection<Armor>();
        public ObservableCollection<Wepons> WeponInventoy { get; set; } = new ObservableCollection<Wepons>();
        public ObservableCollection<Potions> PotionInventoy { get; set; } = new ObservableCollection<Potions>();
        public Character(string name)
        {
            Name = name;
        }


    }

    
    public class Monsters
    {
        public string Spices { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int MinHealth { get; set; }
        public int MaxHealth { get; set; }
        public int MoneyDrop { get; set; }
        public int GachaMoneyDrop { get; set; }

        public int ExpDrop { get; set; }

        public Monsters(string spices, int minAttack, int maxAttack, int minHealth, int maxHealth, int moneyDrop, int gachaMoneyDrop, int expDrop)
        {
            Spices = spices;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
            MinHealth = minHealth;
            MaxHealth = maxHealth;
            MoneyDrop = moneyDrop;
            GachaMoneyDrop = gachaMoneyDrop;
            ExpDrop = expDrop;
        }
    }
}
