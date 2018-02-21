using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Entities;
using SignalRDemo.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo.WebApi.Controllers
{
    [Route("api/SalesOrders")]
    public class SalesOrdersController : Controller
    {
        private readonly ISalesOrderRepository _repository;
        private readonly IHubContext<NotificationHub> _hubContext;

        #region ctor

        public SalesOrdersController(ISalesOrderRepository repository, IHubContext<NotificationHub> hubContext)
            : base()
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        #endregion

        #region Methods

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesOrder([FromRoute] int id, CancellationToken cancellationToken)
        {
            SalesOrder result = await _repository.GetSalesOrderAsync(id, cancellationToken);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateSalesOrder([FromBody] SalesOrder salesOrder, CancellationToken cancellationToken)
        {
            var result = await _repository.CreateSalesOrderAsync(salesOrder, cancellationToken);
            await _hubContext.Clients.All.InvokeAsync(SalesOrderEvents.Created, result);
            return this.CreatedAtAction("GetSalesOrder", new { id = result.Id }, result);
        }


        #endregion
    }
}
