﻿using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;
using Dima.Web.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.ComponentModel.Design;

namespace Dima.Web.Pages.Categories
{
    public partial class CreateCategoryPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateCategoryRequest InputModel { get; set; } = new();
        
        #endregion

        #region Services

        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar SnackBar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    NavigationManager.NavigateTo("/categorias");                    
                }
                else
                {
                    SnackBar.Add(result.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }

        }
        #endregion

    }
}
