using FreshMvvm;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectTest.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.ViewModels
{
    public class ProductViewModel : FreshBasePageModel
    {

        public ProductModel product { get; set; }

        public ProductViewModel()
        {
        }

        public override void Init(object initData)
        {
            if (initData != null)
            {
                product = (ProductModel)initData;
            }
            else
            {
                product = new ProductModel();
            }
        }
    }
}
