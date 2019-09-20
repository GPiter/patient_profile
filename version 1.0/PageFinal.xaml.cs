using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageFinal.xaml
    /// </summary>
    public partial class PageFinal : Page
    {
        int slider_value;                   // Переменная для хранения значения слайдера
        public PageFinal()
        {
            InitializeComponent();
            CheckBase(); // Проверка базы ответов на введенные данные
        }

        //------------------------ Обработка радиобаттонов ----------------------------//
        private void Rb1_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[20] = cb_answer1_1.Content.ToString();
        }

        private void Rb2_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[20] = cb_answer1_2.Content.ToString();
        }

        private void Rb3_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[20] = cb_answer1_3.Content.ToString();
        }

        private void Rb4_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[20] = cb_answer1_4.Content.ToString();
        }

        private void Rb5_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[22] = cb_answer3_1.Content.ToString();
        }

        private void Rb6_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[22] = cb_answer3_2.Content.ToString();
        }

        //----------------------------------------------------------------------------//


        //------------------------- Обработка слайдера -------------------------------//

        private void Sl_answer_ValueChanged(object sender, RoutedEventArgs e)
        {
            slider_value = (int)sl_answer2_1.Value;
            WorkBase.anket_base[21] = slider_value.ToString();
        }

        //----------------------------------------------------------------------------//

        // Привязка к странице 3 при нажатии кнопки "Назад"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page3 p3 = new Page3();
            this.NavigationService.Navigate(p3);
        }

        //------------------------- Обработка конпки "Запись в XML" -------------------------//
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            WriteAnketBaseToXML();
        }

        //----------------------------------------------------------------------------//

        //-------------------- Проверка на содержимое базы ответов -------------------//
        private void CheckBase()
        {

            if (WorkBase.anket_base.ContainsKey(20))
            {
                if (WorkBase.anket_base[20] == "Отлично") { cb_answer1_1.IsChecked = true; }
                if (WorkBase.anket_base[20] == "Хорошо") { cb_answer1_2.IsChecked = true; }
                if (WorkBase.anket_base[20] == "Удовлетворительно") { cb_answer1_3.IsChecked = true; }
                if (WorkBase.anket_base[20] == "Плохо") { cb_answer1_4.IsChecked = true; }
            }

            if (WorkBase.anket_base.ContainsKey(21))
            {
                sl_answer2_1.Value = Convert.ToDouble(WorkBase.anket_base[21]);
            }

            if (WorkBase.anket_base.ContainsKey(22))
            {
                if (WorkBase.anket_base[22] == "Зрительный образ") { cb_answer3_1.IsChecked = true; }
                if (WorkBase.anket_base[22] == "Мышечное чувство") { cb_answer3_2.IsChecked = true; }
            }

        }

        //------------------------ Запись ответов в XML ---------------------------------//

        private void WriteAnketBaseToXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(item[]),
            new XmlRootAttribute() { ElementName = "items" });

            using (FileStream fs = new FileStream("anket_answers.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,
                WorkBase.anket_base.Select(kv => new item() { id = kv.Key, value = kv.Value }).ToArray());
            }
        }
        //----------------------------------------------------------------------------//

    }
}
