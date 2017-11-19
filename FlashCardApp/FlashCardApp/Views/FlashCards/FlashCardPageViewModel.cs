using FlashCardApp.Models;
using FlashCardApp.Views.Admin;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardApp.ViewModels
{
    public class FlashCardPageViewModel : BindableBase
    {
        private int _currentPosition;
        public int CurrentPosition
        {
            get { return _currentPosition; }
            set { SetProperty(ref _currentPosition, value); }
        }

        public ObservableCollection<WordModel> FlashWords
        {
            get
            {
                return new ObservableCollection<WordModel>
                {
                    new WordModel{ Index = 0, Word= "test1" },
                    //new WordModel{ Index = 0, Word= "test2" },
                    //new WordModel{ Index = 0, Word= "test3" },
                    //new WordModel{ Index = 0, Word= "test4" },
                };
                if (App.Current.Properties.ContainsKey("FlashCardWordList"))
                {
                    return new ObservableCollection<WordModel>(App.Current.Properties["FlashCardWordList"] as List<WordModel>);
                }

                return null;
            }
        }

        public DelegateCommand EditFlashCardWordsCommand { get; set; }

        private DelegateCommand _restartFlashWordsCommand;
        public DelegateCommand RestartFlashWordsCommand
        {
            get
            {
                return _restartFlashWordsCommand ?? (_restartFlashWordsCommand = new DelegateCommand(() =>
                {
                    if (CurrentPosition != 0)
                        CurrentPosition = 0;
                }
                ));
            }
        }

        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        public FlashCardPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            EditFlashCardWordsCommand = new DelegateCommand(async () =>
                await _navigationService.NavigateAsync(nameof(EditWordsPage)));
        }
    }
}
