using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_and_Matrix_classes.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        MainViewModel() {
            Objects = new List<string>() { "Треугольник", "Матрица" };
        }

        private object _selectedObject;

        public object SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value; 
            OnPropertyChanged();
            }
        }

        private List<string> _objects;

        public List<string> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
