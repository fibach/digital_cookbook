namespace CosmosDbAdapter
{
    public class CosmosDbOptions
    {
        public CosmosDbOptions()
        {
            ContainerIds = new List<string>();
        }

        public string? EndpointUri { get; set; }
        public string? PrimaryKey {  get; set; }
        public string? ApplicationName { get; set; }
        public string? DatabaseId { get; set; }
        public List<string> ContainerIds { get; set; }
    }
}
