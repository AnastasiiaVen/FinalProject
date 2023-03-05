namespace AnimalNursery.Models.Commands
{
    public class CommandsList
    {
        public List<Command> _commands;

        public CommandsList(String commands)
        {
            ToList(commands);
        }
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
        }

        public string ConvertToString()
        {
            return string.Join(", ", _commands);
        }
    }
}
