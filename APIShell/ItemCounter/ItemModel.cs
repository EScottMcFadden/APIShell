using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.ItemCounter
{
    public class ItemModel
    {
        public ItemModel(string name, string aPI)
        {
            Name = name;
            API = aPI;
            Counter = 0;

        }

        public string Name { get; set;  }
        public string API { get; set; }
        public int Counter { get; set; }
        public DateTime LastCall { get; set; }
        public DateTime? FirstCall { get; set; } = null;

        public void Increment ()
        {
            Counter++;
            LastCall = DateTime.UtcNow;
            if (FirstCall == null)
                FirstCall = LastCall;
        }

        public override string ToString()
        {
            return $"API: {API} Name: {Name}  Count: {Counter}  FirstCall: {FirstCall}   LastCall: {LastCall}";
        }
    }
}
