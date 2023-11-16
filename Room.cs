namespace ProjetNarratif
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        public List<string> inventory = new List<string>();
        internal abstract void ReceiveChoice(string choice);
    }
}
