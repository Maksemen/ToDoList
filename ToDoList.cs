using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
using System.ComponentModel;

namespace ToDoListApp
{
    [Serializable]
    public class ToDoItem : INotifyPropertyChanged
    {
        private XElement todo;//vytvoreni ukolu
        internal XElement ToDo { get { return todo; } }//getter pro ukol
        internal ToDoItem(XElement todo)//setter pro ukol
        {
            this.todo = todo;
        }
        public string CreatedDateTime//ulozeni casu kdyz ukol byl vytvoren
        {
            get { return todo.Element("createdatetime").Value; }//getter
            set
            {
                todo.Element("createdatetime").Value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CreatedDateTime"));
                }
            }
        }
        public string Description//pridani nazvu ukolu
        {
            get { return todo.Element("description").Value; }//getter
            set
            {
                todo.Element("description").Value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }

        public string DoneDateTime//ulozeni casu kdyz ukol byl udelan
        {
            get { return todo.Element("donedatetime") == null ? "" : todo.Element("donedatetime").Value; }//getter
            set
            {
                if (todo.Element("donedatetime") == null)
                {
                    todo.Add(new XElement("donedatetime"));
                }
                
                todo.Element("donedatetime").Value = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DoneDateTime"));
                }
            }
        }

        public bool IsDone { get { return (todo.Element("donedatetime") != null); } }//getter pro stav ukolu

        public override string ToString()//formatovani pro datum a cas
        {
            string result;
            if (DoneDateTime != "")
            {
                DateTime doneAt = DateTime.Parse(DoneDateTime);
                result = String.Format("{0} - Done at: {1:yyyy-MM-dd hh:mm}", Description, doneAt);
            }
            else
            {
                result = Description;
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    [Serializable]
    public class ToDoList: INotifyPropertyChanged
    {
        [NonSerialized]
        private XDocument todoList;
        [NonSerialized]
        private bool showDoneItems;
        [NonSerialized]
        private List<ToDoItem> items;

        public List<ToDoItem> Items //zpracovani klepnuti Show done items
        {
            get
            {
                if (showDoneItems)
                {
                    return items;
                }
                else
                {
                    return (from i in items
                            where i.DoneDateTime == ""
                            select i).ToList();
                }
            }
        }

        public bool ShowDoneItems //getter a setter pro zoobrazeni detailu ukolu
        { 
            get { return showDoneItems; }
            set 
            { 
                showDoneItems = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ShowDoneItems"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Items"));
                }
            } 
        }

        public ToDoList()//ulozeni ukolu
        {
            AppSettingsReader asr = new AppSettingsReader();
            string listFileName = (string)asr.GetValue("listFileName", typeof(string));
            if (File.Exists(listFileName))
            {
                todoList = XDocument.Load(listFileName);
                items = (from e in todoList.Root.Elements()
                         select new ToDoItem(e)).ToList();
            }
            else
            {
                todoList = new XDocument();
                todoList.Add(new XElement("todolist"));
                items = new List<ToDoItem>();
            }

        }

        public void Additem(string description)//ulozeni informace o ukolu
        {
            XElement item = new XElement("todo");
            XElement createAt = new XElement("createdatetime");
            createAt.Value = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.ms");
            item.Add(createAt);
            XElement desc = new XElement("description");
            desc.Value = description;
            item.Add(desc);

            todoList.Root.Add(item);
            items.Add(new ToDoItem(item));

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public void DeleteItem(ToDoItem item)//odstraneni ukolu
        {
            items.Remove(item);
            item.ToDo.Remove();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
