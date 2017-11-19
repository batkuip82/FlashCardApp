using FlashCardApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; }

            public MasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailMenuItem>(new[]
                {
                    new MasterDetailMenuItem { Id = 0, Title = "Show Words", TargetType = typeof(FlashCardPage) },
                    new MasterDetailMenuItem { Id = 1, Title = "Add Words", TargetType = typeof(MasterDetailPageDetail) },
                    //new MasterDetailMenuItem { Id = 2, Title = "Page 3" },
                    //new MasterDetailMenuItem { Id = 3, Title = "Page 4" },
                    //new MasterDetailMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}