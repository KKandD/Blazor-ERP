using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Clients.Models
{
    public class ClientModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        private string _companyName;
        private string _NIP;
        private DateTime _addingDate;
        private string _email;
        private string _contactNumber;
        private string _city;
        private string _street;
        private string _postalCode;


        public string CompanyName
        {
            get => _companyName;
            set
            {
                if (value != _companyName)
                {
                    _companyName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompanyName)));
                }
            }
        }

        [MinLength(10, ErrorMessage = "NIP musi posiadać 10 cyfr")]
        [MaxLength(10, ErrorMessage = "NIP musi posiadać 10 cyfr")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NIP może zawierać tylko cyfry")]
        public string NIP
        {
            get => _NIP;
            set
            {
                if (value != _NIP)
                {
                    _NIP = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NIP)));
                }
            }
        }

        public DateTime AddingDate
        {
            get => _addingDate;
            set
            {
                if (value != _addingDate)
                {
                    _addingDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddingDate)));
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value != _email)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }

        public string ContactNumber
        {
            get => _contactNumber;
            set
            {
                if (value != _contactNumber)
                {
                    _contactNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContactNumber)));
                }
            }
        }

        public string City
        {
            get => _city;
            set
            {
                if (value != _city)
                {
                    _city = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(City)));
                }
            }
        }

        public string Street
        {
            get => _street;
            set
            {
                if (value != _street)
                {
                    _street = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Street)));
                }
            }
        }

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                if (value != _postalCode)
                {
                    _postalCode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PostalCode)));
                }
            }
        }
    }
}
