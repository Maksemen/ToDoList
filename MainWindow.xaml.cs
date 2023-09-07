using System;
using System.Windows;
using System.Windows.Input;
namespace ToDoListApp
{
    public partial class MainWindow : Window
    {
        ToDoList tdl = new ToDoList();//vytvoreni objektu typa ToDoList
        public MainWindow()//initializace komponentu
        {
            InitializeComponent();
            DataContext = tdl;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)//zpracovani stlaceni tlacitka ADD a pridani dat do listu
        {
            if (!txtItemDesc.Text.Trim().Equals(string.Empty))//kontrola prazdnosti
            {
                tdl.Additem(txtItemDesc.Text.Trim());//pridani
            }
            txtItemDesc.Text = "";
            lvToDo.Items.Refresh();//aktualice
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) { }//prazdna metoda uzavreni aplikace

        private void MarkAsDone(object sender, RoutedEventArgs e)//oznaceni vyplneni ukolu
        {
            if (lvToDo.SelectedItem != null)//kontrola prazdnosti
            {
                MessageBoxResult done = MessageBox.Show("Mark this as done?", "Done?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);//vyber ano nebo ne
                if (done == MessageBoxResult.Yes)
                {
                    (lvToDo.SelectedItem as ToDoItem).DoneDateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.ms");//pridani informace o tom kdy to bylo udelano
                }
                lvToDo.Items.Refresh();//aktualice
            }
        }

        private void lvToDo_MouseDoubleClick(object sender, MouseButtonEventArgs e)//vyvolani metody MarkAsDone
        {
            MarkAsDone(sender, e);
        }

        private void EditMenu_Click(object sender, RoutedEventArgs e)//zpracovani stlaceni Edit
        {
            if (lvToDo.SelectedItem != null)//kontrola prazdnosti
            {
                EditPopup ep = new EditPopup(lvToDo.SelectedItem as ToDoItem);
                ep.Owner = this;
                ep.ShowDialog();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//zpracovani stlaceni Delete
        {
            if (lvToDo.SelectedItem != null)//kontrola prazdnosti
            {
                MessageBoxResult del = MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);//vyber ano nebo ne
                if (del == MessageBoxResult.Yes)
                {
                    tdl.DeleteItem(lvToDo.SelectedItem as ToDoItem);//odstraneni ukolu
                }
                lvToDo.Items.Refresh();//aktualice
            }
        }
    }
}
