namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SeparatorResultFormatter : IResultFormatter
    {
        private string separator;

        public SeparatorResultFormatter(string stringSeparator)
        {
            this.separator = stringSeparator;
        }

        public SeparatorResultFormatter(SerializationInfo info, StreamingContext context)
        {
            this.separator = (string)info.GetValue("separator", typeof(string));
        }

        public string Format(string name, string moves)
        {
            return string.Format("{2} {0} {2} {1} moves", name, moves, this.separator);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("separator", this.separator);
        }
    }
}
