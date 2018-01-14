using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Pizzawork.Infrastructure
{
    public class CommandablePushpin : Pushpin
    {
        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(CommandablePushpin),
                new PropertyMetadata(new SolidColorBrush(Colors.LightBlue)));

        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", typeof(Location), typeof(CommandablePushpin), new PropertyMetadata(null));

        public int? Id
        {
            get { return (int?)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int?), typeof(CommandablePushpin), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandablePushpin), new PropertyMetadata(null));

        public CommandablePushpin() : base()
        {
            MouseLeftButtonDown += CommandablePushpin_MouseLeftButtonDown;
        }

        private void CommandablePushpin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Command != null && Command.CanExecute(sender))
            {
                Command.Execute(sender);
            }
        }
    }
}

