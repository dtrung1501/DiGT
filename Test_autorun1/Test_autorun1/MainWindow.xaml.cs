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

namespace Test_autorun1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int fovCount = 0;
        private int smdCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        //Thêm FOV 
        private void AddFOV_Click(object sender, RoutedEventArgs e)
        {
            fovCount++;
            TreeViewItem newFOV = new TreeViewItem { Header = $"FOV {fovCount}"};
            TrvNavigation.Items.Add(newFOV);
        }
        //Thêm SMD
        private void AddSMD_Click(object sender, RoutedEventArgs e)
        {
            if (TrvNavigation.SelectedItem is TreeViewItem selectedFOV && selectedFOV.Header.ToString().StartsWith("FOV"))
            {
                smdCount++;
                TreeViewItem newSMD = new TreeViewItem { Header = $"SMD {smdCount}"};
                selectedFOV.Items.Add(newSMD);
                selectedFOV.IsExpanded = true;
            }
            else
            {
                MessageBox.Show("Please select a FOV to add SMD.");
            }
        }

        private void RMove_Click(object sender, RoutedEventArgs e)
        {
            if (TrvNavigation.SelectedItem is TreeViewItem selectedItem)
            {
                if (selectedItem.Parent is TreeViewItem parentFOV)
                {
                    parentFOV.Items.Remove(selectedItem); // Remove SMD from FOV
                }
                else
                {
                    TrvNavigation.Items.Remove(selectedItem); // Remove FOV
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void TrvNavigation_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TrvNavigation.SelectedItem is TreeViewItem selectedItem)
            {
                GridLayer1.Children.Clear();
                TextBlock boardInfo = new TextBlock
                {
                    Text = $"Selected: {selectedItem.Header}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                GridLayer1.Children.Add(boardInfo);
            }
        }

        private void TrvNavigation_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TrvNavigation.SelectedItem is TreeViewItem selectedItem)
            {
                GridLayer2.Children.Clear();
                TextBlock detailInfo = new TextBlock
                {
                    Text = $"Details of {selectedItem.Header}",
                    FontSize = 14,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                GridLayer2.Children.Add(detailInfo);
            }
        }
    }
}
