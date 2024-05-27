using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
using FUMiniHotelSystemClassLib.Repository;
using Microsoft.Extensions.Configuration;
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
using FUMiniHotelSystemClassLib.Model;
namespace FUMINUHOTELSYSTEM
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {/*
        private readonly IConfiguration _configuration;

        public static IUnitOfWork _UnitOfWork { get; set; }

        public static IServiceProvider _ServiceProvider { get; set; }


        public LoginPage(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            InitializeComponent();

*/
        /*}*/
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        public readonly IUnitOfWork _unitOfWork;


        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; set; }
        public static IUnitOfWork UnitOfWork { get; set; }

        public LoginPage()
        {
            _serviceProvider = ServiceProvider;
            _configuration = Configuration;
            _unitOfWork = UnitOfWork;

            if (_serviceProvider == null)
            {
                throw new InvalidOperationException("Service provider is not initialized.");
            }

            InitializeComponent();
        }

        public LoginPage(IServiceProvider serviceProvider, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _serviceProvider = serviceProvider;
            ServiceProvider = serviceProvider;
            _configuration = configuration;
            Configuration = configuration;
            _unitOfWork = unitOfWork;
            UnitOfWork = unitOfWork;
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbEmail.Text;
            string password = tbPassword.Text;

            if (username.Equals(_configuration["Account:Email"]) && password.Equals(_configuration["Account:Password"]))
            {
                var bookingDetailWindow = _serviceProvider.GetRequiredService<BookingDetailsWindows>();
                bookingDetailWindow.Show();
                this.Close();
            }
            else
            {
                var customerRepository = UnitOfWork.GetCustomersRepository();

                var user = customerRepository.verifiedMember(new() {EmailAddress = username , Password=password });
                if (user != null)
                {
                    // login as customer
                    var customerProfileWindow = new CustomeWindows(_unitOfWork,ServiceProvider,user);
                    customerProfileWindow.Show();
                    this.Close();
                }
                else
                {
                    // Login failed, show an error message
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
