// namespace Zimba.Maui.Controls;

// public partial class Card : ContentPage
// {
// 	public Card()
// 	{
// 		InitializeComponent();
// 	}
// }
using Microsoft.Maui.Controls.Shapes;

namespace Zimba.Maui.Controls
{
	public partial class Card : Border
	{
		#region Properties

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(nameof(Title), typeof(string), typeof(Card), string.Empty);

		public string Title
		{
			get => (string)GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public static readonly BindableProperty TitleFontSizeProperty =
			BindableProperty.Create(nameof(TitleFontSize), typeof(double), typeof(Card), 12.0);

		public double TitleFontSize
		{
			get => (double)GetValue(TitleFontSizeProperty);
			set => SetValue(TitleFontSizeProperty, value);
		}

		public static readonly BindableProperty ShowTitleSectionProperty =
			BindableProperty.Create(nameof(ShowTitleSection), typeof(bool), typeof(Card), true);
		
		public bool ShowTitleSection
		{
			get => (bool)GetValue(ShowTitleSectionProperty);
			set => SetValue(ShowTitleSectionProperty, value);
		}
		
	
		public static readonly BindableProperty CardContentProperty =
			BindableProperty.Create(nameof(CardContent), typeof(View), typeof(Card), null);

		public View CardContent
		{
			get => (View)GetValue(CardContentProperty);
			set => SetValue(CardContentProperty, value);
		}


		public static readonly BindableProperty FooterProperty =
			BindableProperty.Create(nameof(Footer), typeof(View), typeof(Card), null);

		public View Footer
		{
			get => (View)GetValue(FooterProperty);
			set => SetValue(FooterProperty, value);
		}

		public static readonly BindableProperty ShowFooterSectionProperty =
			BindableProperty.Create(nameof(ShowFooterSection), typeof(bool), typeof(Card), false);

		public bool ShowFooterSection
		{
			get => (bool)GetValue(ShowFooterSectionProperty);
			set => SetValue(ShowFooterSectionProperty, value);
		}

		public static readonly BindableProperty CardCornerRadiusProperty =
			BindableProperty.Create(nameof(CardCornerRadius), typeof(double), typeof(Card), 8.0,
				propertyChanged: OnCardCornerRadiusChanged);

		public double CardCornerRadius
		{
			get => (double)GetValue(CardCornerRadiusProperty);
			set => SetValue(CardCornerRadiusProperty, value);
		}

		public static readonly BindableProperty HasShadowProperty =
			BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(Card), true,
				propertyChanged: OnHasShadowChanged);

		public bool HasShadow
		{
			get => (bool)GetValue(HasShadowProperty);
			set => SetValue(HasShadowProperty, value);
		}

		public static readonly BindableProperty ShadowOffsetProperty =
			BindableProperty.Create(nameof(ShadowOffset), typeof(Point), typeof(Card), new Point(2, 3),
				propertyChanged: OnShadowPropertyChanged);

		public Point ShadowOffset
		{
			get => (Point)GetValue(ShadowOffsetProperty);
			set => SetValue(ShadowOffsetProperty, value);
		}

		public static readonly BindableProperty ShadowRadiusProperty =
			BindableProperty.Create(nameof(ShadowRadius), typeof(float), typeof(Card), 5.0f,
				propertyChanged: OnShadowPropertyChanged);

		public float ShadowRadius
		{
			get => (float)GetValue(ShadowRadiusProperty);
			set => SetValue(ShadowRadiusProperty, value);
		}

		public static readonly BindableProperty ShadowOpacityProperty =
			BindableProperty.Create(nameof(ShadowOpacity), typeof(float), typeof(Card), 0.2f,
				propertyChanged: OnShadowPropertyChanged);

		public float ShadowOpacity
		{
			get => (float)GetValue(ShadowOpacityProperty);
			set => SetValue(ShadowOpacityProperty, value);
		}
		
		public static readonly BindableProperty ElevationProperty =
			BindableProperty.Create(nameof(Elevation), typeof(double), typeof(Card), 2.0,
				propertyChanged: OnShadowGeometryChanged);

		public double Elevation
		{
			get => (double)GetValue(ElevationProperty);
			set => SetValue(ElevationProperty, value);
		}
		public static readonly BindableProperty ShadowAngleProperty =
			BindableProperty.Create(nameof(ShadowAngle), typeof(double), typeof(Card), 90.0,
				propertyChanged: OnShadowGeometryChanged);

		public double ShadowAngle
		{
			get => (double)GetValue(ShadowAngleProperty);
			set => SetValue(ShadowAngleProperty, value);
		}
		private static void OnShadowGeometryChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Card card && card.HasShadow)
			{
				double radians = card.ShadowAngle * Math.PI / 180;
				var dx = Math.Cos(radians) * card.Elevation;
				var dy = Math.Sin(radians) * card.Elevation;

				card.ShadowOffset = new Point(dx, dy);

				card.Shadow = new Shadow
				{
					Brush = Brush.Black,
					Offset = card.ShadowOffset,
					Radius = card.ShadowRadius,
					Opacity = card.ShadowOpacity
				};
			}
		}



		#endregion

		public Card()
		{
			InitializeComponent();
		}

		#region Property Change Handlers

		private static void OnCardCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Card card)
			{
				double radius = (double)newValue;
				card.StrokeShape = new RoundRectangle
				{
					CornerRadius = radius
				};

				// Also update the title and footer sections
				card.UpdateTitleAndFooterShapes(radius);
			}
		}

		private static void OnHasShadowChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Card card)
			{
				bool hasShadow = (bool)newValue;
				card.Shadow = hasShadow ? new Shadow
				{
					Brush = Brush.Black,
					Offset = card.ShadowOffset,
					Radius = card.ShadowRadius,
					Opacity = card.ShadowOpacity
				} : null;
			}
		}

		private static void OnShadowPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Card card && card.HasShadow && card.Shadow != null)
			{
				card.Shadow = new Shadow
				{
					Brush = Brush.Black,
					Offset = card.ShadowOffset,
					Radius = card.ShadowRadius,
					Opacity = card.ShadowOpacity
				};
			}
		}

		private void UpdateTitleAndFooterShapes(double radius)
		{
			if (TitleSection != null)
			{
				TitleSection.StrokeShape = new RoundRectangle
				{
					CornerRadius = new CornerRadius(radius, radius, 0, 0)
				};
			}

			if (FooterSection != null)
			{
				FooterSection.StrokeShape = new RoundRectangle
				{
					CornerRadius = new CornerRadius(0, 0, radius, radius)
				};
			}
		}

		#endregion
	}
}