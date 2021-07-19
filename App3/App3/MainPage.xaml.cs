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
        public double progress = 0;
        public Color progresscolor = Color.White;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = myviewmodel;
            myviewmodel.GenderValid = false;
            myviewmodel.NameValid = false;
            myviewmodel.PriceZero = false;
            myviewmodel.NameEmpty = false;
            myviewmodel.EmailNotValid = true;
            myviewmodel.PhoneValid = false;
            myviewmodel.IdValid = false;

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

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            loading.PlayAnimation();
            submitbutton.Text = "please wait...";

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            myviewmodel.PasswordStrength = (int)DetailViewModel.CheckStrength(e.NewTextValue);
            progress = myviewmodel.PasswordStrength / 7.0;
            passwordbar.ProgressTo(progress, 900, Easing.Linear);
            passwordbar.ProgressColor = myviewmodel.ScoreToColor(myviewmodel.PasswordStrength);
            PasswordStrengthLabel.Text = myviewmodel.ScoreToMessage(myviewmodel.PasswordStrength);
        }

        private void price_ValueChanged(object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e)
        {
            if (myviewmodel.PriceZero)
            {
                pricelabel.IsVisible = true;
                pricecheck.IsVisible = false;
            }
            else
            {
                pricelabel.IsVisible = false;
                pricecheck.IsVisible = true;
            }
        }

        private void email_ValueChanged(object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e)
        {
            if(myviewmodel.EmailNotValid)
            {
                emaillabel.IsVisible = true;
                emailcheck.IsVisible = false;
            }
            else
            {
                emaillabel.IsVisible = false;
                emailcheck.IsVisible = true;
            }
        }
    }
}
