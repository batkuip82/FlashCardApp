using FlashCardApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlashCardApp.Views.Admin
{
    public class EditWordsPageViewModel : BindableBase
    {
        INavigationService _navigationService;
        public ObservableCollection<WordModel> WordsList { get; set; } = new ObservableCollection<WordModel>();

        private DelegateCommand<WordModel> _deleteRowCommand;
        public DelegateCommand<WordModel> DeleteRowCommand
        {
            get
            {
                return _deleteRowCommand ?? (_deleteRowCommand = new DelegateCommand<WordModel>((w) =>
                {
                    WordsList.Remove(w);
                }));
            }
        }

        private DelegateCommand _addRowCommand;
        public DelegateCommand AddRowCommand
        {
            get
            {
                return _addRowCommand ?? (_addRowCommand = new DelegateCommand(() =>
                {
                    WordsList.Add(new WordModel { Index = WordsList.Count });
                }));
            }
        }

        private DelegateCommand _saveWordsListCommand;
        public DelegateCommand SaveWordsListCommand
        {
            get
            {
                return _saveWordsListCommand ??
                    (_saveWordsListCommand = new DelegateCommand(async () =>
                    {
                        App.Current.Properties["FlashCardWordList"] = WordsList.ToList();
                        await _navigationService.GoBackToRootAsync();
                    }));
            }
        }

        private DelegateCommand<WordModel> _updateWordItemCommand;
        public DelegateCommand<WordModel> UpdateWordItemCommand
        {
            get
            {
                return _updateWordItemCommand ??
                      (_updateWordItemCommand = new DelegateCommand<WordModel>((item) =>
                      {
                          WordsList.Where(w => w.Index == item.Index).Select(w => w.Word = item.Word);
                      }));
            }
        }

        public EditWordsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var wordList = new List<WordModel>();
            for (int i = 0; i < 5; i++)
            {
                wordList.Add(new WordModel { Index = i, Word = null });
            }

            WordsList = new ObservableCollection<WordModel>(wordList);
        }
    }
}
