using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Triangle_and_Matrix_classes.Models;

namespace Triangle_and_Matrix_classes.ViewModel
{
    public class TriangleViewModel : INotifyPropertyChanged
    {
        public TriangleViewModel() {
            Triangle triangle = new Triangle();
        }
        
        private Parameters _sides;
        public Parameters Sides
        {
            get { return _sides; }
            set
            {
                _sides = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
