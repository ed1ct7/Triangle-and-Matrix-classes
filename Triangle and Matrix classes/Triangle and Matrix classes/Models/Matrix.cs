using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//12.Создать класс квадратная матрица, поля класса – размерность и элементы матрицы. 
//Методы класса: проверка, является ли матрица верхнетреугольной или нижнетреугольной,
//вывод матрицы. В классе предусмотреть методы: сложение, вычитание, умножение матриц,
//умножение матрицы на число.

namespace Triangle_and_Matrix_classes.Models
{
    public class Matrix
    {
        public Matrix(ObservableCollection<double> MatrixElements)
        {
			this.MatrixElements = MatrixElements;
        }
        public Matrix() {}

		private int _size;
		public int Size
		{
			get { return _size; }
			set { _size = value; }
		}

		private ObservableCollection<double> _matrixElements;
		public ObservableCollection<double>  MatrixElements
        {
			get { return _matrixElements; }
			set { _matrixElements = value; }
		}

		public void CheckMatrixType()
		{

		}
		public void Summation(Matrix matrix)
		{

		}
		public void Sutraction(Matrix matrix)
		{

		}
		public void Multification(Matrix matrix)
		{

		}
        public void Multification(double num)
        {

        }
    }
}
