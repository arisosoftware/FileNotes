using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileNotes.ViewModel;
using System.Collections.ObjectModel;

namespace FileNotes.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FolderItem root = new FolderItem() { Title = "Menu" };
			FolderItem childItem1 = new FolderItem() { Title = "Child item #1" };
			childItem1.SubItems= new ObservableCollection<FolderItem>();
                
              childItem1.SubItems  .Add(new FolderItem() { Title = "Child item #1.1" });
			childItem1.SubItems.Add(new FolderItem() { Title = "Child item #1.2" });
            root.SubItems = new ObservableCollection<FolderItem>();
			root.SubItems.Add(childItem1);
			root.SubItems.Add(new FolderItem() { Title = "Child item #2" });
			trvMenu.Items.Add(root);

            this.DataContext = root;
        }
    }
}
