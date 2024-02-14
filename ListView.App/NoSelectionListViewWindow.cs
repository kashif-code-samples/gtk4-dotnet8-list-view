namespace ListView.App;

using Gtk;
using static Gtk.SignalListItemFactory;

public class NoSelectionListViewWindow : Window
{
    private readonly ListView _listView;

    public NoSelectionListViewWindow()
        : base()
    {
        Title = "No Selection ListView";
        SetDefaultSize(300, 300);

        var stringList = StringList.New(["One", "Two", "Three", "Four"]);
        var selectionModel = NoSelection.New(stringList);
        var listItemFactory = SignalListItemFactory.New();
        listItemFactory.OnSetup += SetupSignalHandler;
        listItemFactory.OnBind += BindSignalHandler;

        _listView = ListView.New(selectionModel, listItemFactory);

        var scrolledWindow = ScrolledWindow.New();
        scrolledWindow.Child = _listView;
        Child = scrolledWindow;
    }

    private void SetupSignalHandler(SignalListItemFactory sender, SetupSignalArgs args)
    {
        var listItem = args.Object as ListItem;
        if (listItem is null)
        {
            return;
        }

        var label = Label.New(null);
        listItem.Child = label;
    }

    private void BindSignalHandler(SignalListItemFactory sender, BindSignalArgs args)
    {
        var listItem = args.Object as ListItem;
        if (listItem is null)
        {
            return;
        }
        
        var label = listItem.Child as Label;
        if (label is null)
        {
            return;
        }

        var item = listItem.Item as StringObject;
        label.SetText(item?.String ?? "NOT FOUND");
    }
}