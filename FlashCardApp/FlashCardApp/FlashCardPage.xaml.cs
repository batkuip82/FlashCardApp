using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using FlashCardApp.Admin;

namespace FlashCardApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardPage : ContentPage
    {
        //private Command _editFlashCardWordsCommand;
        //public Command EditFlashCardWordsCommand
        //{
        //    get
        //    {
        //        return _editFlashCardWordsCommand ?? new Command(async () =>
        //        {
        //            await Navigation.PushAsync(new EditWords());
        //        });
        //    }
        //    set { _editFlashCardWordsCommand = value; }
        //}

        public ICommand EditFlashCardWordsCommand { get; set; }

        public ObservableCollection<WordModel> FlashWords { get; set; } = new ObservableCollection<WordModel>();

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

        public FlashCardPage()
        {
            InitializeComponent();
            if (App.Current.Properties.ContainsKey("FlashCardWordList"))
            {
                FlashWords = new ObservableCollection<WordModel>(App.Current.Properties["FlashCardWordList"] as List<WordModel>);
            }

            BindingContext = this;

            EditFlashCardWordsCommand = new Command(async () => {
                await Navigation.PushAsync(new EditWords()); }
            );

            //if (Index == 0)
            //    previousWordButton.IsEnabled = false;

            _flashWordsCount = FlashWords.Count - 1;

            //Word = FlashWords[Index];
        }

        //public async void OnNextWordClicked(object sender, EventArgs args)
        //{
        //    if (Index < _flashWordsCount)
        //    {
        //        Index++;
        //        Word = FlashWords[Index];
        //        return;
        //    }

        //    await DisplayAlert("Message", "No more words!", "Ok");
        //    Index = FlashWords.Count;
        //}

        //public async void OnPreviousWordClicked(object sender, EventArgs args)
        //{
        //    if (Index >= 0)
        //    {
        //        Index--;
        //        Word = FlashWords[Index];

        //        return;
        //    }


        //    await DisplayAlert("Message", "This is the first work", "Ok");
        //    Index = 0;

        //}


    }
}
