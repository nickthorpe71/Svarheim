namespace Data
{
    public class ServiceModel
    {
        private readonly string _name;
        private readonly ServiceModel[] _dependencies;
        private readonly EndpointModel[] _endpoints;

        public ServiceModel(string name, ServiceModel[] dependencies, EndpointModel[] endpoints)
        {
            _name = name;
            _dependencies = dependencies;
            _endpoints = endpoints;
        }

        public string Name
        {
            get { return _name; }
        }

        public ServiceModel[] Dependencies
        {
            get { return _dependencies; }
        }

        public EndpointModel[] Endpoints
        {
            get { return _endpoints; }
        }
    }
}