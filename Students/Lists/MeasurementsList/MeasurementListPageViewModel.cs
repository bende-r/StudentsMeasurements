using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Lists.MeasurementsList;

public class MeasurementListPageViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<MeasurementOfStudent> _measurementOfStudents;

    private MeasurementOfStudent _selectedMeasurementOfStudent;

    public MeasurementOfStudent SelectedMeasurementOfStudent
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

    public string Name { get; set; }
    public string Surname { get; set; }

    public ObservableCollection<MeasurementOfStudent> MeasurementOfStudents
    {
        get => _measurementOfStudents;
        set
        {
            _measurementOfStudents = value;
            OnPropertyChanged(nameof(MeasurementOfStudents));
        }
    }

    public MeasurementListPageViewModel(Student student)
    {
        Name = student.Name;
        Surname = student.Surname;
        MeasurementOfStudents = student.Measurements;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}