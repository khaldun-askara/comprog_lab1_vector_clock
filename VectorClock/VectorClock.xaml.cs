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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace VectorClock
{
    public partial class VectorClock : UserControl
    {
        public Timer Timer = new Timer(1000);
        public VectorClock()
        {
            InitializeComponent();

            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
        }

        delegate void update();

        private void UpdateTime()
        {
            DateTime current_time = DateTime.Now;
            Hours.Angle = 30 * (current_time.Hour % 12) + current_time.Minute / 2;
            Minutes.Angle = 6 * current_time.Minute + (current_time.Second) / 10;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            update update_time = new update(UpdateTime);
            Dispatcher.Invoke(DispatcherPriority.Normal, update_time);
        }
    }
}
