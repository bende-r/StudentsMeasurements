using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Add.AddStudent;

public class AddStudentPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Student> _students;

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

    private string _newName;

    public string NewName
    {
        get => _newName;
        set
        {
            _newName = value;
            OnPropertyChanged(nameof(NewName));
        }
    }

    private string _newSurname;

    public string NewSurname
    {
        get => _newSurname;
        set
        {
            _newSurname = value;
            OnPropertyChanged(nameof(NewSurname));
        }
    }

    public ObservableCollection<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            OnPropertyChanged(nameof(Students));
        }
    }

    public AddStudentPageViewModel(Group group)
    {
        Students = group.Students;
    }

    public void AddStudent()
    {
        if (NewName != null && !NewName.Equals(string.Empty) && NewSurname != null && !NewSurname.Equals(string.Empty))
        {
            Student student = new Student( NewGender, NewName, NewSurname);

            Students.Add(student);

            NewName = string.Empty;
            NewSurname = string.Empty;
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}