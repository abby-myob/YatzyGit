using System.Collections.Generic;

namespace YatzyLibrary
{
    public class YatzyGame
    {
        public readonly List<Person> _people = new List<Person>();
        
        public YatzyGame(List<string> names)
        {
            foreach (var name in names)
            {
                _people.Add(new Person(name));
            }
        }
    }
}