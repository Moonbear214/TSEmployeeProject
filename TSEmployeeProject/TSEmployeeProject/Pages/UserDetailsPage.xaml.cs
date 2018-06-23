using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TSEmployeeProject.Models;

namespace TSEmployeeProject.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailsPage : ContentPage
	{
		public UserDetailsPage (UserDetailed user)
		{
			InitializeComponent ();

            stkIdNumber.IsVisible = !user.IsForeigner;
            stkVisaDoc.IsVisible = user.IsForeigner;
            stkEndDate.IsVisible = (user.EndDate == null) ? false : true;

            this.BindingContext = user;
        }
        
        /// <summary>
        /// When the user taps the "Reviews" button, the "Reviews" picker will be focussed and display all previous reviews,
        /// allowing the user to pick one.
        /// A button is used to allow more and easier UI customization 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewReviewPicker(object sender, EventArgs e)
        {
            pckReviewPicker.Focus();
        }

        private async void ReviewPicked(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedIndex != -1)
            {
                EmployeeReview review = ((Picker)sender).SelectedItem as EmployeeReview;

                await DisplayAlert(string.Format(review.TypeDisplay, "Type: {0}"), "Salary: " + review.Salary + "\r\nDate: " + review.Date.ToString("dd/MM/yyyy"), "Okay");// string.Format(review.Salary, review.TypeDisplay, "Salary: {0} \r\nType: {1}"), "Okay");

                ((Picker)sender).SelectedIndex = -1;
            }
        }
    }
}