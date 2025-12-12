using System.Collections.Generic;

namespace Meancat.EliteBinding.Reader
{
    public class CommandNames
    {
        private Dictionary<string, string> Commands { get; set; }

        public CommandNames(Dictionary<string, string> commands)
        {
            Commands = commands;
        }

        public string? GetText(string command) => Commands.TryGetValue(command, out var text) ? text : null;
    }
}
