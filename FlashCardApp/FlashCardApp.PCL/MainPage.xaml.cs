using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlashCardApp.PCL
{

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> FlashWords { get; set; }

        private int _flashWordsCount;

        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                    OnPropertyChanged();

                    //previousWordButton.IsEnabled = _index <= 0 ? false : true;
                    //nextWordButton.IsEnabled = _index >= _flashWordsCount ? false : true;
                }
            }
        }

        private string _word;
        public string Word
        {
            get { return _word; }
            set
            {
                if (_word != value)
                {
                    _word = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            FlashWords = new ObservableCollection<string> { "I", "Love", "You", "Poopie!", "And", "I", "Want", "PIZZA!" };

            BindingContext = this;

            //if (Index == 0)
            //    previousWordButton.IsEnabled = false;

            _flashWordsCount = FlashWords.Count - 1;

            //Word = FlashWords[Index];
        }

        public async void OnNextWordClicked(object sender, EventArgs args)
        {
            if (Index < _flashWordsCount)
            {
                Index++;
                Word = FlashWords[Index];
                return;
            }

            await DisplayAlert("Message", "No more words!", "Ok");
            Index = FlashWords.Count;
        }

        public async void OnPreviousWordClicked(object sender, EventArgs args)
        {
            if (Index >= 0)
            {
                Index--;
                Word = FlashWords[Index];

                return;
            }


            await DisplayAlert("Message", "This is the first work", "Ok");
            Index = 0;

        }


    }
}
