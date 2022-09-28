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

namespace Time
{
    public class Times : IEquatable<Times>
    {
        public int TimeSpan { get; set; }

        public int Durations { get; set; }

        public override string ToString()
        {
            return TimeSpan.ToString();
        }
        public bool Equals(Times other)
        {
            if (other == null) return false;
            return (this.TimeSpan.Equals(other.TimeSpan));
        }
    }

    public partial class MainWindow : Window
    {
        public List<Times> times = new List<Times>();

        public MainWindow()
        {
            InitializeComponent();

            DataGrid.ItemsSource = times;
        }

        private void TimeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ProcessBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshBTN_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = times.ToList();
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = DataGrid.SelectedItem;
                Core.DB.Entry(index).State = System.Data.Entity.EntityState.Added;
                Core.DB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось...");
            }
            DataGrid.ItemsSource = Core.DB.HockeyTeam.ToList();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = DataGrid.SelectedItem;
                Core.DB.Entry(index).State = System.Data.Entity.EntityState.Modified;
                Core.DB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось...");
            }
            DataGrid.ItemsSource = Core.DB.HockeyTeam.ToList();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = DataGrid.SelectedItem;
                Core.DB.Entry(index).State = System.Data.Entity.EntityState.Deleted;
                Core.DB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось...");
            }
            DataGrid.ItemsSource = Core.DB.HockeyTeam.ToList();
        }
    }
}
