using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Edit.EditStudent;

public class EditStudentPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Student> _students;

    private Student _selectedStudent;

    public Student SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            if (_selectedStudent != value)
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
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

    public ObservableCollection<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            OnPropertyChanged(nameof(Students));
        }
    }

    public EditStudentPageViewModel(Group group)
    {
        Students = group.Students;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}