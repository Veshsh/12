using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _12DayBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool UpdateOr;
        public static object SelectItem;
        public bool all=false;
        public static string CreateData;
        public MainWindow()
        {
            InitializeComponent();
            {
                Data.SelectedDate = DateTime.Now;
                List<string> listname = new List<string>();
                foreach (Note note in Ster.data)
                {
                    if (note.date.ToShortDateString() == DateTime.Now.ToShortDateString())
                        listname.Add(note.name);
                }
                NoteName.ItemsSource = listname;

            }
        }

        private void DataPic(object sender, SelectionChangedEventArgs e)
        {
            DataPicin.Text = "";
            UpdateWindow();
            all = false;
        }
        private void ChoisNote(object sender, SelectionChangedEventArgs e)
        {
            TextNote.Text = Chouse();
        }
        private void All(object sender, RoutedEventArgs e)
        {
            Data.SelectedDate =null;
            UpdateWindow(true);
            all =true;
        }
        private void New(object sender, RoutedEventArgs e)
        {
            UpdateOr = false;
            NameOrUpdate();
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            SelectItem = NoteName.SelectedItem;
            if (NoteName.SelectedItem != null)
            {
                UpdateOr = true;
                NameOrUpdate();
            }
        }
        private void Delite(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            if (NoteName.SelectedItem != null && window2.ShowDialog() == true)
            {
                for (int i = 0; i < Ster.data.Count; i++)
                    if (NoteName.SelectedItem.ToString() == Ster.data[i].name)
                    Ster.data.RemoveAt(i);
                NoteName.SelectedItem = null;
                UpdateWindow(all);
                Ster.ster(Ster.data, Ster.Sterfile);
                DataPicin.Text = "";
            }

        }
        private void NameOrUpdate()
        {
            CreateData=Data.Text;
            Window1 window1 = new Window1();
            if (window1.ShowDialog() == true)
            { 
            if(UpdateOr)
                {
                    for (int i = 0; i < Ster.data.Count; i++)
                        if (NoteName.SelectedItem.ToString() == Ster.data[i].name)
                        {
                            Ster.data[i].date = Window1.EnterData;
                            Ster.data[i].name = Window1.EnterName;
                            Ster.data[i].text = Window1.EnterTexte;
                        }
                    UpdateWindow(all);
                    TextNote.Text = Chouse();
                }
            else if(!UpdateOr)
                {
                    Note Enteruser=new Note();
                    Enteruser.date = Window1.EnterData;
                    Enteruser.name = Window1.EnterName;
                    Enteruser.text = Window1.EnterTexte;
                    Ster.data.Add(Enteruser);
                    UpdateWindow(all);
                    TextNote.Text = Chouse();
                }
            }
            Ster.ster(Ster.data, Ster.Sterfile);
        }
        private void UpdateWindow(bool tupe=false)
        {
            TextNote.Text = "";
            List<string> listname = new List<string>();
            foreach (Note note in Ster.data)
                if (note.date.ToShortDateString() == Data.Text || tupe)
                    listname.Add(note.name);
            NoteName.ItemsSource = listname;
        }
        private string Chouse()
        {
            foreach (Note note in Ster.data)
                if (NoteName.SelectedItem != null && NoteName.SelectedItem.ToString() == note.name)
                {
                    if(all)
                    DataPicin.Text = note.date.ToString("dd.MM.yyyy");
                    return note.text;
                }
                else if(NoteName.SelectedItem == null)
                {
                    DataPicin.Text = "";
                    return "";
                }
                return ""; 
        }
    }
}
