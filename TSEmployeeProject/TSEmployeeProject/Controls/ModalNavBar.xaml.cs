using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSEmployeeProject.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModalNavBar : StackLayout
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ModalNavBar), default(string), Xamarin.Forms.BindingMode.OneWay);
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public ModalNavBar ()
        {
            InitializeComponent();

            lblTitle.Text = Title;
            btnCloseModal.Clicked += BtnCloseModal_Clicked;
        }

        private async void BtnCloseModal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleProperty.PropertyName)
            {
                lblTitle.Text = Title;
            }
        }
    }
}