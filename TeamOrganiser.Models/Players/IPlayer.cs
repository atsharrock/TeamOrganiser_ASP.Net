using System;
using System.Collections.Generic;
using System.Text;

namespace TeamOrganiser.Models.Players
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string ContactNumber { get; set; }
    }
}
