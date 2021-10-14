# TheCashier
Aplikasi ini berfungsi untuk check out dalam berbelanja
## Fungsi
1. Melakukan Check Out Belanjaan
2. Melakukan Sub Total Belanjaan dll
# File Explain
## Calculator.cs
```csharp
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
```
Berfungsi sebagai code untuk mengkalkulasi Item item yang di Input User
## Item.cs
```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace TheCashier
{
    class Item
    {
        private int id;
        public string title { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double subtotal { get; set; }
        private string type;

        public Item(int id, string title, int quantity, string type, double price)
        {
            this.id = id;
            this.title = title;
            this.quantity = quantity;
            this.type = type;
            this.price = price;
            this.subtotal = 0;
        }
        public string getTitle()
        {
            return title;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public string getType()
        {
            return type;
        }
        public double getPrice()
        {
            return price;
        }
        public double getSubTotal()
        {
            subtotal = price * quantity;
            return subtotal;
        }
    }
}
```
Berfungsi untuk mengidentifikasi Item yang di inputkan User
## MainWindow.xaml
```csharp
<Window x:Name="The_Cashier" x:Class="TheCashier.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"

        Title="MainWindow" Height="710" Width="470">
    <Grid Margin="0,0,2,-3">
        <ListBox x:Name="listBox" HorizontalAlignment="Left" Height="217" Margin="58,328,0,0" VerticalAlignment="Top" Width="344">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="0,2">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="100" />
                            <ColumnDefinition Width="75" />
                            <ColumnDefinition Width="75" />
                            <ColumnDefinition Width="75" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Text="{Binding title}" TextAlignment="Left" />
                        <TextBlock Grid.Column="1" Text="{Binding quantity}"  TextAlignment="Right"  />
                        <TextBlock Grid.Column="2" Text="{Binding price}"  TextAlignment="Right" />
                        <TextBlock Grid.Column="3" Text="{Binding subtotal}" TextAlignment="Right" />
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>  
```
Berfungsi untuk mengatur Layout Aplikasi
## MainWindow.xaml.cs
```csharp
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

namespace TheCashier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            listBox.ItemsSource = calculator.getListItem();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = itemNameBox.Text;
            int quantity = int.Parse(quantityBox.Text);
            string type = typeBox.Text;
            double price = double.Parse(priceBox.Text);

            Item item = new Item(new Random().Next(), title, quantity, type, price);
            calculator.addItem(item);
            double total = calculator.getTotal();

            totalLabel.Content = string.Format("Rp. {0}", total);

            listBox.Items.Refresh();
        }

    }
}
```
Berfungsi untuk menggabungkan UI dan Code
