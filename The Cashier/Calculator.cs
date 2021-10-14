using System;
using System.Collections.Generic;
using System.Text;

namespace TheCashier
{
    class Calculator
    {
        private List<Item> listItem;
        private double total = 0;

        public Calculator()
        {
            this.listItem = new List<Item>();
        }
        public void addItem(Item item)
        {
            this.listItem.Add(item);
            this.total += item.getSubTotal();
        }
        public double getTotal()
        {
            return total;
        }

        public List<Item> getListItem()
        {
            return listItem;
        }
    }
}
