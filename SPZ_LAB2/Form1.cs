using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SPZ_LAB2
{
    public partial class Form1 : Form
    {
        static List<Class.University> universities = new List<Class.University>();
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            table.Columns.Add("Название", typeof(string));
            table.Columns.Add("Адрес", typeof(string));
            table.Columns.Add("Кол-во комнат", typeof(int));
            table.Columns.Add("Кол-во персонала", typeof(int));
            table.Columns.Add("Кол-во студентов", typeof(int));
            table.Columns.Add("Оплата за проживание", typeof(decimal));
            dataGridView1.DataSource = table;

        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            string university_name;
            string address;
            int number_of_rooms;
            int number_of_staff;
            int number_of_students;
            decimal payment_for_accommodation;
            bool error = false;
            
                if(!Regex.IsMatch(textBox_name.Text, @"^[а-яА-ЯA-za-z ]+$") || String.IsNullOrEmpty(textBox_name.Text))
                {
                    MessageBox.Show("Название университета не может содержать цифры или быть пустой!","Ошибка ввода",
                        MessageBoxButtons.OK);
                    textBox_name.Clear();
                    error = true;
                }
            
          
                if (String.IsNullOrEmpty(textBox_address.Text))
                {
                    MessageBox.Show("Строка адреса не может быть пустой!", "Ошибка ввода",
                        MessageBoxButtons.OK);  
                    error = true;
                    textBox_address.Clear(); 
                }

            if (!error)
            { 
            university_name = textBox_name.Text;
            address = textBox_address.Text;
            number_of_rooms = decimal.ToInt32(numericUpDown_rooms.Value);
            number_of_staff = decimal.ToInt32(numericUpDown_staff.Value);
            number_of_students = decimal.ToInt32(numericUpDown_students.Value);
            payment_for_accommodation = numericUpDown_payment.Value;

            Class.University university = new Class.University(university_name, address, number_of_rooms,
                                    number_of_staff, number_of_students, payment_for_accommodation);
            universities.Add(university);
            
            textBox_name.Clear();
            textBox_address.Clear();
            numericUpDown_rooms.Value = numericUpDown_rooms.Minimum;
            numericUpDown_staff.Value = numericUpDown_staff.Minimum;
            numericUpDown_students.Value = numericUpDown_students.Minimum;
            numericUpDown_payment.Value = numericUpDown_payment.Minimum;
            }
        }

        private void button_income_month_Click(object sender, EventArgs e)
        {
            if(universities.Count>0)
            { 
            textBox_income.Text = universities[universities.Count - 1].IncomeMonth().ToString();
            }
        }

        private void button_income_half_year_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                textBox_income.Text = universities[universities.Count - 1].IncomeHalfAYear().ToString();
            }
        }

        private void button_income_year_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                textBox_income.Text = universities[universities.Count - 1].IncomeYear().ToString();
            }
        }

        private void button_increase_room_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                universities[universities.Count - 1].Increase_room(decimal.ToInt32(numericUpDown_increase.Value));  
            }
            numericUpDown_increase.Value = numericUpDown_increase.Minimum;
        }

        private void button_settling_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                universities[universities.Count - 1].Settling(decimal.ToInt32(numericUpDown_settling.Value));  
            }
            numericUpDown_settling.Value = numericUpDown_settling.Minimum;
        }

        private void button_eviction_Click(object sender, EventArgs e)
        {

            if (universities.Count > 0 && numericUpDown_eviction.Value < universities[universities.Count - 1].Number_of_students)
            {
                universities[universities.Count - 1].Eviction(decimal.ToInt32(numericUpDown_eviction.Value));      
            }
            else MessageBox.Show("Причина ошибки может быть:\n1)Нет ни одного университета, чтобы выселить студентов," +
                "\n2)Количество студентов для выселения превышает количество существующих студентов!", "Ошибка",
                 MessageBoxButtons.OK);
            numericUpDown_eviction.Value = numericUpDown_eviction.Minimum;
        }

        private void button_canteen_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                universities[universities.Count - 1].Income_with_canteen();
            }
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            if (universities.Count > 0)
            {
                Class.University university = (Class.University)universities[universities.Count - 1].Clone();
                universities.Add(university);
            }
            else MessageBox.Show("Нет ни одного университета, чтобы сделать копию!", "Ошибка",
                       MessageBoxButtons.OK);

        }

        private void button_display_Click(object sender, EventArgs e)
        {
            table.Clear();

            for (int i = 0; i < universities.Count; i++)
            { 
                table.Rows.Add(universities[i].University_name,
                    universities[i].Address, universities[i].Number_of_rooms, universities[i].Number_of_staff,
                    universities[i].Number_of_students, universities[i].Payment_for_accommodation);     
            }
            dataGridView1.DataSource = table;
            
        }
    }
}
