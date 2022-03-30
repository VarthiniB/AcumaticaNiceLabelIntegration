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

            //var shippingcontact = Base.Shipping_Contact;
            SOShipmentContact shippingcontact = Base.Shipping_Contact.SelectSingle();
            SOShipmentAddress shippingaddress = Base.Shipping_Address.SelectSingle();
            //var displayname = shippingcontact.Current.DisplayName;
            //var test = PXSelect<SOShipmentContact, Where<SOShipmentContact.contactID, Equal<Required<SOShipment.shipContactID>>>>.Select(Base,Base.CurrentDocument.Current.ShipContactID);

            NLClassLabelPref lab = PXSelect<NLClassLabelPref, Where<NLClassLabelPref.customerClassID, Equal<Required<NLClassLabelPref.customerClassID>>>>.Select(Base, Base.customer.Current.CustomerClassID);
            NLLabel labName = PXSelect<NLLabel, Where<NLLabel.labelID, Equal<Required<NLLabel.labelID>>>>.Select(Base, lab.LabelID);

            string subkey = SubSetup.Current.SubscriptionKey;

            PXLongOperation.StartOperation(Base, delegate ()
            {
                NLWebCalls.CreateRequestFromShipment(customerclass, shippingcontact.DisplayName, shippingaddress.AddressLine1, shippingaddress.AddressLine2, shippingaddress.AddressLine3, labName.LabelName.ToString(), subkey);
            });

            return adapter.Get();

        }

        #endregion

    }
}