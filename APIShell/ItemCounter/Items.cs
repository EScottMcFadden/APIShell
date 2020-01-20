using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIShell.ItemCounter
{
    public static class ItemsCounter
    {
        public static List<ItemModel> Items { get; set; } = new List<ItemModel>();

        public static void Increment(string Name, string API)
        {
            if (!Items.Exists(a => a.Name.Equals(Name) && a.API.Equals(API)))
                Items.Add(new ItemModel(Name, API));

            Items.Where(a => a.Name.Equals(Name) && a.API.Equals(API)).First().Increment();
        }

        public static ItemModel Get(string Name, string API)
        {
            return  Items.Where(a => a.Name.Equals(Name) && a.API.Equals(API)).First();
        }

        public static string ItemToString(string Name, string API)
        {
            return Items.Where(a => a.Name.Equals(Name) && a.API.Equals(API)).First().ToString();
        }

        public static string ListAllItems()
        {
            StringBuilder s = new StringBuilder();
            foreach (ItemModel m in Items.OrderBy(a => a.API).ThenBy(a => a.Name))
            {
                s.AppendLine(m.ToString());
            }
            return s.ToString();

        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class SetItemCounterAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string API { get; set; }
        public SetItemCounterAttribute(string Name, string API)
        {
            this.Name = Name;
            this.API = API;
            IncrementCounter();

        }
        public SetItemCounterAttribute()
        {
            IncrementCounter();
        }
        private void IncrementCounter()
        {
            ItemsCounter.Increment(this.Name, this.API);
        }
    }
}
