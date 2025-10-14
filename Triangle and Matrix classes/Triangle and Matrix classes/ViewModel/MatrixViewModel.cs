using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Triangle_and_Matrix_classes.Models;

namespace Triangle_and_Matrix_classes.ViewModel
{
    public class MatrixViewModel : INotifyPropertyChanged
    {
        public MatrixViewModel()
        {
            Matrix = new Matrix();
            MatrixAd = new Matrix();
            OnResize();
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

        private Matrix _matrixAd;
        public Matrix MatrixAd
        {
            get => _matrixAd;
            set
            {
                _matrixAd = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Operations
        {
            get { return Matrix.Operations; }
        }


        public int Size
        {
            get => Matrix.Size;
            set
            {
                Matrix.Size = value;
                MatrixAd.Size = value; // Не забудьте обновить размер второй матрицы!
                OnPropertyChanged();
                OnResize();
            }
        }

        public ObservableCollection<MatrixElement> Elements
        {
            get => Matrix.MatrixElements;
            set
            {
                Matrix.MatrixElements = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MatrixElement> ElementsAd
        {
            get => MatrixAd.MatrixElements;
            set
            {
                MatrixAd.MatrixElements = value;
                OnPropertyChanged();
            }
        }



        public void OnResize()
        {
            var newElements = new ObservableCollection<MatrixElement>();
            var newElementsAd = new ObservableCollection<MatrixElement>();

            for (int i = 0; i < Size * Size; i++)
            {
                newElements.Add(new MatrixElement());
                newElementsAd.Add(new MatrixElement());
            }

            Elements = newElements;
            ElementsAd = newElementsAd;

            OnPropertyChanged(nameof(Elements));
            OnPropertyChanged(nameof(ElementsAd));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}