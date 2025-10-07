using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Triangle_and_Matrix_classes.Models;

namespace Triangle_and_Matrix_classes.ViewModel
{
    public class MatrixViewModel : INotifyPropertyChanged
    {
        public MatrixViewModel()
        {
            Matrix = new Matrix();
        }
        private Matrix _matrix;
        public Matrix Matrix
        {
            get => _matrix;
            set
            {
                _matrix = value; 
                OnPropertyChanged();
            }
        }
        public int Size
        {
            get => Matrix.Size;
            set 
            { 
                Matrix.Size = value;
                OnPropertyChanged();
                //OnResize();
            }
        }
        public ObservableCollection<double> Elements
        {
            get => Matrix.MatrixElements;
            set
            {
                Matrix.MatrixElements = value;
                OnPropertyChanged();
            }
        }
        //public void OnResize()
        //{
        //    Elements.Add(Size);
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
