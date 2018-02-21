using SignalRDemo.Entities;
using System;

namespace SignalRDemo.Notifications
{
    public class SalesOrderCreatedEventArgs : EventArgs
    {
        #region ctor

        public SalesOrderCreatedEventArgs(SalesOrder salesOrder)
            : base()
        {
            this.SalesOrder = salesOrder;
        }

        #endregion

        #region Properties

        public SalesOrder SalesOrder { get; }

        #endregion
    }
}
