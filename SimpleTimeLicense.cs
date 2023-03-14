#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators
{
	public class SimpleTimeLicense : Indicator
	{
		// Exiration date and time
		private DateTime expiration_time = new DateTime(2023,3,14,21,58,59);
		private DateTime tick_time;
		
		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"Indicator which illustrates how to code simple time license for your NinjaTrader product.";
				Name										= "SimpleTimeLicense";
				Calculate									= Calculate.OnEachTick;
				IsOverlay									= true;
				DisplayInDataBox							= true;
				DrawOnPricePanel							= true;
				DrawHorizontalGridLines						= true;
				DrawVerticalGridLines						= true;
				PaintPriceMarkers							= true;
				ScaleJustification							= NinjaTrader.Gui.Chart.ScaleJustification.Right;
				//Disable this property if your indicator requires custom values that cumulate with each new market data event. 
				//See Help Guide for additional information.
				IsSuspendedWhileInactive					= true;
				
				// Output date and time untill our time license is valid
				Print(string.Format("License valid until {0}", expiration_time));
				Print(string.Format("Current time is {0}", DateTime.Now));				
			}
			
		}

		protected override void OnBarUpdate()
		{
			if (expiration_time >= DateTime.Now || expiration_time >= tick_time)
			{	
				Print("===============");
				Print(string.Format("tick time = {0}", tick_time));
				Print(string.Format("current time = {0}", DateTime.Now));
				Print(string.Format("expiration time = {0}", expiration_time));
				Print("===============");
				
				// Place main code here to execute
				
			}
			else
			{
				Print("Your time license is expired! Program does nothing!");
				return;
			}
		}
		
		protected override void OnMarketData(MarketDataEventArgs marketDataUpdate)
		{
    		tick_time = marketDataUpdate.Time;
		}
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private SimpleTimeLicense[] cacheSimpleTimeLicense;
		public SimpleTimeLicense SimpleTimeLicense()
		{
			return SimpleTimeLicense(Input);
		}

		public SimpleTimeLicense SimpleTimeLicense(ISeries<double> input)
		{
			if (cacheSimpleTimeLicense != null)
				for (int idx = 0; idx < cacheSimpleTimeLicense.Length; idx++)
					if (cacheSimpleTimeLicense[idx] != null &&  cacheSimpleTimeLicense[idx].EqualsInput(input))
						return cacheSimpleTimeLicense[idx];
			return CacheIndicator<SimpleTimeLicense>(new SimpleTimeLicense(), input, ref cacheSimpleTimeLicense);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.SimpleTimeLicense SimpleTimeLicense()
		{
			return indicator.SimpleTimeLicense(Input);
		}

		public Indicators.SimpleTimeLicense SimpleTimeLicense(ISeries<double> input )
		{
			return indicator.SimpleTimeLicense(input);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.SimpleTimeLicense SimpleTimeLicense()
		{
			return indicator.SimpleTimeLicense(Input);
		}

		public Indicators.SimpleTimeLicense SimpleTimeLicense(ISeries<double> input )
		{
			return indicator.SimpleTimeLicense(input);
		}
	}
}

#endregion
