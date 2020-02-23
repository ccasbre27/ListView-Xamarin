using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace ListViewRUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, IViewFor<BookViewModel>
    {
        readonly CompositeDisposable _bindingsDisposable = new CompositeDisposable();


        public MainPage()
        {
            InitializeComponent();
        }


		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel = new BookViewModel();

			this.OneWayBind(ViewModel, vm => vm.Books, v => v.Articles.ItemsSource).DisposeWith(_bindingsDisposable);

		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_bindingsDisposable.Clear();
		}

		#region ViewModel Setup
		public BookViewModel ViewModel { get; set; }
		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (BookViewModel)value; }
		}
		#endregion
	}
}
