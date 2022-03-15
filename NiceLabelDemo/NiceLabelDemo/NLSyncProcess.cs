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
     }

        public static void AssignOrders(List<NLSyncPref> orders)
        {
            NLSyncProcess labgraph = PXGraph.CreateInstance<NLSyncProcess>();
           
            NLSubscriptionKey skey = PXSelect<NLSubscriptionKey,
                Where<NLSubscriptionKey.createdByID, Equal<Required<NLSubscriptionKey.createdByID>>>,
                OrderBy<Desc<NLSubscriptionKey.lastModifiedDateTime>>>.SelectWindowed(labgraph, 0, 1, labgraph.Accessinfo.UserID);

            var subKey = skey.SubscriptionKey;

            foreach (NLSyncPref order in orders)
            {
                try
                {
                    switch (order.Description)
                    {
                        case "Printers":
                            String x = NLWebCalls.CreateRequestPrinters("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Printers", subKey);
                            break;
                        case "Labels":
                            String y = NLWebCalls.CreateRequestLabels("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-LabelCatalog", subKey);
                            break;
                        case "Label variables":
                            //   String z = NLWebCalls.CreateRequestVar("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Variables", subKey);
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