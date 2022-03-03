using System;
using PX.Data;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NiceLabelDemo
{
    public class NLSyncProcess : PXGraph<NLSyncProcess>
  {   
    public PXCancel<NLSyncPref> Cancel;
    public PXProcessing<NLSyncPref,
        Where<NLSyncPref.isActive, Equal<True>>> SyncPrefs;
      
     public NLSyncProcess()
     {
            
           SyncPrefs.SetProcessDelegate(AssignOrders);
                      
     }
        public static void AssignOrders(List<NLSyncPref> orders)
        {

            NLSyncProcess labgraph = PXGraph.CreateInstance<NLSyncProcess>();
            NLSubscriptionKey skey = new NLSubscriptionKey();

            skey = PXSelect<NLSubscriptionKey,
                Where<NLSubscriptionKey.createdByID, Equal<Required<NLSubscriptionKey.createdByID>>>,
                OrderBy<Desc<NLSubscriptionKey.lastModifiedDateTime>>>.SelectWindowed(labgraph, 0, 1, labgraph.Accessinfo.UserID);

            var subKey = skey.SubscriptionKey;

            foreach (NLSyncPref order in orders)
            {
                try
                {
               
                    switch(order.Description)
                    {
                        case "Printers":
                            var x = CreateRequestPrinters("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Printers", subKey);
                            break;
                        case "Labels":
                            var y = CreateRequestLabels("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-LabelCatalog", subKey);
                            break;
                        case "Label variables":
                         //   var z = CreateRequestVar("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Variables", subKey);
                            break;
                    }
                }
                catch (Exception e)
                {
                    PXProcessing<NLSyncPref>.SetError(orders.IndexOf(order), e);
                }
            }

        }

        private static String CreateRequestLabels(string url, string key)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                WebRequest req = WebRequest.Create(url);
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";

                string postData = "{\"CatalogRoot\": \"/demoFinal\",\"SubscriptionKey\": \""+key+"\"}";
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


                // Get the stream containing content returned by the server.    
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();


                    JArray json = JArray.Parse(responseFromServer);
                    NLLabelGraph labgraph = PXGraph.CreateInstance<NLLabelGraph>();
                    foreach (JObject z in json)
                    {
                        labgraph.Clear();
                        NLLabel lab = new NLLabel();                                             

                        lab.LabelName = (string)z["itemPath"];
                        lab.LabelPath = (string)z["itemPath"];
                        lab.Nlid = (int)z["id"];
                    
                        labgraph.assign(lab);
                    }
                    // Close the response.
                    response.Close();
                    return ((HttpWebResponse)response).StatusDescription;

                }
            }
            else
            {
                throw (new ArgumentException("Invalid URL provided.", "url"));
            }
        }

        private static String CreateRequestPrinters(string url, string key)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                WebRequest req = WebRequest.Create(url);
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";

                string postData = "{   };";

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


                    JArray json = JArray.Parse(responseFromServer);
                    NLPrinterGraph ptrgraph = PXGraph.CreateInstance<NLPrinterGraph>();
                    foreach (JObject z in json)
                    {

                        ptrgraph.Clear();
                        NLPrinter attNew = new NLPrinter();

                        attNew.PrinterName = (string)z["PrinterName"];
                        ptrgraph.assign(attNew);
                    }
                    // Close the response.
                    response.Close();

                    return ((HttpWebResponse)response).StatusDescription;

                }
            }
            else
            {
                throw (new ArgumentException("Invalid URL provided.", "url"));
            }
        }

       
    }
}