using System;

namespace SignalRDemo.Entities
{
    [Flags()]
    public enum SalesOrderState
    {
        Created = 1,

        Delivered = 2,

        Billed = 4,

        Paid = 8,

        Canceled = 16

    }
}
