using System;
using System.Collections.Generic;
using System.Text;

namespace TeamOrganiser.Models
{
    public enum Sport
    {
        Football,
        Hockey,
        Basketball
    }

    public class Sports
    {
        public int ID { get; set; }
        public Sport Sport { get; set; }
    }

}
