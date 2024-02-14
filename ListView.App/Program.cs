using ListView.App;

﻿var application = Gtk.Application.New("org.kashif-code-samples.listview.sample", Gio.ApplicationFlags.FlagsNone);
application.OnActivate += (sender, args) =>
{
    var buttonShowNoSelectionListView = CreateButton("Show No Selection ListView");
    buttonShowNoSelectionListView.OnClicked += (_, _) => new NoSelectionListViewWindow().Show();

    var gtkBox = Gtk.Box.New(Gtk.Orientation.Vertical, 0);
    gtkBox.Append(buttonShowNoSelectionListView);

    var window = Gtk.ApplicationWindow.New((Gtk.Application) sender);
    window.Title = "ListView Sample";
    window.SetDefaultSize(300, 300);
    window.Child = gtkBox;
    window.Show();
};
return application.RunWithSynchronizationContext(null);

static Gtk.Button CreateButton(string label)
{
    var button = Gtk.Button.New();
    button.Label = label;
    button.SetMarginTop(12);
    button.SetMarginBottom(12);
    button.SetMarginStart(12);
    button.SetMarginEnd(12);
    return button;
}