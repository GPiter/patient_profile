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

namespace patient_profile
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        int slider_value; // Поле для хранения значения слайдера

        public Page3()
        {
            InitializeComponent();
            CheckBase();
        }

        // Привязка к странице 2 при нажатии кнопки "Назад"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2();
            this.NavigationService.Navigate(p2);
        }

        //---------------------- Обработчик UpDown control -------------------------

        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        public void NumberUpDown()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
            {
                txtNum.Text = _numValue.ToString();
            }
            WorkBase.anket_base[9] = txtNum.Text;
        }

        //--------------------------------------------------------------------------------------------//


        //------------------------------ Обработка значений слайдеров --------------------------------//

        private void Sl_answer10_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer10.Value;
            WorkBase.anket_base[10] = slider_value.ToString();
        }

        private void Sl_answer11_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer11.Value;
            WorkBase.anket_base[11] = slider_value.ToString();
        }

        private void Sl_answer12_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer12.Value;
            WorkBase.anket_base[12] = slider_value.ToString();
        }

        private void Sl_answer13_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer13.Value;
            WorkBase.anket_base[13] = slider_value.ToString();
        }

        private void Sl_answer14_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer14.Value;
            WorkBase.anket_base[14] = slider_value.ToString();
        }

        private void Sl_answer15_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer15.Value;
            WorkBase.anket_base[15] = slider_value.ToString();
        }

        private void Sl_answer16_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer16.Value;
            WorkBase.anket_base[16] = slider_value.ToString();
        }

        private void Sl_answer18_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer18.Value;
            WorkBase.anket_base[18] = slider_value.ToString();
        }

        private void Sl_answer19_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider_value = (int)sl_answer19.Value;
            WorkBase.anket_base[19] = slider_value.ToString();
        }
        //--------------------------------------------------------------------------------------------//

        //------------------------------- Обработка радиобаттонов -----------------------------------//
        private void Cb_answer17_1_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[17] = cb_answer17_1.Content.ToString();
        }

        private void Cb_answer17_2_Checked(object sender, RoutedEventArgs e)
        {
            WorkBase.anket_base[17] = cb_answer17_1.Content.ToString();
        }

        //--------------------------------------------------------------------------------------------//

        //------------------------------ Обработка полей "Примечания" --------------------------------//
        private void Note_answer10_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[9] = note_answer10.Text;
        }

        private void Note_answer11_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[10] = note_answer11.Text;
        }

        private void Note_answer12_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[11] = note_answer12.Text;
        }

        private void Note_answer13_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[12] = note_answer13.Text;
        }

        private void Note_answer14_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[13] = note_answer14.Text;
        }

        private void Note_answer15_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[14] = note_answer15.Text;
        }

        private void Note_answer16_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[15] = note_answer16.Text;
        }

        private void Note_answer17_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[16] = note_answer17.Text;
        }

        private void Note_answer18_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[17] = note_answer18.Text;
        }

        private void Note_answer19_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[18] = note_answer19.Text;
        }

        private void Note_answer20_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkBase.answer_notes[19] = note_answer20.Text;
        }

        //-------------------------------------------------------------------------------------------//

        //---------------------------- Проверка на содержимое базы ответов ---------------------------//
        private void CheckBase()
        {
            // Проверка на заполнение ответов на вопросы
            if (WorkBase.anket_base.ContainsKey(9))
            {
                txtNum.Text = WorkBase.anket_base[9];
            }

            if (WorkBase.anket_base.ContainsKey(10))
            {
                sl_answer10.Value = Convert.ToDouble(WorkBase.anket_base[10]);
            }

            if (WorkBase.anket_base.ContainsKey(11))
            {
                sl_answer11.Value = Convert.ToDouble(WorkBase.anket_base[11]);
            }

            if (WorkBase.anket_base.ContainsKey(12))
            {
                sl_answer12.Value = Convert.ToDouble(WorkBase.anket_base[12]);
            }

            if (WorkBase.anket_base.ContainsKey(13))
            {
                sl_answer13.Value = Convert.ToDouble(WorkBase.anket_base[13]);
            }

            if (WorkBase.anket_base.ContainsKey(14))
            {
                sl_answer14.Value = Convert.ToDouble(WorkBase.anket_base[14]);
            }

            if (WorkBase.anket_base.ContainsKey(15))
            {
                sl_answer15.Value = Convert.ToDouble(WorkBase.anket_base[15]);
            }

            if (WorkBase.anket_base.ContainsKey(16))
            {
                sl_answer16.Value = Convert.ToDouble(WorkBase.anket_base[16]);
            }

            if (WorkBase.anket_base.ContainsKey(17))
            {
                if (WorkBase.anket_base[17] == "Да") { cb_answer17_1.IsChecked = true; }
                if (WorkBase.anket_base[17] == "Нет") { cb_answer17_2.IsChecked = true; }
            }

            if (WorkBase.anket_base.ContainsKey(18))
            {
                sl_answer18.Value = Convert.ToDouble(WorkBase.anket_base[18]);
            }

            if (WorkBase.anket_base.ContainsKey(19))
            {
                sl_answer19.Value = Convert.ToDouble(WorkBase.anket_base[19]);
            }

            // Проверка на заполнение примечаний
            if (WorkBase.answer_notes.ContainsKey(9))
            {
                note_answer10.Text = WorkBase.answer_notes[9];
            }

            if (WorkBase.answer_notes.ContainsKey(10))
            {
                note_answer11.Text = WorkBase.answer_notes[10];
            }

            if (WorkBase.answer_notes.ContainsKey(11))
            {
                note_answer12.Text = WorkBase.answer_notes[11];
            }

            if (WorkBase.answer_notes.ContainsKey(12))
            {
                note_answer13.Text = WorkBase.answer_notes[12];
            }

            if (WorkBase.answer_notes.ContainsKey(13))
            {
                note_answer14.Text = WorkBase.answer_notes[13];
            }

            if (WorkBase.answer_notes.ContainsKey(14))
            {
                note_answer15.Text = WorkBase.answer_notes[14];
            }

            if (WorkBase.answer_notes.ContainsKey(15))
            {
                note_answer16.Text = WorkBase.answer_notes[15];
            }

            if (WorkBase.answer_notes.ContainsKey(16))
            {
                note_answer17.Text = WorkBase.answer_notes[16];
            }

            if (WorkBase.answer_notes.ContainsKey(17))
            {
                note_answer18.Text = WorkBase.answer_notes[17];
            }

            if (WorkBase.answer_notes.ContainsKey(18))
            {
                note_answer19.Text = WorkBase.answer_notes[18];
            }

            if (WorkBase.answer_notes.ContainsKey(19))
            {
                note_answer20.Text = WorkBase.answer_notes[19];
            }

        }
        //----------------------------------------------------------------------------//

        private void BtnNext_p3_Click(object sender, RoutedEventArgs e)
        {
            PageFinal pF = new PageFinal();
            this.NavigationService.Navigate(pF);
        }

    }


}
