using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Desktop_01_EG_2020_3943
{
    public partial class CollectionWindowVM : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;
        //public Student selectedStudent;
        public ICommand CloseCommand { get; set; }
        public CollectionWindowVM()
        {
            students = new ObservableCollection<Student>();
            
            BitmapImage image1 = new BitmapImage(new Uri("/Icons/12.png", UriKind.Relative));
            students.Add(new Student("Anna", "Watson", "2000/05/22", 23, 3.122, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Icons/11.jpg", UriKind.Relative));
            students.Add(new Student("Jack", "Bill", "2001/04/04", 22, 3.882, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Icons/13.jpg", UriKind.Relative));
            students.Add(new Student("Sue", "Black", "2001/01/04", 22, 2.999, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Icons/14.jpg", UriKind.Relative));
            students.Add(new Student("Lian", "Grey", "2000/02/06", 23, 3.001, image4));
            BitmapImage image5 = new BitmapImage(new Uri("/Icons/16.jpg", UriKind.Relative));
            students.Add(new Student("Edd", "Brown", "1999/03/08", 24, 2.456, image5));
            BitmapImage image6 = new BitmapImage(new Uri("/Icons/15.png", UriKind.Relative));
            students.Add(new Student("Ert", "Johnes", "2000/04/09", 23, 3.815, image6));
            BitmapImage image7 = new BitmapImage(new Uri("/Icons/17.jpg", UriKind.Relative));
            students.Add(new Student("Zindy", "Bakens", "2000/06/11", 23, 3.994, image7));
            BitmapImage image8 = new BitmapImage(new Uri("/Icons/18.png", UriKind.Relative));
            students.Add(new Student("Windy", "Sophie", "2000/07/15", 23, 2.005, image8));
            BitmapImage image9 = new BitmapImage(new Uri("/Icons/19.jpg", UriKind.Relative));
            students.Add(new Student("Shad", "Jacklin", "2000/08/16", 23, 2.569, image9));
            BitmapImage image10 = new BitmapImage(new Uri("/Icons/20.jpg", UriKind.Relative));
            students.Add(new Student("Ilu", "Every", "2001/09/19", 22, 2.785, image10));
            
            //BitmapImage image1 = new BitmapImage(new Uri("pack://application:,,,/Icons/1.png"));
/*
            BitmapImage image1 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Anna", "Watson", "2000/05/22", 23, 3.122, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Jack", "Bill", "2001/04/04", 22, 3.882, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Sue", "Black", "2001/01/04", 22, 2.999, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Lian", "Grey", "2000/02/06", 23, 3.001, image4));
            BitmapImage image5 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Edd", "Brown", "1999/03/08", 24, 2.456, image5));
            BitmapImage image6 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Ert", "Johnes", "2000/04/09", 23, 3.815, image6));
            BitmapImage image7 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Zindy", "Bakens", "2000/06/11", 23, 3.994, image7));
            BitmapImage image8 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Windy", "Sophie", "2000/07/15", 23, 2.005, image8));
            BitmapImage image9 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Shad", "Jacklin", "2000/08/16", 23, 2.569, image9));
            BitmapImage image10 = new BitmapImage(new Uri("/Icons/1.png"));
            students.Add(new Student("Ilu", "Every", "2001/09/19", 22, 2.785, image10));  8*/
            CloseCommand = new RelayCommand(CloseWindow);
        }
        

        [RelayCommand]
        public void Add()
        {
            var newstudent = new AddVM();
            AddStudentWindow window2 = new AddStudentWindow(newstudent);
            window2.ShowDialog();

            if (newstudent.Addstudent.FirstName != null)
            {
                students.Add(newstudent.Addstudent);
            }
            /*else
            {
                MessageBox.Show("dscaesdcc");
            }*/
            //var person = new Student("Anna", "Watson", "2000/05/22", 23, 3.122, "1.png");
            //Students.Add(person);  // This is a predefined function
        
        }
        [RelayCommand]
        public void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void Edit()
        {
             if(selectedStudent != null)
             {
                var existingStudent = new AddVM(selectedStudent);
                var window3 = new AddStudentWindow(existingStudent);
                window3.ShowDialog();
                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, existingStudent.Addstudent);
             }

             else
             {
                MessageBox.Show("Please select the student");

             }
        }

        [RelayCommand]
        public void Delete()
        {
            if(selectedStudent != null)
            {
                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                MessageBox.Show("Successfully deleted the student!");

            }

            else
            {
                MessageBox.Show("Please select a student");
            }
        }
    }
}
