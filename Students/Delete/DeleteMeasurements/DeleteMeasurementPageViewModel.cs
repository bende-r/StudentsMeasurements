using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Delete.DeleteMeasurements;

public class DeleteMeasurementPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Entities.MeasurementOfStudent> _measurements;

    private Entities.MeasurementOfStudent _selectedMeasurementOfStudent;

    public Entities.MeasurementOfStudent SelectedMeasurementOfStudent
    {
        get => _selectedMeasurementOfStudent;
        set
        {
            if (_selectedMeasurementOfStudent != value)
            {
                _selectedMeasurementOfStudent = value;
                OnPropertyChanged(nameof(SelectedMeasurementOfStudent));
            }
        }
    }

    public ObservableCollection<Entities.MeasurementOfStudent> Measurements
    {
        get => _measurements;
        set
        {
            _measurements = value;
            OnPropertyChanged(nameof(Measurements));
        }
    }

    public DeleteMeasurementPageViewModel(Student student)
    {
        Measurements = student.Measurements;
    }

    public void DeleteMeasurement(Entities.MeasurementOfStudent measurementOfStudent)
    {
        Measurements.Remove(measurementOfStudent);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}