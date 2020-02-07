using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TIMEFRAME_windows.VIEWS
{
    /// <summary>
    /// Interaction logic for V_Main.xaml
    /// </summary>
    public partial class V_Main : Window
    {
        // Local variables
        private static BrushConverter bc = new BrushConverter();
        private Brush highlightColor_SecondMenu = (Brush)bc.ConvertFrom("#FF3FC1C9");
        private Brush highlightColor_Transparent = new SolidColorBrush(Colors.Transparent);

        private static double OrigHeight = 0.0;

        // CONSTRUCTOR
        public V_Main()
        {
            InitializeComponent();
        }

        private void StackPanel_Config_Customer_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Customer.Background = highlightColor_SecondMenu;
        }

        private void StackPanel_Config_Customer_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Customer.Background = highlightColor_Transparent;
        }

        private void StackPanel_Config_Project_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Project.Background = highlightColor_SecondMenu;
        }

        private void StackPanel_Config_Project_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Project.Background = highlightColor_Transparent;
        }

        private void StackPanel_Config_Task_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Task.Background = highlightColor_SecondMenu;
        }

        private void StackPanel_Config_Task_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel_Config_Task.Background = highlightColor_Transparent;
        }

        private void StackPanel_Config_TimeEntry_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel_Config_TimeEntry.Background = highlightColor_SecondMenu;
        }

        private void StackPanel_Config_TimeEntry_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel_Config_TimeEntry.Background = highlightColor_Transparent;
        }

        private void Img_Expand2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Grid_Content.Height > 0)
            {
                OrigHeight = Grid_Content.Height;
                Grid_Content.Height = 0;
                
                //Img_Expand2.Source = new BitmapImage(new Uri("pack://application:,,,/TIMEFRAME_windows;component/IMAGES/SortArrowDOWN_Black.png"));
            }
            else
            {
                Grid_Content.Height = OrigHeight;
                //Img_Expand2.Source = new BitmapImage(new Uri("pack://application:,,,/TIMEFRAME_windows;component/IMAGES/SortArrowUP_Black.png"));
            }
        }
    }
}
