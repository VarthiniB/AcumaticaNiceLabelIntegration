using System;
using System.Net;
using System.IO;
using System.Text;
using PX.Data;
using NiceLabelDemo;
using NiceLabelDemo.Helper;

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

            var x = NLWebCalls.CreateRequestFromShipment("https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Print", cclass, Base.Shipping_Contact.Current.DisplayName +","+ Base.Shipping_Address.Current.AddressLine1 + "," + Base.Shipping_Address.Current.AddressLine2 + "," + Base.Shipping_Address.Current.AddressLine3, lab.LabelID.ToString(), skey.SubscriptionKey);
            var y = "Label is sent to printer";
            throw new PXException(y);

    }
      
    #endregion
  }
}