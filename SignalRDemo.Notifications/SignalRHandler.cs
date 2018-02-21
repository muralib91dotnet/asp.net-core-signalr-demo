using Microsoft.AspNetCore.SignalR.Client;
using SignalRDemo.Entities;
using System.Threading.Tasks;
using Unity;

namespace SignalRDemo.Notifications
{
    public interface ISignalRHandler
    {
        Task InitializeAsync(string signalRAddress);
        Task DisconnectAsync();
    }

    public class SignalRHandler : ISignalRHandler
    {
        private IUnityContainer _container;
        private HubConnection _connection;


        #region ctor

        public SignalRHandler(IUnityContainer container)
            : base()
        {
            _container = container;
        }

        #endregion

        #region Methods

        public async Task InitializeAsync(string signalRAddress)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(signalRAddress)
                .Build();

            #region Methods

            _connection.On<SalesOrder>(SalesOrderEvents.Created, salesOrder =>
            {
                var events = _container.Resolve<INotificationEvents>();
                if (events != null)
                {
                    events.RaiseSalesOrderCreatedEvent(new SalesOrderCreatedEventArgs(salesOrder));
                }
            });

            #endregion

            // Connect
            //
            await this.ConnectAsync(_connection);
        }

        private async Task ConnectAsync(HubConnection connection)
        {
            while (true)
            {
                try
                {
                    await connection.StartAsync();
                    return;
                }
                catch (System.Exception)
                {
                    await Task.Delay(1000);
                }
            }
        }

        public async Task DisconnectAsync()
        {
            if (_connection != null) await _connection.DisposeAsync();
        }

        #endregion

        #region Events

        #endregion

    }
}
