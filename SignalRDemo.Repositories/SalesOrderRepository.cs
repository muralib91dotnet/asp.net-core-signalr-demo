using SignalRDemo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<SalesOrder> CreateSalesOrderAsync(SalesOrder salesOrder, CancellationToken token);

        Task<SalesOrder> GetSalesOrderAsync(int id, CancellationToken cancellationToken);
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
            salesOrder.States = SalesOrderState.Created;
            _salesOrders.Add(salesOrder);
            return await Task.FromResult(salesOrder);
        }

        public async Task<SalesOrder> GetSalesOrderAsync(int id, CancellationToken cancellationToken)
        {
            var result = _salesOrders.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(result);
        }

        #endregion
    }
}
