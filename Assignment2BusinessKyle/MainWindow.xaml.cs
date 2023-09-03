using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2BusinessKyle
{
    public class Event
    {
        public DateTime Date { get; set; }
        public string? Name { get; set; } // Assign a default value
                                               // Other properties as needed
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DateTime _selectedMonthStart = DateTime.Today;
        private int _zumbaClassesLeft = 10;
        private ObservableCollection<Event> _eventsForSelectedMonth = new ObservableCollection<Event>();

        // ... Other properties and fields ...

        public DateTime SelectedMonthStart
        {
            get { return _selectedMonthStart; }
            set { _selectedMonthStart = value; OnPropertyChanged("SelectedMonthStart"); }
        }

        public int ZumbaClassesLeft
        {
            get { return _zumbaClassesLeft; }
            set { _zumbaClassesLeft = value; OnPropertyChanged("ZumbaClassesLeft"); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            MonthCalendar.SelectedDatesChanged += MonthCalendar_SelectedDatesChanged;

            // Initialize other components and data here
        }

        private void MonthCalendar_SelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
        {
            // Handle the selected dates change here
            // You can access the selected dates using: MonthCalendar.SelectedDates
            UpdateEventList();
        }

        // ... Other methods ...

        private void UpdateEventList()
        {
            ObservableCollection<Event> eventsToShow = new ObservableCollection<Event>();

            foreach (var evt in _eventsForSelectedMonth)
            {
                if (evt.Date.Month == SelectedMonthStart.Month && evt.Date.Year == SelectedMonthStart.Year)
                {
                    eventsToShow.Add(evt);
                }
            }

            _eventsForSelectedMonth.Clear(); // Clear the existing collection
            foreach (var evt in eventsToShow)
            {
                _eventsForSelectedMonth.Add(evt); // Populate with events for the selected month
            }
        }


        private void SaveEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (EventDatePicker.SelectedDate.HasValue)
            {
                Event newEvent = new Event
                {
                    Date = EventDatePicker.SelectedDate.Value,
                    Name = EventNameTextBox.Text
                };

                _eventsForSelectedMonth.Add(newEvent);

                EventDatePicker.SelectedDate = null;
                EventNameTextBox.Clear();

                UpdateEventList();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
