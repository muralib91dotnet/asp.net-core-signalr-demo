namespace SignalRDemo.Entities
{
    public class SalesOrder
    {
        #region ctor

        public SalesOrder()
            : base()
        {
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public SalesOrderState States { get; set; }

        #endregion

        #region Methods


        #endregion

        #region Events

        #endregion
    }
}
