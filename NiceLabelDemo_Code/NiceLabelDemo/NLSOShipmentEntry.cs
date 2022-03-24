using System;
using System.Net;
using System.IO;
using System.Text;
using PX.Data;
using NiceLabelDemo;
using NiceLabelDemo.Helper;
using System.Collections.Generic;
using System.Collections;

namespace PX.Objects.SO
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class NLSOShipmentEntry_Extension : PXGraphExtension<SOShipmentEntry>
  {
        public PXSetup<NLSubscriptionKey> SubSetup;
        #region Event Handlers

        public PXAction<PX.Objects.SO.SOShipment> PrintNiceLabel;
  
    [PXButton(CommitChanges = true)]
    [PXUIField(DisplayName = "Print NiceLabel")]
    public IEnumerable printNiceLabel(PXAdapter adapter)
    {
            var customer = Base.customer;
            var customerclass = customer.Current.CustomerClassID;
            
            NLClassLabelPref lab = PXSelect<NLClassLabelPref, Where<NLClassLabelPref.customerClassID, Equal<Required<NLClassLabelPref.customerClassID>>>>.Select(Base, Base.customer.Current.CustomerClassID);

            string subkey = SubSetup.Current.SubscriptionKey;

            PXLongOperation.StartOperation(Base, delegate ()
			{
                NLWebCalls.CreateRequestFromShipment(customerclass, Base.Shipping_Contact.Current.DisplayName, Base.Shipping_Address.Current.AddressLine1, Base.Shipping_Address.Current.AddressLine2, Base.Shipping_Address.Current.AddressLine3, lab.LabelID.ToString(), subkey);
            });  

            return adapter.Get();

        }

        #endregion

    }
}