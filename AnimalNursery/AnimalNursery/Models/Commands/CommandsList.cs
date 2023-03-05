namespace AnimalNursery.Models.Commands
{
    public class CommandsList
    {
     
        
        public List<Command> _commands;

        /*public CommandsList(string item)
        {
            _commands = new List<Command>();
            ToList(item);
        }*/
        public CommandsList()
        {
            _commands = new List<Command>();
        }

        public void ToList(string item)
        {
            var s = item.Split(", ");
            foreach (String c in s)
            {
                Command cm = new Command(c);

                _commands.Add(cm);
            }
            //return _commands;
        }

        public string ConvertToString()
        {
            /*List<string> strings = new List<string>();
            foreach(Command item in _commands)
            {
                strings.Add(item.ToString());
            }*/
            return string.Join(", ", _commands);
        }
    }
}
