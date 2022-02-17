using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo1
{
  public class NLPrinterGraph : PXGraph<NLPrinterGraph, NLPrinters>
  {
    
    public SelectFrom<NLPrinters>.View ptr;
  
    #region Event Handlers
    public void assign(NLPrinters order)
        {
            
            NLPrinters ptrs = new NLPrinters();
            ptrs.PrinterName = order.PrinterName;
            ptrs.IsActive = true;
           
            ptr.Insert(ptrs);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
        }
    #endregion
  }
}