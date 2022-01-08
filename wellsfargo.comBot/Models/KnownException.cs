using System;

namespace wellsfargo.comBot.Models
{
    public class KnownException:Exception
    {
        public KnownException(string s):base(s)
        {
            
        }
    }
}