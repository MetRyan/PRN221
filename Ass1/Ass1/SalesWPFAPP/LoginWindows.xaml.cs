using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;

namespace SalesWPFAPP
{
    /// <summary>
    /// Interaction logic for LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : Window
    {
       private readonly IMemberRepository _memberRepository;

  


        public LoginWindows(IMemberRepository repository)
        {
            _memberRepository = repository;
            InitializeComponent();


        }
        /*  public LoginWindows(IMemberRepository repository) : this()
          {
              memberRepository = repository;
          }*/

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var member = _memberRepository.verifyMember(new() { Email = txtEmail.Text, Password = txtPassword.Text });
            if (member != null)
            {
                var main = new MainWindows();
                main.Show();
                /*Close();*/
            }
            else
            {
                //lbError.Content = "Wrong email or password";
            }

        }
    }
}
