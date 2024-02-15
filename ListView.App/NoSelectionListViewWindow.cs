namespace ListView.App;

using System.Reflection;
using Gtk;
using GObject;
using static Gtk.SignalListItemFactory;
using GLib;

public class NoSelectionListViewWindow : Window
{
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

        var listView = ListView.New(selectionModel, listItemFactory);

        var scrolledWindow = ScrolledWindow.New();
        scrolledWindow.Child = listView;
        scrolledWindow.WidthRequest = 150;

        var singleSelectionModel = SingleSelection.New(stringList);
        var bytes = Assembly.GetExecutingAssembly()
            .ReadResourceAsByteArray("ListItemTemplate.ui");
        var builderListItemFactory = BuilderListItemFactory.NewFromBytes(null, Bytes.New(bytes));
        var listViewRight = ListView.New(singleSelectionModel, builderListItemFactory);

        var scrolledWindowRight = ScrolledWindow.New();
        scrolledWindowRight.WidthRequest = 150;
        scrolledWindowRight.Child = listViewRight;

        var gtkBox = Gtk.Box.New(Gtk.Orientation.Horizontal, 0);
        gtkBox.Append(scrolledWindow);
        gtkBox.Append(scrolledWindowRight);

        Child = gtkBox;
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