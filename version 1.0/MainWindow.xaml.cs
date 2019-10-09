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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace patient_profile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            dictionaryFilling(); // Инициализация словаря начальными значениями

            // Открытие приложения со страницы 1
            Page1 p1 = new Page1(); 
            MainFrame.NavigationService.Navigate(p1);
        }

        private void dictionaryFilling()
        {
            for (int i = 0; i <= WorkBase.size; i++)
            {
                WorkBase.anket_base.Add(i, "0");
            }
        }

    }

    public class item
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string value;

    }

    [Serializable]
    public static class WorkBase
    {
        public static int size = 100;
        // Создание базы ответов на вопросы
        public static Dictionary<int, string> anket_base { get; set; } = new Dictionary<int, string>(size);
    }

}
