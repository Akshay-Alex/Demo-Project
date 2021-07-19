using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool phoneValid = false;
        private bool idValid = false;
        private bool emailNotValid = false;
        bool _hidePassword = true;
        private int passwordStrength = 0;
       
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Color ScoreToColor(int score)
        {
            if (score == 1)
            {
                return Color.Red;
            }
            else if(score == 2)
            {
                return Color.OrangeRed;
            }
            else if(score == 3)
            {
                return Color.Orange;
            }
            else if(score == 4)
            {
                return Color.Yellow;
            }
            else if(score == 5)
            {
                return Color.YellowGreen;
            }
            else if(score == 6)
            {
                return Color.LightGreen;
            }
            else if(score == 7)
            {
                return Color.Green;
            }
            else
            {
                return Color.White;
            }
        }
        public String ScoreToMessage(int score)
        {
            if (score == 1)
            {
                return "Very Weak";
            }
            else if (score == 2)
            {
                return "Weak";
            }
            else if (score == 3)
            {
                return "Okay";
            }
            else if (score == 4)
            {
                return "Medium";
            }
            else if (score == 5)
            {
                return "Good";
            }
            else if (score == 6)
            {
                return "Strong";
            }
            else if (score == 7)
            {
                return "Very Strong";
            }
            else
            {
                return "";
            }
        }
        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
        public static int CheckStrength(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }

            if (password.Length < 1)
            {
                return 0;
            }
            if (password.Length >= 1)
            {
                score++;
            }
            if (password.Length >= 4)
            {
                score++;
            }

            if (password.Length >= 8)
            {
                score++;
            }

            if (password.Length >= 10)
            {
                score++;
            }

            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
                Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            return score;
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
        public int PasswordStrength
        {
            get => passwordStrength;
            set
            {
                passwordStrength = value;
                OnPropertyChanged();
            }
        }
        public bool PhoneValid
        {
            get => phoneValid;
            set
            {
                phoneValid = value;
                OnPropertyChanged();
            }
        }
        public bool IdValid
        {
            get => idValid;
            set
            {
                idValid = value;
                OnPropertyChanged();
            }
        }
        public bool EmailNotValid
        {
            get => emailNotValid;
            set
            {
                emailNotValid = value;
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
