using System;
using System.Activities.Debugger;
using System.Net;
using System.Web;
using System.Xml;

public partial class Zillow : System.Web.UI.Page
{
    public string ZillowAPIDeveloperKey { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        divStep2Failure.Visible = false;
        divStep2Success.Visible = false;
        divStep1Failure.Visible = false;
        divStep1Success.Visible = false;
    }

    protected void BtnSearchClick(object sender, EventArgs e)
    {
        ZillowAPIDeveloperKey = System.Configuration.ConfigurationManager.AppSettings["ZillowAPIDeveloperKey"];
        var address = Server.UrlEncode(tbAddress.Text);
        var zipOrCityState = Server.UrlEncode(tbZipCodeORCityState.Text);
        var zEstimate = ZillowAPI.GetZestimate(ZillowAPIDeveloperKey, address, zipOrCityState);

        if (zEstimate.ReturnCode == 0)
        {
            Estimate.Text = zEstimate.Estimate.ToString("C0");
            ValueRangeLow.Text = zEstimate.ValueRangeLow.ToString("C0");
            ValueRangeHigh.Text = zEstimate.ValueRangeHigh.ToString("C0");
            Latitude.Text = zEstimate.Latitude.ToString();
            Longitude.Text = zEstimate.Longitude.ToString();
            LastUpdated.Text = zEstimate.LastUpdated.ToShortDateString();
            Street.Text = zEstimate.Street;
            City.Text = zEstimate.City;
            State.Text = zEstimate.State;
            ZipCode.Text = zEstimate.ZipCode;
            //LinktoMap.NavigateUrl = zEstimate.LinktoMap;
            //LinktoComparables.NavigateUrl = zEstimate.LinktoComparables;
            //LinktoGraphsAndData.NavigateUrl = zEstimate.LinktoGraphsAndData;
            //LinktoHomeDetails.NavigateUrl = zEstimate.LinktoHomeDetails;
            divStep2Success.Visible = true;
        }
        else
        {
            divStep2Failure.Visible = true;
            lblFailureMessage2.Text = String.Format("Code# {0} - {1}", zEstimate.ReturnCode, zEstimate.ReturnCodeMessage);
        }
    }

    protected void BtnGetChartClick(object sender, EventArgs e)
    {
        ZillowAPIDeveloperKey = System.Configuration.ConfigurationManager.AppSettings["ZillowAPIDeveloperKey"];
        var address = Server.UrlEncode(tbAddress.Text);
        var zipOrCityState = Server.UrlEncode(tbZipCodeORCityState.Text);
        var zEstimate = ZillowAPI.GetZestimate(ZillowAPIDeveloperKey, address, zipOrCityState);
        Address.Text = zEstimate.Street + " " + zEstimate.City + " " + zEstimate.State + " " + zEstimate.ZipCode;
        

        string ZillowId = zEstimate.ZillowId.ToString();
        var zChart = ZillowAPI.GetChart(ZillowAPIDeveloperKey, ZillowId);
        
        if (zChart.ReturnCode == 0)
        {
            Image1.ImageUrl = zChart.Url;
            //Image2.AlternateText = zChart.Graphsanddata;
            divStep1Success.Visible = true;
        }
        else
        {
            divStep1Failure.Visible = true;
            lblFailureMessage1.Text = String.Format("Code# {0} - {1}", zEstimate.ReturnCode, zEstimate.ReturnCodeMessage);
        }
    }
}
