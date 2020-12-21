using System;
using System.Collections.Generic;
using System.Text;

namespace Series
{
    class SeriesDivergenceException : Exception
    {
        public SeriesDivergenceException() { }



        public SeriesDivergenceException(string message): base(message) { }



        public SeriesDivergenceException(string message, Exception inner): base(message, inner) { }

    }
}
