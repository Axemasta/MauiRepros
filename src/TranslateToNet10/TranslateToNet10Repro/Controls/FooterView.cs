using System.ComponentModel;
using System.Diagnostics;

namespace TranslateToNet10Repro.Controls;

[ContentProperty(nameof(InnerContent))]
public class FooterView : ContentView
{
	public static new readonly BindableProperty InnerContentProperty = BindableProperty.Create(
		nameof(Content),
		typeof(View),
		typeof(ContentView),
		null,
		propertyChanged: (bindable, oldValue, newValue) => ((FooterView)bindable).OnContentChanged(oldValue as View, newValue as View));

	public View InnerContent
	{
		get => (View)GetValue(InnerContentProperty);
		set => SetValue(InnerContentProperty, value);
	}

	private Grid Container { get; } = new();
	
	private BoxView ShadowBoxView { get; } = new()
	{
		BackgroundColor = Colors.Transparent,
		Opacity = 1.0,
		VerticalOptions = LayoutOptions.Fill,
		Background = new LinearGradientBrush(
			[
				new GradientStop(Colors.Transparent, 0.0f),
				new GradientStop(Colors.Black, 1.0f)
			],
			new Point(0, 0),
			new Point(0, 1)
		)
	};

	public FooterView()
    {
        this.PropertyChanged += OnPropertyChanged;
        Container.Add(ShadowBoxView);
        this.Content = Container;
    }

    ~FooterView()
	{
		this.PropertyChanged -= OnPropertyChanged;
    }

    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		Debug.WriteLine($"FooterView PropertyChanged: {e.PropertyName}");
	}
    
	private void OnContentChanged(View? oldValue, View? newValue)
	{
		if (oldValue is not null)
		{
			Container.Remove(oldValue);
		}

		if (newValue is not null)
		{
			Container.Add(newValue);
		}
	}
}