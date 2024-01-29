using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Edit.EditMeasurements;

public class EditMeasurementPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<MeasurementOfStudent> _measurementOfStudents;

    private MeasurementOfStudent _selectedMeasurementOf;

    public MeasurementOfStudent SelectedMeasurementOfStudent
    {
        get => _selectedMeasurementOf;
        set
        {
            if (_selectedMeasurementOf != value)
            {
                _selectedMeasurementOf = value;
                OnPropertyChanged(nameof(SelectedMeasurementOfStudent));
            }
        }
    }

    public ObservableCollection<MeasurementOfStudent> MeasurementOfStudents
    {
        get => _measurementOfStudents;
        set
        {
            _measurementOfStudents = value;
            OnPropertyChanged(nameof(MeasurementOfStudents));
        }
    }

    public EditMeasurementPageViewModel(Student student)
    {
        MeasurementOfStudents = student.Measurements;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}