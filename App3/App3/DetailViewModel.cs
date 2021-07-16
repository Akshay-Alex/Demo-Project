using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App3
{
    public class DetailViewModel : TriggerAction<ImageButton>,INotifyPropertyChanged
    {
        private bool nameValid = false;
        public string testdata = "testdata";
        private bool genderValid = false;
        private bool priceZero = false;
        private bool nameEmpty = false;
        bool _hidePassword = true;
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    OnPropertyChanged();
                }
            }
            get => _hidePassword;
        }


        public bool GenderValid
        {
            get => genderValid;
            set
            {
                genderValid = value;
                OnPropertyChanged();
            }
        }
        public bool NameEmpty
        {
            get => nameEmpty;
            set
            {
                nameEmpty = value;
                OnPropertyChanged();
            }
        }
        public bool PriceZero
        { 
            get => priceZero;
            set
            {
                priceZero = value;
                OnPropertyChanged();
            }
        }
        public bool NameValid
        {
            get => nameValid;
            set
            {
                nameValid = value;
                OnPropertyChanged();
            }
        }
        public string Testdata
        {
            get { return testdata; }
            set { testdata = value; }
        }

    }
}
