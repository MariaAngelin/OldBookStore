using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();

        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            itemsListBox.DataSource = itemsBinding;

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListBox.DataSource = cartBinding;

            vendorsBinding.DataSource = store.Vendors;
            vendorListBox.DataSource = vendorsBinding;

            itemsListBox.DisplayMember = "Display";
            itemsListBox.ValueMember = "Display";

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";
        }


        public void SetupData()
        {

            store.Name = "DreamLand";

            store.Vendors.Add(new Vendor
            {
                FirstName = "John",
                LastName = "Boe",
                Commission = 0.5
            });

            store.Vendors.Add(new Vendor
            {
                FirstName = "Sue",
                LastName = "Driffin",
                Commission = 0.5
            });

            store.Items.Add(new Item
            {
                Title = " Harry Potter",
                Description = "The books about Hogwarts",
                Price = 4.80M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = " Lord of The Rings",
                Description = "The  books about Middle Earth",
                Price = 5.45M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = " Eragon",
                Description = "The books about Dragons",
                Price = 4.25M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = " Game of Thrones",
                Description = "The books about Death",
                Price = 3.85M,
                Owner = store.Vendors[0]
            });



        }







        private void label1_Click(object sender, EventArgs e)
        {
            foreach(Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                store.Profit += (1-(decimal)item.Owner.Commission) * item.Price;

            }

            storeProfitValue.Text = string.Format("${0}", store.Profit);
            shoppingCartData.Clear();
            cartBinding.ResetBindings(false);
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            itemsBinding.ResetBindings(false);

            vendorsBinding.ResetBindings(false);

        }

        private void itemsListBoxLabel_Click(object sender, EventArgs e)
        {

        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemsListBox.SelectedItem;
            shoppingCartData.Add(selectedItem);
            cartBinding.ResetBindings(false);

        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
