﻿using Microsoft.AspNetCore.Components;

namespace MyCompanyName.AbpZeroTemplate.Maui.Services.Navigation
{
    public interface INavigationService
    {
        void Initialize(NavigationManager navigationManager);

        void NavigateTo(string uri, bool forceLoad = false, bool replace = false);
    }
}