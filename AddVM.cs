using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
//using static System.Net.Mime.MediaTypeNames;

namespace Desktop_01_EG_2020_3943
{
    public partial class AddVM : ObservableObject, INotifyPropertyChanged
    {
        public Student Addstudent { get; private set; }
        public Action Close { get; set; }

        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public string dateOfBirth;
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public double gPAValue;
        private string _imagePath;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ImgURL))]
        //[NotifyPropertyChangedFor(nameof(SelectedImage))]
        public BitmapImage selectedImage;
        private BitmapImage _selectedImage;
        /*
        public BitmapImage SelectedImage
        {
            get 
            { 
                return _selectedImage; 
            }
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    OnPropertyChanged();
                }
            }
        }
        */
        

        public string ImgURL
        {
            get
            {
                return $"/Icons/{selectedImage}";
                //return Image.UriSource.AbsoluteUri;
                //return _imagePath;
            }
            set
            {
                if(_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public ICommand CloseWindowCommand1 { get; set; }
        public AddVM()
        {
            //CloseCommand = new RelayCommand(CloseWindow);
            //_imagePath = "Image Address";
            CloseWindowCommand1 = new RelayCommand(CloseWindow);
        }

        [RelayCommand]
        public void CloseWindow()
        {

            //Window.GetWindow(this).Close();
            //Window window = MainWindow(); //Window.GetWindow(this);
            //window.Close();
            Close.Invoke();
            //Close();
            //Application.Current.MainWindow.Show();
            //window.Show();

        }
        public AddVM(Student student1) 
        {
            Addstudent = student1;
            firstName= Addstudent.FirstName;  
            lastName= Addstudent.LastName;
            dateOfBirth= Addstudent.DateOfBirth;
            age= Addstudent.Age;
            gPAValue= Addstudent.GPAValue;
            selectedImage = Addstudent.Image;
            //imgURL = Addstudent.ImgURL;

        }

        [RelayCommand]
        public void Add()
        {
            if(Addstudent == null)
            {
                Addstudent = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Age = age,
                    GPAValue = gPAValue,
                    Image = selectedImage,
                    //ImgURL = imgURL
                    //ImgURL = "C:\\MyApp\\Icons",
                };
            }

            else
            {
                Addstudent.FirstName= firstName;
                Addstudent.LastName= lastName;
                Addstudent.DateOfBirth= dateOfBirth;
                Addstudent.Age= age;
                Addstudent.GPAValue= gPAValue;
                Addstudent.Image= selectedImage;
                //Addstudent.ImgURL = imgURL;
            }

            
            if(Addstudent.FirstName != null && Addstudent.LastName != null && Addstudent.DateOfBirth != null && Addstudent.Age != 0 && Addstudent.GPAValue != null)
            {
                if (Addstudent.GPAValue > 4 || Addstudent.GPAValue < 0)
                {
                    MessageBox.Show("GPA value must be between 0 and 4!", "Error");
                }

                else if(Addstudent.Age <= 0)
                {
                    MessageBox.Show("Enter correct Age!", "Error");
                }
                

                else
                {
                    MessageBox.Show("Information saved.", "Successful!");
                    Close();
                    //Close?.Invoke();
                }
                
                
            }

            else
            {
                MessageBox.Show("Enter all the details", "Incomplete information");
                
            }
            Application.Current.MainWindow.Show();
        }

        [RelayCommand]
        public void UploadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));
                //SelectedStudent.Image = new BitmapImage(new Uri(dialog.FileName));
                ImgURL = dialog.FileName;
                MessageBox.Show("Image uploaded!", "Successfull!");
                
            }

            
        }

    }
}
