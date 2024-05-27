using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
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

namespace FUMINUHOTELSYSTEM
{
    /// <summary>
    /// Interaction logic for CustomerWindows.xaml
    /// </summary>
    public partial class CustomerWindows : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly Customer _customer;

        public CustomerWindows(IUnitOfWork unitofwork, IServiceProvider serviceProvider, Customer customer)
        {
            InitializeComponent();
            _unitOfWork = unitofwork;
            _serviceProvider = serviceProvider;
            _customer = customer;
        }
    }
}
