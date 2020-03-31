using System.Collections.Generic;
using Xamarin.Forms;
using EscapeRankUI.Modelos;
using EscapeRankUI.Servicios;

namespace EscapeRankUI.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private bool _cargando = false;
        private List<Category> _listCategory;
        private List<Restaurant> _listRestaurant;
        private List<Food> _listFood;

        public bool Cargando
        {
            get { return _cargando; }
            set
            {
                _cargando = value;
                OnPropertyChanged();
            }
        }



        public List<Restaurant> ListRestaurant
        {
            get { return _listRestaurant; }
            set
            {
                _listRestaurant = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            GetService();
        }

        public List<Category> ListCategory
        {
            get { return _listCategory; }
            set
            {
                _listCategory = value;
                OnPropertyChanged();
            }
        }



        public List<Food> ListFood
        {
            get { return _listFood; }
            set
            {
                _listFood = value;
                OnPropertyChanged();
            }
        }


        


        public void GetService()
        {
            var service = new MainService();
            ListRestaurant = service.GetRestaurant();
            ListCategory = service.GetCategory();
            ListFood = service.GetFood();
        }
    }
}
