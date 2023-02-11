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
using System.Windows.Shapes;

namespace _12DayBook
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static DateTime EnterData;
        public static string EnterName;
        public static string EnterTexte;
        public Window1()
        {
            InitializeComponent();
            {
                if (MainWindow.UpdateOr)
                {
                    foreach (Note note in Ster.data)
                        if (MainWindow.SelectItem != null)
                            if (MainWindow.SelectItem.ToString() == note.name)
                            {
                                RData.Text = note.date.ToString("dd.MM.yyyy");
                                RName.Text = note.name;
                                RText.Text = note.text;
                            }
                }
                else
                {
                    RData.Text = MainWindow.CreateData;
                }
            }
        }
        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                EnterData = DateTime.Parse(RData.Text);
            }
            catch (FormatException)
            {
                RData.Text = "";
                return;
            }
            for(int i = 0; i < Ster.data.Count; i++)
                if (Ster.data[i].name == RName.Text && !MainWindow.UpdateOr)
                {
                    RName.Text = "";
                    return;
                }
            EnterName = RName.Text;
            EnterTexte = RText.Text;
            DialogResult =true;
        }
        private void Clouse(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
