using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StPaulBowlTourneyForm.Uploader
{
	/// <summary>
	/// Interaction logic for DynamicButton.xaml
	/// </summary>
	public partial class DynamicButtonX : Button
	{
		public DynamicButtonX() : base()
		{
		}

		public string DisplayName
		{
			get { return (string)GetValue(DisplayNameProperty); }
			set { SetValue(DisplayNameProperty, value); }
		}

		// Using a DependencyProperty as the backing store for DisplayName.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DisplayNameProperty =
			DependencyProperty.Register("DisplayName", typeof(string), typeof(DynamicButtonX), new PropertyMetadata(String.Empty));
	}
}
