using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    /// <summary>
    /// CustomExceptionClass and inherit
    /// Exception class  
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CensusAnalyserException : Exception
    {
        string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public CensusAnalyserException(string msg) : base(msg)
        {
            this.message = msg;
        }
        /// <summary>
        /// Gets the ge message.
        /// </summary>
        /// <value>
        /// The ge message.
        /// </value>
        public string GetMessage { get => this.message; }
    }
}
