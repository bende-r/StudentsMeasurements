using System.Collections.ObjectModel;

namespace Students.Entities;

public class Group
{
    public string Name { get; set; }
    public ObservableCollection<Student> Students { get; set; }

    public Group()
    {
        this.Students = new ObservableCollection<Student>();
    }
}