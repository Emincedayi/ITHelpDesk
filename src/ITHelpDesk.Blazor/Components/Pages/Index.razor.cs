﻿using Microsoft.AspNetCore.Components;

namespace ITHelpDesk.Blazor.Components.Pages;


public partial class Index
{
    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    private void Login()
    {
        Navigation.NavigateTo("/Account/Login", true);
    }
}
