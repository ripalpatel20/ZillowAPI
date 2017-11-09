using System;
using System.Net;
using System.Xml;

/// <summary>
/// ZillowAPI implementation for .Net
/// </summary>
public class ZillowAPI
{
    public class ZillowEstimate
    {
        public int ReturnCode;
        public string ReturnCodeMessage;
        public int ZillowId;
        public string LinktoMap;
        public string LinktoHomeDetails;
        public string LinktoGraphsAndData;
        public string LinktoComparables;
        public decimal Estimate;
        public DateTime LastUpdated;
        public decimal ValueChange;
        public int ValueChangeDurationInDays;
        public decimal ValueRangeLow;
        public decimal ValueRangeHigh;
        public decimal Latitude;
        public decimal Longitude;
        public string Street;
        public string City;
        public string State;
        public string ZipCode;
        public string Url;
        public string Graphsanddata;
    }


    public static ZillowEstimate GetZestimate(string zillowWebServiceId, string Address, string ZipCode)
    {
        //http://www.zillow.com/howto/api/GetSearchResults.htm

        var z = new ZillowEstimate();
        // Construct the url
       // var zEstimate = new decimal();
        var url = String.Format("http://www.zillow.com/webservice/GetSearchResults.htm?zws-id={0}&address={1}&citystatezip={2}", zillowWebServiceId, Address, ZipCode);


        // Make the HTTP request / get the response
        var Request = (System.Net.HttpWebRequest)WebRequest.Create(url);
        var Response = (HttpWebResponse)Request.GetResponse();

        // Parse the HTTP response into an XML document
        XmlDocument xml = new XmlDocument();
        xml.Load(Response.GetResponseStream());
        XmlElement root = xml.DocumentElement;

        //Return Code
        z.ReturnCode = int.Parse(root.SelectSingleNode("//message/code").InnerText);
        z.ReturnCodeMessage = root.SelectSingleNode("//message/text").InnerText;


        if (z.ReturnCode == 0)
        {
            z.ZillowId = int.Parse(root.SelectSingleNode("//response/results/result/zpid").InnerText);
            z.LinktoMap = root.SelectSingleNode("//response/results/result/links/mapthishome").InnerText;
            z.LinktoHomeDetails = root.SelectSingleNode("//response/results/result/links/homedetails").InnerText;
            z.LinktoGraphsAndData = root.SelectSingleNode("//response/results/result/links/graphsanddata").InnerText;
            z.LinktoComparables = root.SelectSingleNode("//response/results/result/links/comparables").InnerText;
            z.Estimate = decimal.Parse(root.SelectSingleNode("//response/results/result/zestimate/amount").InnerText);
            z.LastUpdated = DateTime.Parse(root.SelectSingleNode("//response/results/result/zestimate/last-updated").InnerText);
            z.ValueChange = decimal.Parse(root.SelectSingleNode("//response/results/result/zestimate/valueChange").InnerText);
            z.ValueChangeDurationInDays = int.Parse(root.SelectSingleNode("//response/results/result/zestimate/valueChange").Attributes["duration"].Value);
            z.ValueRangeLow = decimal.Parse(root.SelectSingleNode("//response/results/result/zestimate/valuationRange/low").InnerText);
            z.ValueRangeHigh = decimal.Parse(root.SelectSingleNode("//response/results/result/zestimate/valuationRange/high").InnerText);

            z.Street = root.SelectSingleNode("//response/results/result/address/street").InnerText;
            z.City = root.SelectSingleNode("//response/results/result/address/city").InnerText;
            z.State = root.SelectSingleNode("//response/results/result/address/state").InnerText;
            z.ZipCode = root.SelectSingleNode("//response/results/result/address/zipcode").InnerText;
            z.Latitude = decimal.Parse(root.SelectSingleNode("//response/results/result/address/latitude").InnerText);
            z.Longitude = decimal.Parse(root.SelectSingleNode("//response/results/result/address/longitude").InnerText);
        }
        Response.Close();

        return z;
    }


    public static ZillowEstimate GetChart(string zillowWebServiceId, string zpid)
    {
        //http://www.zillow.com/howto/api/GetSearchResults.htm

        var z = new ZillowEstimate();
        // Construct the url
        // var zEstimate = new decimal();        
        var url = String.Format("http://www.zillow.com/webservice/GetChart.htm?zws-id={0}&unit-type=percent&zpid={1}", zillowWebServiceId, zpid);

        // Make the HTTP request / get the response
        var Request = (System.Net.HttpWebRequest)WebRequest.Create(url);
        var Response = (HttpWebResponse)Request.GetResponse();

        // Parse the HTTP response into an XML document
        XmlDocument xml = new XmlDocument();
        xml.Load(Response.GetResponseStream());
        XmlElement root = xml.DocumentElement;

        //Return Code
        z.ReturnCode = int.Parse(root.SelectSingleNode("//message/code").InnerText);
        z.ReturnCodeMessage = root.SelectSingleNode("//message/text").InnerText;
        if (z.ReturnCode == 0)
        {
            z.Url = root.SelectSingleNode("//response/url").InnerText;
            z.Graphsanddata = root.SelectSingleNode("//response/graphsanddata").InnerText;
        }
        Response.Close();

        return z;
    }
}