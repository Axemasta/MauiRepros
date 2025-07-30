using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupHeaderResizingRepro.ViewModels;

namespace GroupHeaderResizingRepro.Pages;

public partial class AnimalsPage : ContentPage
{
    public AnimalsPage(AnimalsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}