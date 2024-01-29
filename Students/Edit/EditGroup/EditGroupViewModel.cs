using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Edit.EditGroup;

public class EditGroupViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Group> _groups;

    public ObservableCollection<Group> Groups
    {
        get => _groups;
        set
        {
            _groups = value;
            OnPropertyChanged(nameof(Groups));
        }
    }

    public EditGroupViewModel(ObservableCollection<Group> group)
    {
        this.Groups = group;
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

    private string _newGroupName;

    public string NewGroupName
    {
        get => _newGroupName;
        set
        {
            _newGroupName = value;
            OnPropertyChanged(nameof(NewGroupName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void UpdateGroup(Group group)
    {
        int ind = Groups.IndexOf(group);

        if (NewGroupName != null && !NewGroupName.Equals(string.Empty))
        {
            Group newGroup = new Group()
            {
                Name = NewGroupName
            };

            Groups[ind] = newGroup;

            NewGroupName = string.Empty;
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}