using System.Collections.ObjectModel;

namespace Students.Entities;

public class Student
{
    public event EventHandler MeasurementsChanged;

    public string Level { get; set; }

    public string Gender { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public ObservableCollection<MeasurementOfStudent> Measurements { get; set; }

    public Student(string gender, string name, string surname)
    {
        Gender = gender;
        Name = name;
        Surname = surname;
        Measurements = new ObservableCollection<MeasurementOfStudent>();
    }

    public Student()
    {
        Measurements = new ObservableCollection<MeasurementOfStudent>();
    }

    protected virtual void OnMeasurementsChanged()
    {
        MeasurementsChanged?.Invoke(this, EventArgs.Empty);
    }
}