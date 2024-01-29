using System.Collections.ObjectModel;
using System.ComponentModel;

using Students.Entities;

namespace Students.Add.AddMeasurements;

public class AddMeasurementPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<MeasurementOfStudent> _measurements;

    private DateTime _newDateOfMeasurement;

    public DateTime NewDateOfMeasurement
    {
        get => _newDateOfMeasurement;
        set
        {
            _newDateOfMeasurement = value;
            OnPropertyChanged(nameof(NewDateOfMeasurement));
        }
    }

    private string _newGender;

    public string NewGender
    {
        get => _newGender;
        set
        {
            _newGender = value;
            OnPropertyChanged(nameof(NewGender));
        }
    }

    private int _newLungCapacity;

    public int NewLungCapacity
    {
        get => _newLungCapacity;
        set
        {
            _newLungCapacity = value;
            OnPropertyChanged(nameof(NewLungCapacity));
        }
    }

    private float _newHand;

    public float NewHand
    {
        get => _newHand;
        set
        {
            _newHand = value;
            OnPropertyChanged(nameof(NewHand));
        }
    }

    private int _newHeight;

    public int NewHeight
    {
        get => _newHeight;
        set
        {
            _newHeight = value;
            OnPropertyChanged(nameof(NewHeight));
        }
    }

    private int _newWeight;

    public int NewWeight
    {
        get => _newWeight;
        set
        {
            _newWeight = value;
            OnPropertyChanged(nameof(NewWeight));
        }
    }

    private int _newBloodPressureBefore;

    public int NewBloodPressureBefore
    {
        get => _newBloodPressureBefore;
        set
        {
            _newBloodPressureBefore = value;
            OnPropertyChanged(nameof(NewBloodPressureBefore));
        }
    }

    private int _newBloodPressureAfter;

    public int NewBloodPressureAfter
    {
        get => _newBloodPressureAfter;
        set
        {
            _newBloodPressureAfter = value;
            OnPropertyChanged(nameof(NewBloodPressureAfter));
        }
    }

    private int _newHeartRateBefore;

    public int NewHeartRateBefore
    {
        get => _newHeartRateBefore;
        set
        {
            _newHeartRateBefore = value;
            OnPropertyChanged(nameof(NewHeartRateBefore));
        }
    }

    private int _newHeartRateAfter;

    public int NewHeartRateAfter
    {
        get => _newHeartRateAfter;
        set
        {
            _newHeartRateAfter = value;
            OnPropertyChanged(nameof(NewHeartRateAfter));
        }
    }

    private string _newHeartRateMin;

    public string NewHeartRateMin
    {
        get => _newHeartRateMin;
        set
        {
            _newHeartRateMin = value;
            OnPropertyChanged(nameof(NewHeartRateMin));
        }
    }

    public ObservableCollection<MeasurementOfStudent> Measurements
    {
        get => _measurements;
        set
        {
            _measurements = value;
            OnPropertyChanged(nameof(Measurements));
        }
    }

    public AddMeasurementPageViewModel(Student student)
    {
        NewGender = student.Gender;
        Measurements = student.Measurements;
    }

    public void AddMeasurement()
    {
        if (NewLungCapacity > 0 && NewHand > 0 && NewWeight > 0 && NewHeight > 0 && NewBloodPressureBefore > 0 && NewBloodPressureAfter > 0 && NewHeartRateBefore > 0 && NewHeartRateAfter > 0 && NewHeartRateMin != null)
        {
            MeasurementOfStudent measurementOfStudent = new MeasurementOfStudent(DateTime.Now, NewGender,
                NewLungCapacity, NewHand, NewWeight, NewHeight, NewBloodPressureBefore, NewBloodPressureAfter,
                NewHeartRateBefore, NewHeartRateAfter, NewHeartRateMin);

            Measurements.Add(measurementOfStudent);

            NewBloodPressureBefore = 0;
            NewBloodPressureAfter = 0;
            NewHeartRateBefore = 0;
            NewHeartRateAfter = 0;
            NewHeight = 0;
            NewWeight = 0;
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}