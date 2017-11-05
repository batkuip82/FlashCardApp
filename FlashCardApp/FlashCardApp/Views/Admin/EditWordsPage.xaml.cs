using FlashCardApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardApp.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditWordsPage : ContentPage
    {
        EditWordsPageViewModel _vm;
        public EditWordsPage()
        {
            InitializeComponent();
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if(BindingContext != null)
            {
                _vm = BindingContext as EditWordsPageViewModel;
            }
        }

        void UpdateItem(object sender, TextChangedEventArgs e)
        {
            var item = (WordModel)((Entry)sender).BindingContext;

            _vm.WordsList.Where(w => w.Index == item.Index).Select(w => w.Word = item.Word);

            var newItem = _vm.WordsList.FirstOrDefault(w => w.Index == item.Index);

        }

    }
}