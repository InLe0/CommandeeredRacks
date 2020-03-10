﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XaFirstMVVMNav.ViewModels
{
    class WelcomeViewModel : BaseViewModel
    {
        bool isBusy = false;

        public ICommand NavigateToSentenceCMD => new Command(async () => {
            if (isBusy)
                return;
            isBusy = true;

            await NavigationService.NavigateToAsync<InfoViewModel>();

            isBusy = false;
        });
    }
}
