using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;

namespace DataBinding
{
    internal class MainPageVeiwModel : BindableBase
    {

        public ICommand ButtonCommand { private set; get; }

        private string input;
        public string Input
        {
            get { return input; }
            set
            {

                if (value != input)
                {
                    input = value;
                    OnPropertyChange("Input");
                }

            }
        }

        private ContentPage veiw;

        public MainPageVeiwModel(ContentPage v)
        {
            ButtonCommand = new Command(ButtonPressed);
            Thread threadtimer = new Thread(() => ThreadTimer(this));
            threadtimer.Start();
            veiw = v;
        }


        public async void ButtonPressed()
        {
            //Bound to Button From Front
            //App.Current.MainPage = new Page1();
            //await veiw.Navigation.PushAsync(new Page1());
            APIClient Client = new APIClient();
            ReqVars person = new ReqVars();
            person = await Client.GetName();
            Input = person.name;
        }

        public static void ThreadTimer(MainPageVeiwModel vm)
        {
            while (true)
            {
                Thread.Sleep(1000);
                vm.Input = DateTime.Now.ToString("hh:mm:ss");
            }
        }







    }
}
