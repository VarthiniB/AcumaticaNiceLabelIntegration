using System;
using System.Net;
using System.IO;
using System.Text;
using PX.Data;
using NiceLabelDemo;

namespace PX.Objects.SO
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class NLSOShipmentEntry_Extension : PXGraphExtension<SOShipmentEntry>
  {
    #region Event Handlers

    public PXAction<PX.Objects.SO.SOShipment> PrintNiceLabel;
  
    [PXButton(CommitChanges = true)]
    [PXUIField(DisplayName = "Print NiceLabel")]
    protected void printNiceLabel()
    {
            var customer = Base.customer;
            var cclass = customer.Current.CustomerClassID;

            NLClassLabelPref lab = PXSelect<NLClassLabelPref, Where<NLClassLabelPref.customerClassID, Equal<Required<NLClassLabelPref.customerClassID>>>>.Select(Base, Base.customer.Current.CustomerClassID);

            NLSubscriptionKey skey = PXSelect<NLSubscriptionKey,
                Where<NLSubscriptionKey.createdByID, Equal<Required<NLSubscriptionKey.createdByID>>>,
                OrderBy<Desc<NLSubscriptionKey.lastModifiedDateTime>>>.SelectWindowed(Base, 0, 1, Base.Accessinfo.UserID);

            var x = CreateRequest("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Print", cclass, Base.Shipping_Contact.Current.DisplayName +","+ Base.Shipping_Address.Current.AddressLine1 + "," + Base.Shipping_Address.Current.AddressLine2 + "," + Base.Shipping_Address.Current.AddressLine3, lab.LabelID.ToString(), skey.SubscriptionKey);
            var y = "Label is sent to printer";
            throw new PXException(y);

    }
      
    private static String CreateRequest(string url,string cclass, string add, string labelid, string key)
        {         

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                WebRequest req = WebRequest.Create(url);
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";
                string postData = "";


             
                postData = "{    \"FilePath\": \""+ labelid+"\",    \"FileVersion\": \"\",   \"Quantity\": \"1\",  \"Printer\": \"ZEBRA 105SL 203DPI-VAR\", \"PrinterSettings\": \"\",  \"Variables\": [   {   \"address\": \"" + add + "\" }  ]};";


                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                req.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                req.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = req.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                WebResponse response = req.GetResponse();
                //   req.Headers.Add(header.Key, header.Value);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                   // Console.WriteLine(responseFromServer);
                }

                // Close the response.
                response.Close();

                return ((HttpWebResponse)response).StatusDescription;
            }
            else
            {
                throw (new ArgumentException("Invalid URL provided.", "url"));
            }
        }  



    #endregion
  }
}