using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Delete.DeleteGroup;

public class DeleteGroupPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Group> _groups;

    public DeleteGroupPageViewModel(ObservableCollection<Group> groups)
    {
        Groups = groups;
    }

    public ObservableCollection<Group> Groups
    {
        get => _groups;
        set
        {
            _groups = value;
            OnPropertyChanged(nameof(Groups));
        }
    }

    private Group _selectedGroup;

    public Group SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            if (_selectedGroup != value)
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void DeleteGroup(Group group)
    {
        Groups.Remove(group);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}