namespace Data
{
    public class AppModel
    {
        private readonly string _name;
        private readonly ServiceModel[] _services;

        public AppModel(string name, ServiceModel[] services)
        {
            _name = name;
            _services = services;
        }

        public string Name
        {
            get { return _name; }
        }

        public ServiceModel[] Services
        {
            get { return _services; }
        }
    }
}
