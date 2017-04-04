using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace CustomerDetails
{
    enum Title { Mr, Mrs, Miss, Ms }
    enum Gender { Male, Female }

    class Customer
    {
        private string foreName;
        private string lastName;
        private Title title;
        private Gender gender;

        public string ForeName
        {
            get { return this.foreName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Specify a forename for the customer");
                }
                else
                {
                    this.foreName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Specify a last name for the customer");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        public Title Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                if (!checkTitleAndGender(value, this.gender))
                {
                    throw new ApplicationException("The title must match the gender of the customer");
                }
            }
        }

        public Gender Gender
        {
            get { return this.gender; }
            set
            {
                this.gender = value;
                if (!checkTitleAndGender(this.title, value))
                {
                    throw new ApplicationException("The gender must match the title of the customer");
                }
            }
        }

        public override string ToString()
        {
            return this.Title.ToString() + " " + this.ForeName + " " + this.LastName + " - " + this.Gender.ToString();
        }

        private bool checkTitleAndGender(Title proposedTitle, Gender proposedGender)
        {
            bool retVal = false;

            if (proposedGender.Equals(Gender.Male))
            {
                retVal = (proposedTitle.Equals(Title.Mr))? true : false;
            }

            if (proposedGender.Equals(Gender.Female))
            {
                retVal = (proposedTitle.Equals(Title.Mr)) ? false : true;
            }

            return retVal;
        }
    }

    [ValueConversion(typeof(string), typeof(Title))]
    public class TitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Title title = (Title)value;
            return title.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Title retVal = Title.Miss;

            switch ((string)value)
            {
                case "Mr": retVal = Title.Mr;
                    break;
                case "Mrs": retVal = Title.Mrs;
                    break;
                case "Ms": retVal = Title.Ms;
                    break;
                case "Misss": retVal = Title.Miss;
                    break;
            }
            return retVal;
        }
    }

    [ValueConversion(typeof(bool), typeof(Gender))]
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string radioButtonId = (string)parameter;
            Gender gender = (Gender)value;
            bool retVal = false;

            if (String.Equals(radioButtonId, "Female") && gender.Equals(Gender.Female))
                retVal = true;

            if (String.Equals(radioButtonId, "Male") && gender.Equals(Gender.Male))
                retVal = true;

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (String.Equals((string)parameter, "Female"))
                return Gender.Female;
            else
                return Gender.Male;
        }
    }
}
