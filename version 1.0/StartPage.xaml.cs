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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    /// 


    public partial class StartPage : Page
    {

        public StartPage()
        {
            InitializeComponent();
            CheckPatient();
        }

        //------------------------- Обработка конпки "Далее" -------------------------//

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Page1 p1 = new Page1();
            this.NavigationService.Navigate(p1);
        }

        //----------------------------------------------------------------------------//

        //--------------------- Обработка идентификатора пациента --------------------//

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Patient.identifier = txtbox_Identifier.Text;
        }

        //----------------------------------------------------------------------------//

        //------------------------- Обработка номера визита --------------------------//  
        
        private void Txtbox_Number_visit_TextChanged(object sender, TextChangedEventArgs e)
        {
            Patient.visit_number = txtbox_Number_visit.Text;
        }

        //----------------------------------------------------------------------------//

        //-------------------------- Обработка даты визита ---------------------------//  

        private void Dp_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime ? selectedDate = dp_calendar.SelectedDate;
            Patient.visit_date = selectedDate.Value.Date.ToShortDateString();
        }

        //----------------------------------------------------------------------------//

        //------------------------- Привязка данных к форме -------------------------//

        private void CheckPatient()
        {
            txtbox_Identifier.Text = Patient.identifier;
            dp_calendar.SelectedDate = Convert.ToDateTime(Patient.visit_date);
            txtbox_Number_visit.Text = Patient.visit_number;
        }

        //----------------------------------------------------------------------------//
    }

}
