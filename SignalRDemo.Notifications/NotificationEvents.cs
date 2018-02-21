using System;

namespace SignalRDemo.Notifications
{
    public interface INotificationEvents
    {
        #region Methods

        void RaiseSalesOrderCreatedEvent(SalesOrderCreatedEventArgs e);

        #endregion

        #region Events

        event EventHandler<SalesOrderCreatedEventArgs> SalesOrderCreated;

        #endregion
    }

    public class NotificationEvents : INotificationEvents
    {
        #region ctor

        public NotificationEvents()
            : base()
        {
        }

        #endregion

        #region Methods

        public void RaiseSalesOrderCreatedEvent(SalesOrderCreatedEventArgs e)
        {
            this.SalesOrderCreated?.Invoke(this, e);
        }

        #endregion

        #region Events

        public event EventHandler<SalesOrderCreatedEventArgs> SalesOrderCreated;

        #endregion
    }
}
