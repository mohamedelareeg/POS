using System.ComponentModel;

namespace POS.Models
{
    public class Category : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _type;
        private byte[] _image;

        public Category()
        {

        }

        public Category(int id, string name, string type)
        {

            Id = id;
            Name = name;
            Type = type;
        }

        public Category(int id, string name, string type, byte[] image)
        {

            Id = id;
            Name = name;
            Type = type;
            Image = image;
        }

        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        public byte[] Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

