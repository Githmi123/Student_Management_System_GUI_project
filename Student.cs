using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop_01_EG_2020_3943
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public double GPAValue { get; set; }
        public BitmapImage Image { get; set; }
        public string ImgURL
        {
            get
            {
                
                //return $"/Icons/{Image}";
                return Image.UriSource.AbsoluteUri;
            }
            set
            {
                
                // Set the value of ImgURL here if needed
            }

        }

        public Student(string firstName, string lastName, string dateOfBirth, int age, double gPAValue, BitmapImage image)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Age = age;
            GPAValue = gPAValue;
            Image = image;
        }
        public Student() 
        { 
        }
    }
}
