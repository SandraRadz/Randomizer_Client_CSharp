using System;

namespace Randomizer_Client.Models
{
    public class Request
    {

        private int _from;
        private int _to;
        private int _count;
        private DateTime _time;

        public Request(int from, int to, int count, DateTime time)
        {
            _from = from;
            _to = to;
            _count = count;
            _time = time;
        }
        

        public int From
        {
            get { return _from;}
            set { _from = value; }
        }
        public int To
        {
            get { return _to; }
            set { _to = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

    }
}
