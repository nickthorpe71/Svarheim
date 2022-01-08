namespace Data
{
    public class EndpointModel
    {
        private readonly string _name;

        private int _level;

        public EndpointModel(string name, int level)
        {
            _name = name;
            _level = level;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}