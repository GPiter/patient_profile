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

            dictionaryFilling();  // Инициализация коллекции anket_base
            answerNotesFilling(); // Инициализация коллекции answer_notes

            // Открытие приложения со страницы 1
            StartPage spage = new StartPage();
            MainFrame.NavigationService.Navigate(spage);
        }

        private void dictionaryFilling()
        {
            for (int i = 0; i <= WorkBase.size; i++)
            {
                WorkBase.anket_base.Add(i, "0");
            }
        }

        private void answerNotesFilling()
        {
            for (int i = 0; i <= WorkBase.size; i++)
            {
                WorkBase.answer_notes.Add(i, "-");
            }
        }

    }

    public class item
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string answer;

    }

    public class Note
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string notes;
    }

    [Serializable]
    public static class WorkBase
    {
        public static int size = 30;
        // Создание базы ответов на вопросы
        public static Dictionary<int, string> anket_base { get; set; } = new Dictionary<int, string>(size);

        // Создание базы для примечаний
        public static Dictionary<int, string> answer_notes { get; set; } = new Dictionary<int, string>(size);
    }

    public static class Patient
    {
        public static String identifier = "-";
        public static String visit_date = DateTime.Now.ToString();
        public static String visit_number = "-";
    }

}
