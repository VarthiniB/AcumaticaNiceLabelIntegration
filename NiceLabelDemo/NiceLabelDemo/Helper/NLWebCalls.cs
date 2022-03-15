using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PX.Data;

namespace NiceLabelDemo.Helper
{
    class NLWebCalls
    {

        public static String CreateRequestFromShipment(string url, string cclass, string add, string labelid, string key)
        {

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                WebRequest req = WebRequest.Create(url);
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";
                string postData = "";

                postData = "{    \"FilePath\": \"" + labelid + "\",    \"FileVersion\": \"\",   \"Quantity\": \"1\",  \"Printer\": \"ZEBRA 105SL 203DPI-VAR\", \"PrinterSettings\": \"\",  \"Variables\": [   {   \"address\": \"" + add + "\" }  ]};";

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

        public static String CreateRequestPrinters(string url, string key)
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

                    NLPrinterGraph ptrgraph = PXGraph.CreateInstance<NLPrinterGraph>();
                    foreach (JObject z in json)
                    {
                        ptrgraph.Clear();
                        NLPrinter attNew = new NLPrinter();

                        attNew.PrinterName = (string)z["PrinterName"];
                        // attNew.Printcd = (string)z["DriverName"];

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


        public static String CreateRequestLabels(string url, string key)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {



                WebRequest req = WebRequest.Create(url);
                //req.Headers.Add("Ocp-Apim-Subscription-Key", "06bd55b255ea4c0fb7707cba155c5d41");
                req.Headers.Add("Ocp-Apim-Subscription-Key", key);
                req.Method = "POST";

                string postData = "{\"CatalogRoot\": \"/demoFinal\",\"SubscriptionKey\": \"" + key + "\"}";
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
                        lab.LabelID = (int)z["id"];

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


        //public static String CreateRequestVar(string url, string key)
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
        // attributesClass attgraph = PXGraph.CreateInstance<attributesClass>();
        //            foreach (JObject z in y)
        //            {
        //               
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
