using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NLog;

namespace Pizzawork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Trace("Приложение закрыто");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Trace("Приложение запущено");
        }
    }
}
