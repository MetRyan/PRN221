using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
using System.Windows;

namespace FUMINUHOTELSYSTEM
{
    /// <summary>
    /// Interaction logic for CustomeWindows.xaml
    /// </summary>
    public partial class CustomeWindows : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly Customer _customer;

        public CustomeWindows(IUnitOfWork unitOfWork, IServiceProvider serviceProvider, Customer customer)
        {
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;
            _customer = customer;
            InitializeComponent();
            DataContext = _customer;
        }

    }
}
