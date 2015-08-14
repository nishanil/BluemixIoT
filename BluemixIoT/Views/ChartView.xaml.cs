using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using Infragistics.XF.Controls;
using Infragistics.XF;

namespace BluemixIoT
{
	public partial class ChartView : ContentView
	{
		public ChartView ()
		{
			InitializeComponent ();
			OnShowOverlayChanged(true, false);
			xAxis.FormatLabel +=  (object sender, object item) => {
				var value = ((DeviceData)item).Timestamp;
				return String.Format("{0:T}", value);
			
			};

			var series = chart.Series.OfType<LineSeries>().First();
			series.Brush = new SolidColorBrush(Theme.PrimaryColor);
			series.Thickness = 2;
			series.MarkerBrush = new SolidColorBrush(Theme.AscentColor);
			series.MarkerOutline = new SolidColorBrush(Theme.LightColor);
		}

		public static readonly BindableProperty DataProperty =
			BindableProperty.Create<ChartView, DeviceDataCollection>(p => p.Data, null, propertyChanged: OnDataChanged);

		private static void OnDataChanged(BindableObject bindable, DeviceDataCollection oldvalue, DeviceDataCollection newvalue)
		{
			((ChartView)bindable).OnDataChanged(oldvalue, newvalue);
		}

		public DeviceDataCollection Data
		{
			get { return (DeviceDataCollection)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}

		public void OnDataChanged(DeviceDataCollection oldValue, DeviceDataCollection newValue)
		{
			PopulateChart(newValue);
		}

		private void PopulateChart(DeviceDataCollection newValue)
		{
			
			chart.Series[0].ItemsSource = newValue;
			var axis = chart.Axes.OfType<CategoryXAxis>().First();
			axis.ItemsSource = newValue;

		}

		public static readonly BindableProperty ShowOverlayProperty =
			BindableProperty.Create<ChartView, bool>(p => p.ShowOverlay, false, propertyChanged: OnShowOverlayChanged);

		private static void OnShowOverlayChanged(BindableObject bindable, bool oldvalue, bool newvalue)
		{
			((ChartView)bindable).OnShowOverlayChanged(oldvalue, newvalue);
		}

		public bool ShowOverlay
		{
			get { return (bool)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}

		public void OnShowOverlayChanged(bool oldValue, bool newValue)
		{
			if (newValue)
			{
				overlay.Opacity = 0.5;
				downloadingData.Text = "Downloading..";
			}
			else
			{
				overlay.Opacity = 0;
				downloadingData.Text = string.Empty;

			}
		}
	}
}



