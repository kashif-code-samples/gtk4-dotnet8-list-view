using ListView.App;

﻿var application = Gtk.Application.New("org.kashif-code-samples.listview.sample", Gio.ApplicationFlags.FlagsNone);
application.OnActivate += (sender, args) =>
{
    var buttonShowCodeListView = CreateButton("Show Code ListView Window");
    buttonShowCodeListView.OnClicked += (_, _) => new CodeListViewWindow().Show();

    var buttonShowTemplateListView = CreateButton("Show Template ListView Window");
    buttonShowTemplateListView.OnClicked += (_, _) => new TemplateListViewWindow().Show();

    var gtkBox = Gtk.Box.New(Gtk.Orientation.Vertical, 0);
    gtkBox.Append(buttonShowCodeListView);
    gtkBox.Append(buttonShowTemplateListView);

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