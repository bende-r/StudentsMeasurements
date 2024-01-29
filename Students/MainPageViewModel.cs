using System.Collections.ObjectModel;
using System.ComponentModel;

using Students.Entities;

namespace Students;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Group> _groups;

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

    public ObservableCollection<Group> Groups
    {
        get => _groups;
        set
        {
            _groups = value;
            OnPropertyChanged(nameof(Groups));
        }
    }

    public MainPageViewModel()
    {
        Groups = new ObservableCollection<Group>();
    }

    public Group this[int id]
    {
        get { return Groups[id]; }

        set
        {
            Groups[id] = value;
            OnPropertyChanged(nameof(Groups));
        }
    }

    public int IndexOf(Group group)
    {
        return Groups.IndexOf(group);
    }

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}