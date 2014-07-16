namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PlainResultFormatter : IResultFormatter
    {
        public PlainResultFormatter()
        {
        }

        public PlainResultFormatter(SerializationInfo info, StreamingContext context)
        {
        }

        public string Format(string name, string moves)
        {
            return name + " --> " + moves + " moves";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
