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
    /// Логика взаимодействия для AuthorizatPage.xaml
    /// </summary>
    public partial class AuthorizatPage : Page
    {
        public AuthorizatPage()
        {
            InitializeComponent();
        }

        private void VxodButton_Click(object sender, RoutedEventArgs e)
        {
            LogimBox.Text = "akimovya";
            PasswordBox.Password = "bn069Caj";
            StringBuilder erors = new StringBuilder();
            if(PasswordBox.Password == "")
            {
                erors.AppendLine("Введите пароль");
            }
            if (LogimBox.Text == "")
            {
                erors.AppendLine("Введите логин");
            }

            if (erors.Length > 0)
            {
                MessageBox.Show(erors.ToString(), "Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Data.UserDataEntities1.GetContext().User.Any(d=> d.UserLogin == LogimBox.Text && d.UserPassword == PasswordBox.Password))
            {
                var searchRole = Data.UserDataEntities1.GetContext().User.Where(d => d.UserLogin == LogimBox.Text && d.UserPassword == PasswordBox.Password).FirstOrDefault();
                
                MessageBox.Show("Успех", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                string fh = searchRole.Role.RoleName;
                switch (searchRole.Role.RoleName)
                {
                    case "Администратор":
                        Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                        break;
                    case "Исполнитель":
                        Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                        break;
                    case "Менеджер":
                        Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователя не существует", "Errors", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
