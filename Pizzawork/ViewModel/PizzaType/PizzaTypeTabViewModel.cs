using Pizzawork.Infrastructure;
using Pizzawork.ViewModel.PizzaType;
using Pizzawork.Views.PizzaType;
using PizzaWork.BusinessLayer.Interfaces;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pizzawork.ViewModel
{
    class PizzaTypeTabViewModel : BaseViewModel
    {
        private string _connectionName;
        private IPizzaTypeService pizzaTypeService;
        private ObservableCollection<PizzaTypeViewModel> pizzaTypes;

        public ObservableCollection<PizzaTypeViewModel> PizzaTypes
        {
            get { return pizzaTypes; }
            private set
            {
                pizzaTypes = value;
                OnPropertyChanged();
            }
        }

        private PizzaTypeViewModel selectedType = null;

        public PizzaTypeViewModel SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; }
        }

        public PizzaTypeTabViewModel(string connectionName)
        {
            _connectionName = connectionName;
            this.pizzaTypeService = new PizzaTypeService(connectionName);
            pizzaTypes = pizzaTypeService.GetActivePizzaTypes();
        }

        private void UpdateTypes()
        {
            PizzaTypes = pizzaTypeService.GetActivePizzaTypes();
        }


        private ICommand deleteCommand = null;

        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteType,
            s => selectedType != null));

        private void DeleteType(object obj)
        {
            var res = MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.Cancel) return;
            pizzaTypeService.Delete(SelectedType.PizzaTypeId);
            UpdateTypes();
        }

        private ICommand addCommand = null;

        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddType));

        private void AddType(object obj)
        {
            var addDialogVM = new AddEditTypeDialogViewModel(null, _connectionName);
            var dialog = new AddEditTypeDialog(addDialogVM);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                try
                {
                    pizzaTypeService.Create(addDialogVM.Type);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка добавления бренда");
                }
                UpdateTypes();
            }
        }

        private ICommand editCommand = null;

        public ICommand EditCommand => editCommand ?? (editCommand = new RelayCommand(EditType, (o) => SelectedType != null));

        private void EditType(object obj)
        {
            var editDialogVM = new AddEditTypeDialogViewModel(SelectedType, _connectionName);
            var dialog = new AddEditTypeDialog(editDialogVM);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                try
                {
                    pizzaTypeService.Update(editDialogVM.Type);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка изменения бренда");

                }
                UpdateTypes();
            }
        }

        private ICommand chartCommand = null;
        public ICommand ChartCommand => chartCommand ?? (chartCommand = new RelayCommand(buildChart));

        private void buildChart(object obj)
        {
            UpdateTypes();
            var chartVM = new ChartVM(PizzaTypes);
            var dialog = new ChartDialog(chartVM);
            dialog.ShowDialog();
        }
    }
}
