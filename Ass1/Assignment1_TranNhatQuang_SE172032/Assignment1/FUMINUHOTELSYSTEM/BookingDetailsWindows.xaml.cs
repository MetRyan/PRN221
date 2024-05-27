using FUMiniHotelSystemClassLib.IRepository;
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

namespace FUMINUHOTELSYSTEM
{
    /// <summary>
    /// Interaction logic for BookingDetails.xaml
    /// </summary>
    public partial class BookingDetailsWindows : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private static DateTime startDate = DateTime.Now;
        private static DateTime endDate = DateTime.Now;

        public BookingDetailsWindows(IUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadData();
        }
        private async void LoadData()
        {
            lvBookingDetail.ItemsSource = (await _unitOfWork.GetBookingDetailsRepository().GetAllWithDetailAsync())
                .Where(b => b.StartDate.CompareTo(endDate) < 0 || b.EndDate.CompareTo(startDate) > 0)
                .OrderByDescending(b => b.StartDate)
                .ThenByDescending(b => b.EndDate);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            startDate = DateTime.Parse(txtStartDate.Text);
            endDate = DateTime.Parse(txtEndDate.Text);
            LoadData();
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            var roomWindow = _serviceProvider.GetRequiredService<RoomWindows>();
            roomWindow.Show();
            this.Close();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customerWindow = _serviceProvider.GetRequiredService<CustomeWindows>();
            customerWindow.Show();
            this.Close();
        }
    }
}
