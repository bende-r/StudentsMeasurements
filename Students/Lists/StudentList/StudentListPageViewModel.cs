using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Lists.StudentList;

public class StudentListPageViewModel
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

    private string _title;

    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
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

    public StudentListPageViewModel(Group group)
    {
        Title = group.Name;
        Students = group.Students;
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}