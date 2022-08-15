using FreshMvvm;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectTest.Model;
using ProjectTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectTest.ViewModels
{
    public class ProductListViewModel : FreshBasePageModel
    {
        public ProductListViewModel()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetProduct();
            });
        }

        public async Task GetProduct()
        {
            try
            {
                List<ProductModel> list = new List<ProductModel>();

                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                    list = await new ApiClient().GetProduct();
                else
                    await CoreMethods.DisplayAlert("Error", "No Connection", "Ok");

                ListProduct = new ObservableCollection<ProductModel>(list);
                RaisePropertyChanged("ListProduct");
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get => selectedProduct;
            set
            {

                if(value != null)
                {
                     CoreMethods.PushPageModel<ProductViewModel>(value);
                }
                selectedProduct = value;

            }
        }


        private ObservableCollection<ProductModel> _productList = new ObservableCollection<ProductModel>();
        private ProductModel _selectedProduct { get; set; }

        public ObservableCollection<ProductModel> ListProduct
        {
            get
            {
                return _productList;
            }

            set
            {
                _productList = value;
            }
        }


    }
}
