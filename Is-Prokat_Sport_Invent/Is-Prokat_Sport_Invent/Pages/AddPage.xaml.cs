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

namespace Is_Prokat_Sport_Invent.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public Data.User _addUser = new Data.User();
        public AddPage()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            RoleBox.ItemsSource = Data.UserDataEntities1.GetContext().Role.ToList();
            GenderBox.ItemsSource = Data.UserDataEntities1.GetContext().Gender.ToList();
            IdBox.Text = Data.UserDataEntities1.GetContext().User.Max(d => d.UserId).ToString();
        }

        private void AddUser_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                StringBuilder error = new StringBuilder();
                if(LastNameBox.Text == "")
                {
                    error.AppendLine("Введите Фамилию");
                }
                if (NameBox.Text == "")
                {
                    error.AppendLine("Введите Имя");
                }
                if (PatronicBox.Text == "")
                {
                    error.AppendLine("Введите Отчество");
                }

                if (RoleBox.SelectedIndex + 1 ==0)
                {
                    error.AppendLine("Выберите Должность");
                }

                if (Phonbeox.Text == "")
                {
                    error.AppendLine("Введите Телефон");
                }

                if (GenderBox.SelectedIndex + 1 == 0)
                {
                    error.AppendLine("Выберите Пол");
                }


                if (emailbox.Text == "")
                {
                    error.AppendLine("Введите Почту");
                }

                if (Loginbox.Text == "")
                {
                    error.AppendLine("Введите Логин");
                }

                if (Passwordbox1.Text == "")
                {
                    error.AppendLine("Введите Пароль");
                }

                if (Passwordbox2.Text == "")
                {
                    error.AppendLine("Повторите Пароль");
                }

                if(Passwordbox1.Text != Passwordbox2.Text)
                {
                    error.AppendLine("Пароли не совпадают");
                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _addUser.UserLastName = LastNameBox.Text;
                _addUser.UserName = NameBox.Text;
                _addUser.UserFirstName = PatronicBox.Text;

                int intRole = RoleBox.SelectedIndex + 1;
                var searchrole = Data.UserDataEntities1.GetContext().Role.Where(d => d.RoleId == intRole).FirstOrDefault();
                _addUser.UserRoleId = searchrole.RoleId;

               
                _addUser.UserPhone = Phonbeox.Text;

                _addUser.UserGenderId = RoleBox.SelectedIndex + 1;

                _addUser.UserEmail = emailbox.Text;
                _addUser.UserLogin = Loginbox.Text;
                _addUser.UserPassword = Passwordbox1.Text;

                Data.UserDataEntities1.GetContext().User.Add(_addUser);
                Data.UserDataEntities1.GetContext().SaveChanges();
                MessageBox.Show("Добавлено", "Успех",MessageBoxButton.OK,MessageBoxImage.Information);
                Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "dsf");
            }
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
        }
    }
}
