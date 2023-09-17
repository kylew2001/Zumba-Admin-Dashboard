using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Assignment2BusinessKyle
{
    public partial class MainWindow : Window
    {
        private Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        private Dictionary<string, int> customerClasses = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveEvent_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = eventDatePicker.SelectedDate.HasValue ? eventDatePicker.SelectedDate.Value : DateTime.Today;
            string eventText = eventTextBox.Text;

            if (!string.IsNullOrWhiteSpace(eventText))
            {
                events[selectedDate] = eventText;
                eventTextBox.Clear();
            }
        }

        private void dateViewerCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateViewerCalendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = dateViewerCalendar.SelectedDate.Value;

                if (events.ContainsKey(selectedDate))
                {
                    eventDisplay.Text = $"Events for date: {selectedDate.ToShortDateString()}\n{events[selectedDate]}";
                }
                else
                {
                    eventDisplay.Text = $"No events for date: {selectedDate.ToShortDateString()}";
                }
            }
        }

        private void addClassButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCustomer = (customerComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                if (!customerClasses.ContainsKey(selectedCustomer))
                {
                    customerClasses[selectedCustomer] = 0;
                }

                customerClasses[selectedCustomer]++;
                UpdateClassesRemaining();
            }
        }

        private void useClassButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCustomer = ((ComboBoxItem)customerComboBox.SelectedItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                if (customerClasses.ContainsKey(selectedCustomer) && customerClasses[selectedCustomer] > 0)
                {
                    customerClasses[selectedCustomer]--;
                    UpdateClassesRemaining();
                }
            }
        }

        private void UpdateClassesRemaining()
        {
            string selectedCustomer = ((ComboBoxItem)customerComboBox.SelectedItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                int classesLeft = customerClasses.ContainsKey(selectedCustomer) ? customerClasses[selectedCustomer] : 0;
                classesRemainingTextBlock.Text = $"Classes remaining for {selectedCustomer}: {classesLeft}";
            }
        }

        private void eventTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
