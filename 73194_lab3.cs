namespace lab3
{
    public abstract class Item
    {
        private string name;
        private decimal value;
        private double weight;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Item(string name, decimal value, double weight)
        {
            this.name = name;
            this.value = value;
            this.weight = weight;
        }

        public virtual string Describe()
        {
            return $"Przedmiot: {name}, Wartość: {value} złota, Waga: {weight} kg";
        }

        public virtual decimal GetValue()
        {
            return value;
        }
    }
    public abstract class Weapon : Item
    {
        private int damage;

        public int Damage
        {
            get { return damage; }
        }

        public Weapon(string name, decimal value, double weight, int damage) : base(name, value, weight)
        {
            this.damage = damage;
        }

        public override decimal GetValue()
        {
            return Value * 1.2m;
        }
    }
    public class Sword : Weapon
    {
        public Sword(string name, decimal value, double weight, int damage) : base(name, value, weight, damage)
        {
        }

        public override string Describe()
        {
            return base.Describe() + $", Obrażenia: {Damage}, Typ broni: Miecz";
        }
    }

    public class Axe : Weapon
    {
        public Axe(string name, decimal value, double weight, int damage) : base(name, value, weight, damage)
        {
        }

        public override string Describe()
        {
            return base.Describe() + $", Obrażenia: {Damage}, Typ broni: Topór";
        }
    }
    public class Consumable : Item
    {
        private int useCount;

        public int UseCount
        {
            get { return useCount; }
        }

        public Consumable(string name, decimal value, double weight, int useCount) : base(name, value, weight)
        {
            this.useCount = useCount;
        }

        public override string Describe()
        {
            return base.Describe() + $", Liczba użyć: {useCount}";
        }
    }
    public class Potion : Consumable
    {
        private int duration;

        public int Duration
        {
            get { return duration; }
        }

        public Potion(string name, decimal value, double weight, int useCount, int duration)
            : base(name, value, weight, useCount)
        {
            this.duration = duration;
        }

        public override string Describe()
        {
            return base.Describe() + $", Czas trwania: {duration} s";
        }
    }
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public int Quantity
        {
            get { return items.Count; }
        }

        public Item ItemAt(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                return items[index];
            }
            return null;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
            }
        }

        public void ListAll()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.Describe());
            }
        }

        public void ListWeapons()
        {
            foreach (Item item in items)
            {
                if (item is Weapon)
                {
                    Console.WriteLine(item.Describe());
                }
            }
        }

        public decimal GetTotalValue()
        {
            decimal total = 0;
            foreach (Item item in items)
            {
                total += item.GetValue();
            }
            return total;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Inventory ekwipunek = new Inventory();
            Sword miecz = new Sword("Długi miecz", 300.0m, 2.5, 40);
            Axe topor = new Axe("Topór bojowy", 450.0m, 4.2, 65);
            Consumable jedzenie = new Consumable("Chleb", 5.0m, 0.5, 1);
            Potion mikstura = new Potion("Mikstura lecznicza", 50.0m, 0.5, 3, 30);

            ekwipunek.AddItem(miecz);
            ekwipunek.AddItem(topor);
            ekwipunek.AddItem(jedzenie);
            ekwipunek.AddItem(mikstura);

            Console.WriteLine("Liczba przedmiotów w ekwipunku: " + ekwipunek.Quantity);
            Console.WriteLine();

            Console.WriteLine("--- Wszystkie przedmioty ---");
            ekwipunek.ListAll();
            Console.WriteLine();

            Console.WriteLine("--- Tylko bronie ---");
            ekwipunek.ListWeapons();
            Console.WriteLine();

            Console.WriteLine("Przedmiot na pozycji 0: " + ekwipunek.ItemAt(0).Name);
            Console.WriteLine("Łączna wartość ekwipunku: " + ekwipunek.GetTotalValue() + " złota");
            Console.WriteLine();

            ekwipunek.RemoveItem(2);
            Console.WriteLine("Po usunięciu przedmiotu o indeksie 2:");
            Console.WriteLine("Liczba przedmiotów: " + ekwipunek.Quantity);
            Console.WriteLine("Łączna wartość: " + ekwipunek.GetTotalValue() + " złota");

            Console.ReadKey();
        }
    }
}