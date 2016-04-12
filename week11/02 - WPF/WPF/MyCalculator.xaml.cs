using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
	public partial class MyCalculatur
	{
		private string _onScreen;

		private string _input;

		private List<ResourceDictionary> Themes = new List<ResourceDictionary>();

		private int currentIndex;

		public MyCalculatur()
		{
			_onScreen = "";
			_input = null;

			// for change themes ;)
			ResourceDictionary darkTheme = new ResourceDictionary();
			darkTheme.Source = new Uri( "/Themes/DarkTheme.xaml", UriKind.Relative );
			ResourceDictionary YellowTheme = new ResourceDictionary();
			YellowTheme.Source = new Uri( "/Themes/YellowTheme.xaml", UriKind.Relative );
			//Themes = new List<ResourceDictionary>();
			Themes.Add( darkTheme );
			Themes.Add( YellowTheme );
			
			UpdateTheme();

			InitializeComponent();
		}



		private void BtnMathOperations_OnClick(object sender, RoutedEventArgs e)
		{
			if (_onScreen.Length != 0)
			{
			//TextBlock.Text = "!!!!";
			var a = _onScreen[_onScreen.Length - 1];
				if (!(a == '*' || a == '+' || a == '+' || a == '-' || a == '.' || a == ','))
				{
					var btnOperation = sender as Button;
					_onScreen += btnOperation.Content.ToString();
					_input = null;
					TextBox.Text = _onScreen;
				}
			}
		}

		private void Button_OnClick(object sender, RoutedEventArgs e)
		{
			//TextBox.Text = "";

			var button = sender as Button;

			_input += button?.Content;

			_onScreen += button.Content;

			TextBox.Text = _onScreen;

		}

		private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
		{
			TextBox.Text = "";
			_input = null;
			_onScreen = "";
		}

		private void ButtonEquals_OnClick(object sender, RoutedEventArgs e)
		{
			if (_onScreen.Length != 0)
			{

				var result = Evaluate(_onScreen).ToString( "#.###################", CultureInfo.CurrentCulture);
				TextBox.Text = _onScreen = result;
				_input = null;
			}
			else TextBox.Text = "No possible actions";
		}

		private void ButtonPoint_OnClick(object sender, RoutedEventArgs e)
		{
			if (_input != null && !_input.Contains("."))
			{
				_input += ".";
			}
			TextBox.Text = _onScreen += ".";
		}

		private void ButtonSqr_OnClick(object sender, RoutedEventArgs e)
		{
			if (_onScreen.Length != 0)
			{

				var result1 = Evaluate(_onScreen).ToString( "#.###################", CultureInfo.CurrentCulture );
				TextBox.Text = _onScreen = result1;


				double operator1;
				double.TryParse(result1, out operator1);
				_onScreen = Math.Sqrt(operator1).ToString( "#.###################", CultureInfo.CurrentCulture );
				TextBox.Text = _onScreen;
			}
		}

		private void ButtonLog_OnClick(object sender, RoutedEventArgs e)
		{
			if (_onScreen.Length != 0)
			{

				var result1 = Evaluate(_onScreen).ToString( "#.#################", CultureInfo.CurrentCulture ); 
				TextBox.Text = _onScreen = result1;

				double operator1;
				double.TryParse(result1, out operator1);
				_onScreen = Math.Log(operator1).ToString( "#.#################", CultureInfo.CurrentCulture ); 
				TextBox.Text = _onScreen;
			}
			else TextBox.Text = "Error";
		}

		private void ButtonChange_OnClick(object sender, RoutedEventArgs e)
		{
			if (_onScreen.Length != 0)
			{ 
				var result1 = Evaluate(_onScreen).ToString( "#.###################", CultureInfo.CurrentCulture );

				TextBox.Text = _onScreen = "-" + result1;
			}
			else
			{
				TextBox.Text = _onScreen = (-1).ToString();
			}
		}

		public static double Evaluate(string expression)
		{
			var loDataTable = new DataTable();
			try
			{
				DataColumn loDataColumn = new DataColumn( "Eval", typeof( double ), expression );
				loDataTable.Columns.Add( loDataColumn );
				loDataTable.Rows.Add( 0 );
				return (double)(loDataTable.Rows[0]["Eval"]);
			}
			catch ( Exception error )
			{
				var a = expression[expression.Length - 1];

				if ( (a == '*' || a == '+' || a == '+' || a == '-' || a == ',' || a == '.' || a == '=') )
				{
					if ( a != '=' ) { ShowErrorMessage( "but try to fix it ", expression ); }

					return Evaluate( expression.TrimEnd( '*', '+', '-', '/', '.', ',','=' ) );
				}
				else {
					ShowErrorMessage( error.Message, expression );
					return 0;
				}
			}
		}
		
		static  void ShowErrorMessage(string error = "Ops...", string expression = "Haven't info")
		{
			MessageBox.Show( "Something Happened " + error + "\n Your Ask: " + expression + "\n :,( " +
							 "\nbut if you added more actions will fix it automaticly \n" +
							 "and will see right result, else 0 \n Click OK!" );
		}

		private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			//Regex regex = new Regex( "\\D" );
			//string a;
			//onScreen = TextBox.Text;
			TextBox.Text = _onScreen = Regex.Replace(TextBox.Text, "[^ -+*[0-9]\\.,/=]", "");
			if (_onScreen.Contains("="))
			{
				ButtonEquals_OnClick(null,null);
			}
		}

		private void ButtonChangeTheme_OnClick(object sender, RoutedEventArgs e)
		{
			currentIndex++;

			if ( currentIndex == Themes.Count )
			{
				currentIndex = 0;
			}
			//TextBox.Text = "TestTheme";
			UpdateTheme();
		}

		private void UpdateTheme()
		{
			Application.Current.Resources.MergedDictionaries.Clear();
			Application.Current.Resources.MergedDictionaries.Add( Themes[currentIndex] );
		}
	}
}
