using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidSSLRepro.ViewModels;

namespace AndroidSSLRepro.Pages;

public partial class TestUrlPage : ContentPage
{
    public TestUrlPage(TestUrlViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}