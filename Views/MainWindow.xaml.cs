using MySql.Data.MySqlClient;
using NewLab_2.Core;
using NewLab_2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NewLab_2.Views
{
    public partial class MainWindow : Window
    {
        #region PROPERTIES

        public int SectionIndex { get; set; }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            LoadDataBase();
        }

        #region BASE METHODS

        private void MoveWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        #endregion

        #region TAB BUTTONS

        private void ActivatePersonSection_Click(object sender, RoutedEventArgs e)
        {
            SectionIndex = 0;
            LoadPersonData();
        }

        private void ActivateRegionSection_Click(object sender, RoutedEventArgs e)
        {
            SectionIndex = 1;
            LoadRegionData();
        }

        private void ActivateCityTypeSection_Click(object sender, RoutedEventArgs e)
        {
            SectionIndex = 2;
            LoadCityTypeData();
        }

        private void ActivateCitySection_Click(object sender, RoutedEventArgs e)
        {
            SectionIndex = 3;
            LoadCityData();
        }

        private void ActivateMigrationInfoSection_Click(object sender, RoutedEventArgs e)
        {
            SectionIndex = 4;
            LoadMigrationData();
        }

        #endregion

        #region LOAD DATABASE

        private void LoadDataBase()
        {
            using (var context = new HospitalDbContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }

        #endregion

        #region LOAD SECTION METHODS

        private void LoadData(string tableName)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                var dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dtGrid.ItemsSource = dt.DefaultView;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadPersonData()
        {
            PersonInputPanel.Visibility = Visibility.Visible;
            ControlButtonsPanel.Visibility = Visibility.Visible;
            dtGrid.Visibility = Visibility.Visible;

            RegionInputPanel.Visibility = Visibility.Collapsed;
            CityTypeInputPanel.Visibility = Visibility.Collapsed;
            CityInputPanel.Visibility = Visibility.Collapsed;

            LoadData("persons");
        }

        private void LoadRegionData()
        {
            RegionInputPanel.Visibility = Visibility.Visible;
            ControlButtonsPanel.Visibility = Visibility.Visible;
            dtGrid.Visibility = Visibility.Visible;

            PersonInputPanel.Visibility = Visibility.Collapsed;
            CityTypeInputPanel.Visibility = Visibility.Collapsed;
            CityInputPanel.Visibility = Visibility.Collapsed;

            LoadData("regions");
        }

        private void LoadCityTypeData()
        {
            CityTypeInputPanel.Visibility = Visibility.Visible;
            ControlButtonsPanel.Visibility = Visibility.Visible;
            dtGrid.Visibility= Visibility.Visible;

            PersonInputPanel.Visibility = Visibility.Collapsed;
            RegionInputPanel.Visibility= Visibility.Collapsed;
            CityInputPanel.Visibility = Visibility.Collapsed;

            LoadData("city_types");
        }

        private void LoadCityData()
        {
            CityInputPanel.Visibility = Visibility.Visible;
            ControlButtonsPanel.Visibility = Visibility.Visible;
            dtGrid.Visibility = Visibility.Visible;

            PersonInputPanel.Visibility = Visibility.Collapsed;
            RegionInputPanel.Visibility = Visibility.Collapsed;
            CityTypeInputPanel.Visibility = Visibility.Collapsed;

            LoadData("cities");
        }

        private void LoadMigrationData()
        {
            PersonInputPanel.Visibility = Visibility.Collapsed;
            RegionInputPanel.Visibility = Visibility.Collapsed;
            CityTypeInputPanel.Visibility = Visibility.Collapsed;
            CityInputPanel.Visibility = Visibility.Collapsed;
            ControlButtonsPanel.Visibility = Visibility.Collapsed;
            dtGrid.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region CONTROL BUTTONS

        private void AddData()
        {
            switch (SectionIndex)
            {
                case 0:
                    AddNewPerson();
                    break;
                case 1:
                    AddNewRegion();
                    break;
                case 2:
                    AddNewCityType();
                    break;
                case 3:
                    AddNewCity();
                    break;
                default:
                    MessageBox.Show("Incorrect choice.");
                    break;
            }
        }

        private void AddNewPerson()
        {
            if (!(string.IsNullOrEmpty(FirstNameBox.Text) && string.IsNullOrEmpty(LastNameBox.Text) && string.IsNullOrEmpty(MiddleNameBox.Text)))
            {
                using (var context = new HospitalDbContext())
                {
                    var newPerson = new Person()
                    {
                        FirstName = FirstNameBox.Text,
                        LastName = LastNameBox.Text,
                        MiddleName = MiddleNameBox.Text
                    };

                    context.Persons.Add(newPerson);
                    MessageBox.Show("Information added successfully.");

                    context.SaveChanges();

                    FirstNameBox.Text = "";
                    LastNameBox.Text = "";
                    MiddleNameBox.Text = "";

                    LoadPersonData();
                }
            }
            else MessageBox.Show("Fill in the data.");
        }

        private void AddNewRegion()
        {
            if (!string.IsNullOrEmpty(RegionNameBox.Text))
            {
                using (var context = new HospitalDbContext())
                {
                    var newRegion = new Region()
                    {
                        RegionName = RegionNameBox.Text
                    };

                    context.Regions.Add(newRegion);
                    MessageBox.Show("Information added successfully.");

                    context.SaveChanges();

                    RegionNameBox.Text = "";

                    LoadRegionData();
                }
            }
            else MessageBox.Show("Fill in the data.");
        }

        private void AddNewCityType()
        {
            if (!string.IsNullOrEmpty(CityTypeNameBox.Text))
            {
                using (var context = new HospitalDbContext())
                {
                    var newCityType = new CityType()
                    {
                        TypeName = CityTypeNameBox.Text
                    };

                    context.CityTypes.Add(newCityType);
                    MessageBox.Show("Information added successfully.");

                    context.SaveChanges();

                    CityTypeNameBox.Text = "";

                    LoadCityTypeData();
                }
            }
            else MessageBox.Show("Fill in the data.");
        }

        private void AddNewCity()
        {
            if (!(string.IsNullOrEmpty(CityNameBox.Text) && string.IsNullOrEmpty(CityTypeIDNameBox.Text)))
            {
                using (var context = new HospitalDbContext())
                {
                    var newCity = new City()
                    {
                        CityName = CityNameBox.Text,
                        CityTypeID = Convert.ToInt64(CityTypeIDNameBox.Text)
                    };

                    context.Cities.Add(newCity);
                    MessageBox.Show("Information added successfully.");

                    context.SaveChanges();

                    CityNameBox.Text = "";
                    CityTypeIDNameBox.Text = "";

                    LoadCityData();
                }
            }
            else MessageBox.Show("Fill in the data.");
        }

        private void SaveChanges()
        {
            switch (SectionIndex)
            {
                case 0:
                    SavePersonChanges();
                    break;
                case 1:
                    SaveRegionChanges();
                    break;
                case 2:
                    SaveCityTypeChanges();
                    break;
                case 3:
                    SaveCityChanges();
                    break;
                default:
                    MessageBox.Show("Incorrect choice.");
                    break;
            }
        }

        private void SavePersonChanges()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var personID = Convert.ToInt64(selectedDataRow["PersonID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var existingPerson = context.Persons.Find(personID);
                        if (existingPerson != null)
                        {
                            existingPerson.FirstName = FirstNameBox.Text;
                            existingPerson.LastName = LastNameBox.Text;
                            existingPerson.MiddleName = MiddleNameBox.Text;

                            context.SaveChanges();
                            MessageBox.Show("Information updated successfully.");

                            LoadPersonData();
                        }
                        else MessageBox.Show("Person not found in the database.");
                    }
                }
                else MessageBox.Show("Person ID is Null.");
            }
        }

        private void SaveRegionChanges()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var regionID = Convert.ToInt64(selectedDataRow["RegionID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var existingRegion = context.Regions.Find(regionID);
                        if (existingRegion != null)
                        {
                            existingRegion.RegionName = RegionNameBox.Text;

                            context.SaveChanges();
                            MessageBox.Show("Information updated successfully.");

                            LoadRegionData();
                        }
                        else MessageBox.Show("Region not found in the database.");
                    }
                }
                else MessageBox.Show("Region ID is Null.");
            }
        }

        private void SaveCityTypeChanges()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var cityTypeID = Convert.ToInt64(selectedDataRow["CityTypeID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var existingCityType = context.CityTypes.Find(cityTypeID);
                        if (existingCityType != null)
                        {
                            existingCityType.TypeName = CityTypeNameBox.Text;

                            context.SaveChanges();
                            MessageBox.Show("Information updated successfully.");

                            LoadCityTypeData();
                        }
                        else MessageBox.Show("CityType not found in the database.");
                    }
                }
                else MessageBox.Show("CityType ID is Null.");
            }
        }

        private void SaveCityChanges()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var cityID = Convert.ToInt64(selectedDataRow["CityID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var existingCity = context.Cities.Find(cityID);
                        if (existingCity != null)
                        {
                            existingCity.CityName = CityNameBox.Text;
                            existingCity.CityTypeID = Convert.ToInt64(CityTypeIDNameBox.Text);

                            context.SaveChanges();
                            MessageBox.Show("Information updated successfully.");

                            LoadCityData();
                        }
                        else MessageBox.Show("City not found in the database.");
                    }
                }
                else MessageBox.Show("City ID is Null.");
            }
        }

        private void Remove()
        {
            switch (SectionIndex)
            {
                case 0:
                    RemovePerson();
                    break;
                case 1:
                    RemoveRegion();
                    break;
                case 2:
                    RemoveCityType();
                    break;
                case 3:
                    RemoveCity();
                    break;
                default:
                    MessageBox.Show("Incorrect choice.");
                    break;
            }
        }

        private void RemovePerson()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var personID = Convert.ToInt64(selectedDataRow["PersonID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var productToDelete = context.Persons.Find(personID);
                        if (productToDelete != null)
                        {
                            context.Persons.Remove(productToDelete);
                            MessageBox.Show("Information removed successfully.");

                            context.SaveChanges();
                        }
                    }

                    var personList = dtGrid.ItemsSource as List<Person>;
                    if (personList != null)
                    {
                        var personToRemove = personList.FirstOrDefault(p => p.PersonID == personID);
                        if (personToRemove != null)
                            personList.Remove(personToRemove);
                    }
                }
                LoadPersonData();
            }
        }

        private void RemoveRegion()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var regionID = Convert.ToInt64(selectedDataRow["RegionID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var productToDelete = context.Regions.Find(regionID);
                        if (productToDelete != null)
                        {
                            context.Regions.Remove(productToDelete);
                            MessageBox.Show("Information removed successfully.");

                            context.SaveChanges();
                        }
                    }

                    var regionList = dtGrid.ItemsSource as List<Region>;
                    if (regionList != null)
                    {
                        var regionToRemove = regionList.FirstOrDefault(p => p.RegionID == regionID);
                        if (regionToRemove != null)
                           regionList.Remove(regionToRemove);
                    }
                }
                LoadRegionData();
            }
        }

        private void RemoveCityType()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var cityTypeID = Convert.ToInt64(selectedDataRow["CityTypeID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var productToDelete = context.CityTypes.Find(cityTypeID);
                        if (productToDelete != null)
                        {
                            context.CityTypes.Remove(productToDelete);
                            MessageBox.Show("Information removed successfully.");

                            context.SaveChanges();
                        }
                    }

                    var cityTypeList = dtGrid.ItemsSource as List<CityType>;
                    if (cityTypeList != null)
                    {
                        var cityTypeToRemove = cityTypeList.FirstOrDefault(p => p.CityTypeID == cityTypeID);
                        if (cityTypeToRemove != null)
                            cityTypeList.Remove(cityTypeToRemove);
                    }
                }
                LoadCityTypeData();
            }
        }

        private void RemoveCity()
        {
            var selectedDataRowView = dtGrid.SelectedItem as DataRowView;
            if (selectedDataRowView != null)
            {
                var selectedDataRow = selectedDataRowView.Row;
                if (selectedDataRow != null)
                {
                    var cityID = Convert.ToInt64(selectedDataRow["CityID"]);
                    using (var context = new HospitalDbContext())
                    {
                        var productToDelete = context.Cities.Find(cityID);
                        if (productToDelete != null)
                        {
                            context.Cities.Remove(productToDelete);
                            MessageBox.Show("Information removed successfully.");

                            context.SaveChanges();
                        }
                    }

                    var cityList = dtGrid.ItemsSource as List<City>;
                    if (cityList != null)
                    {
                        var cityToRemove = cityList.FirstOrDefault(p => p.CityID == cityID);
                        if (cityToRemove != null)
                            cityList.Remove(cityToRemove);
                    }
                }
                LoadCityData();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddData();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Remove();
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtGrid.SelectedItem is DataRowView selectedDataRowView)
            {
                if (dtGrid.Columns.Count > 0 && dtGrid.Columns[0].Header.Equals("PersonID"))
                {
                    if (selectedDataRowView["PersonID"] != DBNull.Value)
                    {
                        long selectedPersonID = Convert.ToInt64(selectedDataRowView["PersonID"]);
                        using (var context = new HospitalDbContext())
                        {
                            var existingPerson = context.Persons.Find(selectedPersonID);
                            if (existingPerson != null)
                            {
                                FirstNameBox.Text = existingPerson.FirstName;
                                LastNameBox.Text = existingPerson.LastName;
                                MiddleNameBox.Text = existingPerson.MiddleName;
                            }
                            else MessageBox.Show("Person not found in the database.");
                        }
                    }
                    else MessageBox.Show("Person ID is Null.");
                }
                
                else if (dtGrid.Columns.Count > 0 && dtGrid.Columns[0].Header.Equals("RegionID"))
                {
                    if (selectedDataRowView["RegionID"] != DBNull.Value)
                    {
                        long selectedRegionID = Convert.ToInt64(selectedDataRowView["RegionID"]);
                        using (var context = new HospitalDbContext())
                        {
                            var existingRegion = context.Regions.Find(selectedRegionID);
                            if (existingRegion != null)
                            {
                                RegionNameBox.Text = existingRegion.RegionName;
                            }
                            else MessageBox.Show("Region not found in the database.");
                        }
                    }
                    else MessageBox.Show("Region ID is Null.");
                }

                else if (dtGrid.Columns.Count > 0 && dtGrid.Columns[0].Header.Equals("CityTypeID"))
                {
                    if (selectedDataRowView["CityTypeID"] != DBNull.Value)
                    {
                        long selectedCityTypeID = Convert.ToInt64(selectedDataRowView["CityTypeID"]);
                        using (var context = new HospitalDbContext())
                        {
                            var existingCityType = context.CityTypes.Find(selectedCityTypeID);
                            if (existingCityType != null)
                            {
                                CityTypeNameBox.Text = existingCityType.TypeName;
                            }
                            else MessageBox.Show("CityType not found in the database.");
                        }
                    }
                    else MessageBox.Show("CityType ID is Null.");
                }

                else if (dtGrid.Columns.Count > 0 && dtGrid.Columns[0].Header.Equals("CityID"))
                {
                    if (selectedDataRowView["CityID"] != DBNull.Value)
                    {
                        long selectedCityID = Convert.ToInt64(selectedDataRowView["CityID"]);
                        using (var context = new HospitalDbContext())
                        {
                            var existingCity = context.Cities.Find(selectedCityID);
                            if (existingCity != null)
                            {
                                CityNameBox.Text = existingCity.CityName;
                                CityTypeIDNameBox.Text = existingCity.CityTypeID.ToString();
                            }
                            else MessageBox.Show("City not found in the database.");
                        }
                    }
                    else MessageBox.Show("City ID is Null.");
                }
            }
        }

        #endregion
    }
}