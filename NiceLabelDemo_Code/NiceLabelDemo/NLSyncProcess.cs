using System;
using PX.Data;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;
using NiceLabelDemo.Helper;

namespace NiceLabelDemo
{
    public class NLSyncProcess : PXGraph<NLSyncProcess>
    {
   
    public PXCancel<NLSyncPref> Cancel;
    public PXProcessing<NLSyncPref> SyncPrefs;

        public PXSetup<NLSubscriptionKey> AutoNumSetup;

        protected virtual IEnumerable syncPrefs()
        {
          PXResultset<NLSyncPref> res = new PXResultset<NLSyncPref>();

            NLSyncPref syncobj = new NLSyncPref();
            syncobj.Description = "Labels";
            res.Add(new PXResult<NLSyncPref>(syncobj));
            NLSyncPref syncobj1 = new NLSyncPref();
            syncobj1.Description = "Printers";
            res.Add(new PXResult<NLSyncPref>(syncobj1));
            NLSyncPref syncobj2 = new NLSyncPref();
            syncobj2.Description = "Label variables";
            res.Add(new PXResult<NLSyncPref>(syncobj2));
           return res;
        }
         public NLSyncProcess()
         {            
               SyncPrefs.SetProcessDelegate(AssignOrders);
                string subkey = AutoNumSetup.Current.SubscriptionKey;
         }

          

        public static void AssignOrders(List<NLSyncPref> orders)
        {
            NLSyncProcess labgraph = PXGraph.CreateInstance<NLSyncProcess>();
          
           string subkey = labgraph.AutoNumSetup.Current.SubscriptionKey;
            foreach (NLSyncPref order in orders)
            {
                try
                {
                    switch (order.Description)
                    {
                        case "Printers":
                            NLWebCalls.CreateRequestPrinters("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Printers", subkey);
                            break;
                        case "Labels":
                            NLWebCalls.CreateRequestLabels("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-LabelCatalog", subkey);
                            break;
                        case "Label variables":
                            // NLWebCalls.CreateRequestVar("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Variables", subKey);
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception e)
                {
                    PXProcessing<NLSyncPref>.SetError(orders.IndexOf(order), e);
                }
            }

        }



    }
}