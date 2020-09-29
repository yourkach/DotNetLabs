using System;

namespace DotNet.Base
{
    public class PersonalComputerException : Exception
    {
        protected PersonalComputerException(string msg = "") : base(msg)
        {
        }
    }

    public class ComputerIsWorkingException : PersonalComputerException
    {
        public ComputerIsWorkingException(string msg = "") : base(msg)
        {
        }
    }
}