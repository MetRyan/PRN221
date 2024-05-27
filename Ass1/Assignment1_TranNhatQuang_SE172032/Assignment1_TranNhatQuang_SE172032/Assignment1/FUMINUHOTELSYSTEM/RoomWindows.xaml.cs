using FUMiniHotelSystemClassLib.IRepository;
using FUMiniHotelSystemClassLib.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RoomWindows.xaml
    /// </summary>
    public partial class RoomWindows : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;

        public RoomWindows
            (IUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadData();
        }
        private async void LoadData()
        {
            lvRoomInformation.ItemsSource = (await _unitOfWork.GetRoomInformationRepository().GetAllWithDetailAsync())
                .Where(x => x.RoomStatus== 1);
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvRoomInformation.SelectedItem is RoomInformation selectedRoom)
            {
                selectedRoom.RoomNumber = txtRoomNumber.Text;
                selectedRoom.RoomDetailDescription = txtRoomDetailDescription.Text;
                selectedRoom.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                selectedRoom.RoomTypeId = (await _unitOfWork.GetRoomTypesRepository().GetAllAsync())
                    .FirstOrDefault(r => r.RoomTypeName.Equals(txtRoomType.Text)).RoomTypeId;
                selectedRoom.RoomPricePerDay = int.Parse(txtRoomPricePerDay.Text);

                _unitOfWork.GetRoomInformationRepository().Update(selectedRoom);
                await _unitOfWork.SaveChangesAsync();
                LoadData(); // Refresh the list
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Room?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (lvRoomInformation.SelectedItem is RoomInformation selectedRoom && result == MessageBoxResult.Yes)
            {
                selectedRoom.RoomStatus = 0;
                _unitOfWork.GetRoomInformationRepository().Update(selectedRoom);
                await _unitOfWork.SaveChangesAsync();
                LoadData(); // Refresh the list
            }
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (lvRoomInformation.SelectedItem is RoomInformation selectedRoom)
            {
                selectedRoom.RoomNumber = txtRoomNumber.Text;
                selectedRoom.RoomDetailDescription = txtRoomDetailDescription.Text;
                selectedRoom.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                selectedRoom.RoomTypeId = (await _unitOfWork.GetRoomTypesRepository().GetAllAsync())
                    .FirstOrDefault(r => r.RoomTypeName.Equals(txtRoomType.Text)).RoomTypeId;
                selectedRoom.RoomPricePerDay = int.Parse(txtRoomPricePerDay.Text);

                _unitOfWork.GetRoomInformationRepository().Update(selectedRoom);
                await _unitOfWork.SaveChangesAsync();
                LoadData(); // Refresh the list
            }
    }
        private void NumberOnlyTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void NumberOnlyTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); // Regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
        //    var customerWindow = _serviceProvider.GetRequiredService<CustomerWindow>();
           // customerWindow.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
          //  var bookingDetailWindow = _serviceProvider.GetRequiredService<BookingDetailWindow>();
         //   bookingDetailWindow.Show();
            this.Close();
        }
    }
}
