using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Desktop_01_EG_2020_3943
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        public ObservableCollection<Student> Students { get; set; }

        public AddStudentWindowVM(ObservableCollection<Student> students)
        {
            Students = students;
        }
    }
}
