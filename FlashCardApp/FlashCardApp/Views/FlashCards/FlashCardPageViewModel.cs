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
        public ObservableCollection<WordModel> FlashWords
        {
            get
            {
                if (App.Current.Properties.ContainsKey("FlashCardWordList"))
                {
                    return new ObservableCollection<WordModel>(App.Current.Properties["FlashCardWordList"] as List<WordModel>);
                }

                return null;
            }
        }

        public DelegateCommand EditFlashCardWordsCommand { get; set; }
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
