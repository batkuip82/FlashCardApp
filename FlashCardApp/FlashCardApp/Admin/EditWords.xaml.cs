using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;

namespace FlashCardApp.Admin
{
    public class WordModel
    {
        public int Index { get; set; }
        public string Word { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditWords : ContentPage
    {
        public ObservableCollection<WordModel> WordsList { get; set; } = new ObservableCollection<WordModel>();

        private Command _saveWordsListCommand;
        public Command SaveWordsListCommand
        {
            get
            {
                return _saveWordsListCommand ??
                    (_saveWordsListCommand = new Command(() =>
                    {
                        App.Current.Properties["FlashCardWordList"] = WordsList.ToList();
                        App.Current.MainPage = new NavigationPage(new FlashCardPage());
                    }));
            }
        }

        public EditWords()
        {
            InitializeComponent();
            BindingContext = this;

            var wordList = new List<WordModel>();
            for (int i = 0; i < 5; i++)
            {
                wordList.Add(new WordModel { Index = i, Word = null });
            }

            WordsList = new ObservableCollection<WordModel>(wordList);
        }

        void UpdateItem(object sender, TextChangedEventArgs e)
        {
            var item = (WordModel)((Entry)sender).BindingContext;

            WordsList.Where(w => w.Index == item.Index).Select(w => w.Word = item.Word);

            var newItem = WordsList.FirstOrDefault(w => w.Index == item.Index);

            
            //Code to update the item with the SQLite database with the new price
        }

    }
}