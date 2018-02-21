using SignalRDemo.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<SalesOrder> CreateSalesOrderAsync(SalesOrder salesOrder, CancellationToken token);
    }

    public class SalesOrderRepository : ISalesOrderRepository
    {
        private static List<SalesOrder> _salesOrders = new List<SalesOrder>();

        #region ctor

        public SalesOrderRepository()
            : base()
        {
        }

        #endregion

        #region Methods

        public async Task<SalesOrder> CreateSalesOrderAsync(SalesOrder salesOrder, CancellationToken token)
        {
            salesOrder.Id = _salesOrders.Count + 1;
            _salesOrders.Add(salesOrder);
            return await Task.FromResult(salesOrder);
        }

        #endregion
    }
}
