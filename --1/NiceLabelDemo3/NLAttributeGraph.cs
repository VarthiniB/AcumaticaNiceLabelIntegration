using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLAttributeGraph : PXGraph<NLAttributeGraph, NLAttributes>
  {
    public SelectFrom<NLAttributes>.View att;
    #region Event Handlers
    public void assign(NLAttributes order)
     {
            //Modify the number of assigned orders for the employee.
            NLAttributes atts = new NLAttributes();            
            atts.NLAttributeName = order.NLAttributeName;
          
            atts.AttributeID = order.AttributeID;

            att.Insert(atts);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
    }
  
    #endregion
  }
}