using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public DetailViewModel myviewmodel = new DetailViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = myviewmodel;
            myviewmodel.GenderValid = false;
            myviewmodel.NameValid = false;
            List<String> myList = new List<String>();
            myList.Add("Male");
            myList.Add("Female");
            List<String> mycurrency = new List<String>();
            mycurrency.Add("USD");
            mycurrency.Add("TSH");
            comboBox.ComboBoxSource = myList;
            currency.ComboBoxSource = mycurrency;
            currency.SelectedIndex = 1;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //string namevalue = namebox.Text;
            //Navigation.PushModalAsync(new NavigationPage(new Welcomepage(namebox.Text)));
        }

        private void comboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex > -1)
            {
                myviewmodel.GenderValid = true;
            }
            else
            {
                myviewmodel.GenderValid = false;
            }
        }

        private void currency_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {

        }
    }
}
