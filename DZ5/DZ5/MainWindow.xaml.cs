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
using MainClass;
using System.Text.RegularExpressions;

namespace DZ5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Дз5. Вариант 2. Буй Тхе Зунг. УТС-22
    /// Program Includes : -  Enter Nation, region, city, street, house number, postcode
    ///                    -  Each new position when entering the system creates a new object of class Base and is stored in List DB
    ///                    -  Display the data just entered on the Listview
    ///                    -  Users can access each entered location and change information and save as new information, or delete the entered data

    public partial class MainWindow : Window
    {
        static List<Base> DB = new List<Base>();
        int Click = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        //Function Check Format Input Data
        //Nation : Have to be letters a-z, can accept uppercase or lowercase letters, [space] can be accepted, CANNOT contain numbers or other characters
        //Region: Have to be letters a-z, can accept uppercase or lowercase letters, [space] can be accepted, CANNOT contain numbers or other characters
        //City : Have to be letters a-z, can accept uppercase or lowercase letters, [space] can be accepted, CANNOT contain numbers or other characters
        //Street: Have to be letters a-z and numbers, can accept uppercase or lowercase letters, [space] can be accepted, CANNOT contain other characters
        //Street: Have to be numbers 6 digits [space] CANNOT be accepted, CANNOT contain other characters
        //Postcode: Have to be numbers 6 digits [space] CANNOT be accepted, CANNOT contain other characters
        //
        //If any 1 or more blanks in 6 blanks (Nation, Region, City, Street, House Number, Postcode), the system will not allow data to be saved
        //
        //To determine the conditions for the blanks above for the system.Use Regular Expressions to perform data conditional validation
        private void Check_Format_Input(object sender, System.EventArgs e)
        {
            int AcceptIndex = 0;
            int NationAccess = 0;
            int RegionAccess = 0;
            int CityAccess = 0;
            int StreetAccess = 0;
            int HouseAccess = 0;
            int PostAccess = 0;

            //Nation
            if (Regex.IsMatch(InputNation.Text, "^[a-zA-Z ]+$", RegexOptions.IgnoreCase)) //allow Letters a-z or A-Z and [Space]
            {
                if (string.IsNullOrWhiteSpace(InputNation.Text))// if all the blank just [Space] cannot be allowed
                {
                    InputNationWarning.Visibility = Visibility.Collapsed;
                    NationEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    NationAccess = 0;
                }
                else
                {
                    NationEmpty.Visibility = Visibility.Collapsed;
                    InputNationWarning.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    NationAccess = 1;
                }
            }
            else if (string.IsNullOrEmpty(InputNation.Text))// if nothing in blank, just show the note
            {
                InputNationWarning.Visibility = Visibility.Collapsed;
                NationEmpty.Visibility = Visibility.Visible;
                AcceptIndex ++;
                NationAccess = 0;
            }
            else// if in the blank have some other characters, show red warning 
            {
                InputNationWarning.Visibility = Visibility.Visible;
                NationEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                NationAccess = 0;
            }

            //Region
            if (Regex.IsMatch(InputRegion.Text, "^[a-zA-Z ]+$", RegexOptions.IgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(InputRegion.Text))
                {
                    InputRegionWarning.Visibility = Visibility.Collapsed;
                    RegionEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    RegionAccess = 0;
                }
                else
                {
                    RegionEmpty.Visibility = Visibility.Collapsed;
                    InputRegionWarning.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    RegionAccess = 1;
                }
            }
            else if (string.IsNullOrEmpty(InputRegion.Text))
            {
                InputRegionWarning.Visibility = Visibility.Collapsed;
                RegionEmpty.Visibility = Visibility.Visible;
                AcceptIndex ++;
                RegionAccess = 0;
            }
            else
            {
                InputRegionWarning.Visibility = Visibility.Visible;
                RegionEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                RegionAccess = 0;
            }

            //City
            if (Regex.IsMatch(InputCity.Text, "^[a-zA-Z ]+$", RegexOptions.IgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(InputCity.Text))
                {
                    InputCityWarning.Visibility = Visibility.Collapsed;
                    CityEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    CityAccess = 0;
                }
                else
                {
                    CityEmpty.Visibility = Visibility.Collapsed;
                    InputCityWarning.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    CityAccess = 1;
                }
            }
            else if (string.IsNullOrEmpty(InputCity.Text))
            {
                InputCityWarning.Visibility = Visibility.Collapsed;
                CityEmpty.Visibility = Visibility.Visible;
                AcceptIndex ++;
                CityAccess = 0;
            }
            else
            {
                InputCityWarning.Visibility = Visibility.Visible;
                CityEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                CityAccess = 0;
            }

            //Street
            if (Regex.IsMatch(InputStreet.Text, "^[0-9a-zA-Z ]+$", RegexOptions.IgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(InputStreet.Text))
                {
                    InputStreetWarning.Visibility = Visibility.Collapsed;
                    StreetEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    StreetAccess = 0;
                }
                else
                {
                    StreetEmpty.Visibility = Visibility.Collapsed;
                    InputStreetWarning.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    StreetAccess = 1;
                }
            }
            else if (string.IsNullOrEmpty(InputStreet.Text))
            {
                InputStreetWarning.Visibility = Visibility.Collapsed;
                StreetEmpty.Visibility = Visibility.Visible;
                AcceptIndex ++;
                StreetAccess = 0;
            }
            else
            {
                InputStreetWarning.Visibility = Visibility.Visible;
                StreetEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                StreetAccess = 0;
            }

            //House Number
            if (Regex.IsMatch(InputHouse.Text, "^[0-9]+$", RegexOptions.IgnoreCase))
            {
                InputHouseWarning.Visibility = Visibility.Collapsed;
                if (InputHouse.Text.Length == 6)
                {
                    HouseEmpty.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    HouseAccess = 1;
                }
                else 
                {
                    HouseEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    HouseAccess = 0;
                }
            }
            else if (string.IsNullOrEmpty(InputHouse.Text))
            {
                InputHouseWarning.Visibility = Visibility.Collapsed;
                HouseEmpty.Visibility = Visibility.Visible;
                AcceptIndex++;
                HouseAccess = 0;
            }
            else
            {
                InputHouseWarning.Visibility = Visibility.Visible;
                HouseEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                HouseAccess = 0;
            }

            //Postcode
            if (Regex.IsMatch(InputPostcode.Text, "^[0-9]+$", RegexOptions.IgnoreCase))
            {
                InputPostcodeWarning.Visibility = Visibility.Collapsed;
                if (InputPostcode.Text.Length == 6)
                {
                    PostcodeEmpty.Visibility = Visibility.Collapsed;
                    AcceptIndex = 0;
                    PostAccess = 1;
                }
                else
                {
                    PostcodeEmpty.Visibility = Visibility.Visible;
                    AcceptIndex++;
                    PostAccess = 0;
                }
            }
            else if (string.IsNullOrEmpty(InputPostcode.Text))
            {
                InputPostcodeWarning.Visibility = Visibility.Collapsed;
                PostcodeEmpty.Visibility = Visibility.Visible;
                AcceptIndex++;
                PostAccess = 0;
            }
            else
            {
                InputPostcodeWarning.Visibility = Visibility.Visible;
                PostcodeEmpty.Visibility = Visibility.Collapsed;
                AcceptIndex++;
                PostAccess = 0;
            }

            //Allow to save
            int AllAccess = NationAccess + RegionAccess + CityAccess + StreetAccess + HouseAccess + PostAccess;
            if (AcceptIndex == 0 && AllAccess == 6)
            {
                EnterBtn.IsEnabled = true;
            }
            else 
            {
                EnterBtn.IsEnabled = false;
            }
        }

        //ListBox
        //User can double click on data and change information
        private void ListResult_SelectionChanged(object sender, System.EventArgs e)
        {
            int FirstTestClick= ListResult.SelectedIndex;
            if (FirstTestClick < DB.Count && FirstTestClick >= 0)
            {
                Click = FirstTestClick;
                Click = ListResult.SelectedIndex;
                DeleteBtn.IsEnabled = true;
                InputNation.Text = DB[Click].NationOutput;
                InputRegion.Text = DB[Click].RegionOutput;
                InputCity.Text = DB[Click].CityOutput;
                InputStreet.Text = DB[Click].StreetOutput;
                InputHouse.Text = DB[Click].HouseOutput;
                InputPostcode.Text = DB[Click].PostcodeOutput;
            }
        }

        //Enter Button (Save)
        //Save new data in DB
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteBtn.IsEnabled = false;
            ListResult.ItemsSource = DB;
            DB.Add(new Base() { NationOutput = InputNation.Text, RegionOutput = InputRegion.Text,CityOutput=InputCity.Text, StreetOutput=InputStreet.Text, HouseOutput=InputHouse.Text, PostcodeOutput=InputPostcode.Text });
            ListResult.Items.Refresh();
        }

        //Delete Button
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int sizeDB = DB.Count;
            for (int i = Click; i < sizeDB; i++)
            {
                if (i < sizeDB-1)
                {
                    DB[i] = DB[i + 1];
                }
            }
            DB.RemoveAt(sizeDB - 1);
            ListResult.ItemsSource = DB;
            ListResult.Items.Refresh();
            InputNation.Text = "";
            InputRegion.Text = "";
            InputCity.Text = "";
            InputStreet.Text = "";
            InputHouse.Text = "";
            InputPostcode.Text = "";
            DeleteBtn.IsEnabled = false;
        }
    }
}
