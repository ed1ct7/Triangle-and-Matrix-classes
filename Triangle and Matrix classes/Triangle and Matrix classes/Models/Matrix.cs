using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_and_Matrix_classes.Models
{
    public class MatrixElement : INotifyPropertyChanged
    {
        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Matrix
    {
        public static readonly ObservableCollection<string> Operations
            = new ObservableCollection<string>
            {
                "+", "-", "*", "compare"
            };

        public Matrix()
        {
            MatrixElements = new ObservableCollection<MatrixElement>();
        }

        public Matrix(ObservableCollection<MatrixElement> matrixElements)
        {
            this.MatrixElements = matrixElements;
        }

        private int _size = 2;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private ObservableCollection<MatrixElement> _matrixElements;
        public ObservableCollection<MatrixElement> MatrixElements
        {
            get { return _matrixElements; }
            set { _matrixElements = value; }
        }

        // Проверка, является ли матрица верхнетреугольной
        public bool IsUpperTriangular()
        {
            for (int i = 1; i < Size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (GetElement(i, j) != 0)
                        return false;
                }
            }
            return true;
        }

        // Проверка, является ли матрица нижнетреугольной
        public bool IsLowerTriangular()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    if (GetElement(i, j) != 0)
                        return false;
                }
            }
            return true;
        }

        // Сложение матриц
        public Matrix Summation(Matrix other)
        {
            if (Size != other.Size)
                throw new ArgumentException("Матрицы должны быть одного размера");

            var result = new Matrix();
            result.Size = Size;
            result.MatrixElements = new ObservableCollection<MatrixElement>();

            for (int i = 0; i < Size * Size; i++)
            {
                result.MatrixElements.Add(new MatrixElement
                {
                    Value = this.MatrixElements[i].Value + other.MatrixElements[i].Value
                });
            }

            return result;
        }

        // Вычитание матриц
        public Matrix Subtraction(Matrix other)
        {
            if (Size != other.Size)
                throw new ArgumentException("Матрицы должны быть одного размера");

            var result = new Matrix();
            result.Size = Size;
            result.MatrixElements = new ObservableCollection<MatrixElement>();

            for (int i = 0; i < Size * Size; i++)
            {
                result.MatrixElements.Add(new MatrixElement
                {
                    Value = this.MatrixElements[i].Value - other.MatrixElements[i].Value
                });
            }

            return result;
        }

        // Умножение матриц
        public Matrix Multiplication(Matrix other)
        {
            if (Size != other.Size)
                throw new ArgumentException("Матрицы должны быть одного размера");

            var result = new Matrix();
            result.Size = Size;
            result.MatrixElements = new ObservableCollection<MatrixElement>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Size; k++)
                    {
                        sum += GetElement(i, k) * other.GetElement(k, j);
                    }
                    result.MatrixElements.Add(new MatrixElement { Value = sum });
                }
            }

            return result;
        }

        // Умножение матрицы на число
        public Matrix Multiplication(double number)
        {
            var result = new Matrix();
            result.Size = Size;
            result.MatrixElements = new ObservableCollection<MatrixElement>();

            for (int i = 0; i < Size * Size; i++)
            {
                result.MatrixElements.Add(new MatrixElement
                {
                    Value = this.MatrixElements[i].Value * number
                });
            }

            return result;
        }

        // Сравнение матриц
        public bool Compare(Matrix other)
        {
            if (Size != other.Size)
                return false;

            for (int i = 0; i < Size * Size; i++)
            {
                if (Math.Abs(this.MatrixElements[i].Value - other.MatrixElements[i].Value) > 0.0001)
                    return false;
            }

            return true;
        }

        // Вспомогательный метод для получения элемента по индексам
        private double GetElement(int row, int col)
        {
            return MatrixElements[row * Size + col].Value;
        }

        // Вспомогательный метод для установки элемента по индексам
        private void SetElement(int row, int col, double value)
        {
            MatrixElements[row * Size + col].Value = value;
        }
    }
}