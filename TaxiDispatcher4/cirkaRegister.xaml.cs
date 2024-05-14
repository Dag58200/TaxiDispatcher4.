using System;
using System.Windows;
using MySqlConnector;

namespace TaxiDispatcher4
{
    public partial class cirkaRegister : Window
    {
        private readonly string connectionString = "server=localhost;user=root;password=student;database=taxi";

        public cirkaRegister()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtCarNumber.Text))
            {
                MessageBox.Show("Please enter a name and car number.");
                return;
            }

            string name = txtName.Text;
            string carNumber = txtCarNumber.Text;
            string carClass = cboCarClass.SelectedItem.ToString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO taxi_drivers (name, car_number, car_class) VALUES (@name, @car_number, @car_class)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@car_number", carNumber);
                    command.Parameters.AddWithValue("@car_class", carClass);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Регистрация успешна Имя: {name}, Номер машины: {carNumber}, Тариф: {carClass}");
            Close();
        }
    }
}