using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferenceCommandParameterRepro.ViewModels;

namespace ReferenceCommandParameterRepro.Pages;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}