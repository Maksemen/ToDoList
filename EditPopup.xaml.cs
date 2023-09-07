using System.Windows;

namespace ToDoListApp
{
    public partial class EditPopup : Window
    {
        private string tempdesc;//nazev do zmeny
        public EditPopup(ToDoItem item)//initializace komponentu
        {
            InitializeComponent();
            DataContext = item;
            tempdesc = item.Description;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//zpracovani zavreni dialogoveho okna a neukladani zmenenych dat
        {
            bool result = DialogResult??false;
            if (!result)
               (DataContext as ToDoItem).Description = tempdesc;
        }

        private void OK_Click(object sender, RoutedEventArgs e)//zpracovani klepnuti OK a ulozeni zmenenych dat
        {
            DialogResult = true;
            Close();
        }
    }
}
