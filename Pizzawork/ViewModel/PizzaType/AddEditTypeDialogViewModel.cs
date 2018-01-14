using PizzaWork.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Services;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Pizzawork.ViewModel
{
    public class AddEditTypeDialogViewModel : BaseViewModel
    {
        private PizzaTypeViewModel _type = null;

        public PizzaTypeViewModel Type
        {
            get => _type ?? (_type = new PizzaTypeViewModel());
            set => _type = value;
        }

        private string selectedTrademark;

        public string SelectedTrademark
        {
            get { return selectedTrademark; }
            set
            {
                selectedTrademark = value;
                OnPropertyChanged();
            }
        }

        public string TypedTrademark { get; set; }


        public IEnumerable<string> Trademarks { get; set; }

        public AddEditTypeDialogViewModel(PizzaTypeViewModel type, string connectionName)
        {
            Trademarks = new PizzaTypeService(connectionName).GetActivePizzaTypes().Select(t => t.Trademark);
            TypedTrademark = type?.Trademark;
            Type = type;
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, o => !Type.HasErrors));

        private void Ok(object parameter)
        {
            Type.Trademark = SelectedTrademark ?? TypedTrademark;
            if (parameter is Window dialogWindow)
            {
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }

        private ICommand selectImageCommand = null;
        public ICommand SelectImageCommand => selectImageCommand ?? (selectImageCommand = new RelayCommand(SelectImage));
        private void SelectImage(object obj)
        {
            OpenFileDialog ofn = new OpenFileDialog();
            ofn.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "images");
            ofn.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
            ofn.Multiselect = false;
            if (ofn.ShowDialog() != false)
            {
                var myUniqueFileName = $@"{DateTime.Now.Ticks}{Path.GetExtension(ofn.FileName)}";
                File.Copy(ofn.FileName, Path.Combine(Directory.GetCurrentDirectory(), "images", myUniqueFileName));
                Type.ImageLink = myUniqueFileName;
            }
        }
    }
}
