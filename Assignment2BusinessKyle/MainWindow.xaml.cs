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
            DateTime selectedDate = eventDatePicker.SelectedDate ?? DateTime.Today;
            string eventText = eventTextBox.Text;

            if (!string.IsNullOrWhiteSpace(eventText))
            {
                // Store the event in the dictionary
                events[selectedDate] = eventText;

                // Optionally, clear the eventTextBox for the next event
                eventTextBox.Clear();
            }
        }

        private void dateViewerCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateViewerCalendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = dateViewerCalendar.SelectedDate.Value;

                // Check if events exist for the selected date
                if (events.ContainsKey(selectedDate))
                {
                    // Display events for the selected date
                    eventDisplay.Text = $"Events for date: {selectedDate.ToShortDateString()}\n{events[selectedDate]}";
                }
                else
                {
                    // No events for the selected date
                    eventDisplay.Text = $"No events for date: {selectedDate.ToShortDateString()}";
                }
            }
        }

        private void addClassButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCustomer = ((ComboBoxItem)customerComboBox.SelectedItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                // Implement logic to add a class to the selected customer
                if (!customerClasses.ContainsKey(selectedCustomer))
                {
                    customerClasses[selectedCustomer] = 0;
                }

                customerClasses[selectedCustomer]++;

                // Update classes remaining text
                UpdateClassesRemaining();
            }
        }

        private void useClassButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCustomer = ((ComboBoxItem)customerComboBox.SelectedItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                // Implement logic to use a class for the selected customer
                if (customerClasses.ContainsKey(selectedCustomer) && customerClasses[selectedCustomer] > 0)
                {
                    customerClasses[selectedCustomer]--;

                    // Update classes remaining text
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

        private void customerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement logic to handle the selection change of the customerComboBox, if needed.
            // This event is triggered when the selected customer changes.
            // You can update the classes remaining text or perform any other required actions.
            UpdateClassesRemaining();
        }
    }
}
