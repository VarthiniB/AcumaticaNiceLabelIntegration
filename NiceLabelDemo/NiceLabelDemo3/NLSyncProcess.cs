using System;
using PX.Data;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NiceLabelDemo1
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

            // var subKey = "06bd55b255ea4c0fb7707cba155c5d41";
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
                    if (order.Description.Equals("Printers"))
                    {
                      var x = CreateRequestPrinters("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Printers", subKey);

                    }
                    else
                    {
                        if (order.Description.Equals("Labels"))
                        {
                            var x = CreateRequestLabels("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-LabelCatalog", subKey);

                        }
                        else
                        {
                            if (order.Description.Equals("Label variables"))
                            {
                                //    var x = CreateRequestVar("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Variables", subKey);
                                //   order.Description = x;


                            }
                        }
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
                //req.Headers.Add("Ocp-Apim-Subscription-Key", "06bd55b255ea4c0fb7707cba155c5d41");
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";

                //string postData = "{   };";
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

                    foreach (JObject z in json)
                    {
                        NLLabelGraph labgraph = PXGraph.CreateInstance<NLLabelGraph>();
                        NLLabelList lab = new NLLabelList();
                                             

                        lab.LabelName = (string)z["itemPath"];
                        lab.LabelPath = (string)z["itemPath"];
                        lab.Nlid = (int)z["id"];

                       // NLLabelList.Insert(lab);
                      //  Actions.PressSave();
                       labgraph.Clear();
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
                //req.Headers.Add("Ocp-Apim-Subscription-Key", "06bd55b255ea4c0fb7707cba155c5d41");
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

                    foreach (JObject z in json)
                    {
                        NLPrinterGraph ptrgraph = PXGraph.CreateInstance<NLPrinterGraph>();
                        NLPrinters attNew = new NLPrinters();

                        attNew.PrinterName = (string)z["PrinterName"];
                       // attNew.Printcd = (string)z["DriverName"];

                        ptrgraph.Clear();
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

        //private static String CreateRequestVar(string url, string key)
        //{
        //    if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
        //    {
        //        WebRequest req = WebRequest.Create(url);
        //        req.Headers.Add("Ocp-Apim-Subscription-Key", "06bd55b255ea4c0fb7707cba155c5d41");
        //        req.Method = "POST";

        //        string postData = "{    \"FilePath\": \"/de12-folder/Labelv1.nlbl\",    \"FileVersion\": \"\",   \"Quantity\": \"1\",  \"Printer\": \"ZEBRA 105SL 203DPI-VAR\"};";

        //        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        //        // Set the ContentType property of the WebRequest.
        //        req.ContentType = "application/json";
        //        // Set the ContentLength property of the WebRequest.
        //        req.ContentLength = byteArray.Length;

        //        // Get the request stream.
        //        Stream dataStream = req.GetRequestStream();
        //        // Write the data to the request stream.
        //        dataStream.Write(byteArray, 0, byteArray.Length);
        //        // Close the Stream object.
        //        dataStream.Close();
        //        WebResponse response = req.GetResponse();
        //        //   req.Headers.Add(header.Key, header.Value);

        //        // Get the stream containing content returned by the server.    
        //        // The using block ensures the stream is automatically closed.
        //        using (dataStream = response.GetResponseStream())
        //        {
        //            // Open the stream using a StreamReader for easy access.
        //            StreamReader reader = new StreamReader(dataStream);
        //            // Read the content.
        //            string responseFromServer = reader.ReadToEnd();


        //            JObject json = JObject.Parse(responseFromServer);

        //            JObject x = (JObject)json.GetValue("Variables");

        //            JArray y = (JArray)x.GetValue("Variable");

        //            foreach (JObject z in y)
        //            {
        //                attributesClass attgraph = PXGraph.CreateInstance<attributesClass>();
        //                attributes attNew = new attributes();

        //                attNew.Attributeid = "/de12-folder/Labelv1.nlbl";
        //                attNew.Nlkey = (string)z["Name"];
        //                attNew.AcuKey = (string)z["Name"];
        //                attgraph.Clear();
        //                attgraph.assign(attNew);
        //            }


        //            // Close the response.
        //            response.Close();

        //            return ((HttpWebResponse)response).StatusDescription;

        //        }
        //    }
        //    else
        //    {
        //        throw (new ArgumentException("Invalid URL provided.", "url"));
        //    }
        //}


    }
}