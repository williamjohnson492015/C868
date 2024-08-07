using System;


namespace C868
{
    class LoginException : ApplicationException
    {
        public LoginException(string loginErr) : base(loginErr)
        {

        }
    }
}