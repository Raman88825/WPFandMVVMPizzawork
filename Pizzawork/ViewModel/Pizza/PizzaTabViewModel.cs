using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Services;
using PizzaWork.BusinessLayer.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using System.Windows;
using PizzaWork.BusinessLayer.Interfaces;
using Pizzawork.Views.Pizza;
using System.Xml.Serialization;
using System.IO;

namespace Pizzawork.ViewModel
{
    public class PizzaTabViewModel : BaseViewModel
    {
        private string _connectionName;
        private IPizzaService pizzaService;

        private ObservableCollection<PizzaViewModel> pizzas;
        public ObservableCollection<PizzaViewModel> Pizzas
        {
            get { return pizzas; }
            private set
            {
                pizzas = value;
                OnPropertyChanged();
            }
        }

        private PizzaViewModel selectedPizza = null;

        public PizzaViewModel SelectedPizza
        {
            get { return selectedPizza; }
            set { selectedPizza = value; }
        }

        private void RefreshPizzas()
        {
            Pizzas = pizzaService.GetActivePizzas();
        }

        public PizzaTabViewModel(string connectionName)
        {
            _connectionName = connectionName;
            this.pizzaService = new PizzaService(connectionName);
            pizzas = pizzaService.GetActivePizzas();
        }

        private ICommand deletePizzaCommand = null;

        public ICommand DeletePizzaCommand => deletePizzaCommand ?? (deletePizzaCommand = new RelayCommand(DeletePizza,
            s => selectedPizza != null));

        private void DeletePizza(object obj)
        {
            var res = MessageBox.Show("Вы уверены?", "Удаление пиццы", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.Cancel) return;
            pizzaService.Delete(SelectedPizza.PizzaId);
            RefreshPizzas();
        }

        private ICommand addPizzaCommand = null;

        public ICommand AddPizzaCommand => addPizzaCommand ?? (addPizzaCommand = new RelayCommand(AddPizza));

        private void AddPizza(object obj)
        {
            var addDialogVM = new AddEditPizzaDialogViewModel(null, _connectionName);
            var dialog = new AddEditPizzaDialog(addDialogVM);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                try
                {
                    addDialogVM.Pizza.PizzaTypeId = addDialogVM.SelectedPizzaType.PizzaTypeId;
                    new PizzaService(_connectionName).Create(addDialogVM.Pizza);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка добавления пиццы");
                }
                RefreshPizzas();
            }
        }

        private ICommand editCommand = null;

        public ICommand EditCommand => editCommand ?? (editCommand = new RelayCommand(EditPizza, (o) => SelectedPizza != null));

        private void EditPizza(object obj)
        {
            var editDialogVM = new AddEditPizzaDialogViewModel(SelectedPizza, _connectionName);
            var dialog = new AddEditPizzaDialog(editDialogVM);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                //Set null to avoid changes conflict
                editDialogVM.Pizza.PizzaType = null;
                editDialogVM.Pizza.Spot = null;
                try
                {
                    new PizzaService(_connectionName).Update(editDialogVM.Pizza);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка изменения пиццы");

                }
                RefreshPizzas();
            }
        }

        private ICommand exportCommand = null;

        public ICommand ExportCommand => exportCommand ?? (exportCommand = new RelayCommand(Export));

        private void Export(object obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<PizzaViewModel>));
            FileStream fs;
            using (fs = new FileStream("export.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xs.Serialize(fs, Pizzas);
            }
            MessageBox.Show("Сохранено в файл export.dat");
        }

        private ICommand importCommand = null;

        public ICommand ImportCommand => importCommand ?? (importCommand = new RelayCommand(Import));

        private void Import(object obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<PizzaViewModel>));
            FileStream fs;
            IEnumerable<PizzaViewModel> list;
            using (fs = new FileStream("export.dat", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                list = (IEnumerable<PizzaViewModel>)xs.Deserialize(fs);
            }
            foreach (var pizza in list)
            {
                try
                {
                    pizzaService.Create(pizza);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка импорта пиццы");
                }
            }
            RefreshPizzas();
        }
    }
}
