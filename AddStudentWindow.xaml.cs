using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Desktop_01_EG_2020_3943
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    /// 
    
    public partial class AddStudentWindow : Window
    {
        
        public AddStudentWindow(AddVM newstudent)
        {

            InitializeComponent();
            DataContext = newstudent;
            newstudent.Close = () => Close();
            

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
