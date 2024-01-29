using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Delete.DeleteStudent;

public class DeleteStudentPageViewModel : INotifyPropertyChanged
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

    public ObservableCollection<Student> Students
    {
        get => _students;
        set
        {
            _students = value;
            OnPropertyChanged(nameof(Students));
        }
    }

    public DeleteStudentPageViewModel(Group group)
    {
        Students = group.Students;
    }

    public void DeleteStudent(Student student)
    {
        Students.Remove(student);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}