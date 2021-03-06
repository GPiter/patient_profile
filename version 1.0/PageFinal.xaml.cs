﻿using System;
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
using MySql.Data.MySqlClient;

namespace patient_profile
{
    /// <summary>
    /// Логика взаимодействия для PageFinal.xaml
    /// </summary>
    public partial class PageFinal : Page
    {
        int slider_value; // Поле для хранения значения слайдера
		string sql;       // Запрос SQL

        // Параметры подключения к базе данных
        string connectString = " server    = localhost; "             +
                               " user      = root; "                  +
                               " database  = patient_profile_base; "  +
                               " password  = 2145635; ";

        public PageFinal()
        {
            InitializeComponent();
            CheckBase();                   // Проверка базы ответов на введенные данные
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
            XmlSerializer serializer = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "items" } );
            XmlSerializer serialize_notes = new XmlSerializer(typeof(Note[]), new XmlRootAttribute() { ElementName = "notes" });

            using (FileStream fs = new FileStream("anket_answers.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, WorkBase.anket_base.Select(kv => new item() { id = kv.Key, answer = kv.Value } ).ToArray());
                serialize_notes.Serialize(fs, WorkBase.answer_notes.Select(kv => new Note() { id = kv.Key, notes = kv.Value }).ToArray());
            }
            MessageBox.Show("Запись ответов в XML прошла успешно!");
        }

        //----------------------------------------------------------------------------//

		//------------------------ Запись ответов в базу данных MySQL ---------------------------------//
		private void WriteAnswersToSQL()
        {
            bool sql_request_isTrue;    // Флаг на наличие данных в поле таблицы "answer"

            try
            {
                MySqlConnection connection = new MySqlConnection(connectString);    // Создание подключения к БД MySQL

                connection.Open();

                for (int i = 1; i < WorkBase.anket_base.Count; i++)
                {
                    sql = "SELECT EXISTS(SELECT id FROM answer_base WHERE id = " + i + ")"; // Запрос, содержит ли поле в таблице БД значение
                    MySqlCommand cmd_take_request = new MySqlCommand(sql, connection);
                    sql_request_isTrue = Convert.ToBoolean(cmd_take_request.ExecuteScalar());

                    if (sql_request_isTrue)
                    {
                        sql = "UPDATE answer_base SET answer = '" + WorkBase.anket_base[i - 1] + "' WHERE id = " + i;   // Если значение в таблице есть, обновляем его
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        sql = "INSERT INTO answer_base (id, answer) VALUES(" + i + "," + WorkBase.anket_base[i - 1] + ")";  // Если значения в таблице нет, добавляем
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    
                }

                connection.Close();
                MessageBox.Show("Запись ответов в базу данных прошла успешно!");
            }

            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных!");
            }


        }

        //----------------------------------------------------------------------------//

        private void Btn_SendToSQL_Click(object sender, RoutedEventArgs e)
        {
            WriteAnswersToSQL();
        }

        //----------------------------------------------------------------------------//

    }
}
