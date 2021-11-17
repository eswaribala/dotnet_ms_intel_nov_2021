namespace InventoryService
{
    public class ConsulOption
    {
        /// <summary>
        ///  service name 
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        ///  Service IP
        /// </summary>
        public string ServiceIP { get; set; }

        /// <summary>
        ///  Service port
        /// </summary>
        public int ServicePort { get; set; }

        /// <summary>
        ///  Service health check address
        /// </summary>
       // public string ServiceHealthCheck { get; set; }

        /// <summary>
        ///  Consul address
        /// </summary>
        public string Address { get; set; }
    }
}
