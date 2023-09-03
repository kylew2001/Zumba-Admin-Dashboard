using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2BusinessKyle.ViewModels
{
    public class ViewModel
    {
        public ObservableCollection<string> DaysOfWeek { get; set; }
        public ObservableCollection<DailySchedule> Schedules { get; set; }

        public ViewModel()
        {
            DaysOfWeek = new ObservableCollection<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"
            };

            Schedules = new ObservableCollection<DailySchedule>
            {
                new DailySchedule("Monday"),
                new DailySchedule("Tuesday"),
                new DailySchedule("Wednesday"),
                new DailySchedule("Thursday"),
                new DailySchedule("Friday")
            };
        }
    }

    public class DailySchedule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<EventData>? _events;
        public ObservableCollection<EventData> Events
        {
            get => _events;
            set
            {
                _events = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Events)));

            }
        }

        public string DayName { get; set; }

        public DailySchedule(string dayName)
        {
            DayName = dayName;
            Events = new ObservableCollection<EventData>();
        }
    }

    public class EventData
    {
        public string EventName { get; set; } = ""; // Assign a default value
    }
}