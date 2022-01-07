namespace Data
{
    public class EndpointModel
    {
        private readonly string _name;

        public EndpointModel(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}