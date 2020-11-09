using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Highsoft.Highcharts.Core;
using Com.Highsoft.Highcharts.Common.Hichartsclasses;
using Java.Lang;
using System.Collections.Generic;

namespace HighCharts_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            HIChartView chartView = FindViewById<HIChartView>(Resource.Id.hc);

            HIOptions options = new HIOptions();

            HIChart chart = new HIChart();
            chart.Polar = (Boolean)true;
            options.Chart = chart;
            HITitle title = new HITitle();
            title.Text = "";
            options.Title = title;

            HIXAxis xAxis = new HIXAxis();
            xAxis.TickInterval = (Number)30;
            xAxis.Min = (Number)0;
            xAxis.Max = (Number)360;
            xAxis.Labels = new HILabels();
            List<HIXAxis> list = new List<HIXAxis>();
            list.Add(xAxis);
            options.XAxis = list;

            HILine series2 = new HILine();
            Number[] titleq = number(180, 0.5);
            series2.Data = titleq;

            HILine series3 = new HILine();
            Number[] titleq3 = number(45, 1);
            series3.Data = titleq3;

            List<HISeries> ss = new List<HISeries>();
            ss.Add(series2);
            ss.Add(series3);
            options.Series = ss;
            chartView.Options = options;



        }
        public virtual Number[] number(int phase, double amp)
        {
            Number[] numbers = new Number[360];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (Number)0;
                if (i == phase)
                {
                    numbers[i] = (Number)amp;
                }
            }
            return numbers;
        }
    }
}