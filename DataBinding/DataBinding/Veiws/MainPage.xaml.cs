
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataBinding
{
    public partial class MainPage : ContentPage
    {
        private MainPageVeiwModel VeiwModel;

        public MainPage()
        {
            InitializeComponent();
            VeiwModel = new MainPageVeiwModel(this);
            BindingContext = VeiwModel;
        } 
    }
}
