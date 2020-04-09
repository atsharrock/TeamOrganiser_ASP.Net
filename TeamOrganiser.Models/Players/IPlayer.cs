﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamOrganiser.Models.Players
{
    public interface IPlayer
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string ContactNumber { get; set; }
        List<Sports> AssociatedSports { get; set; }
    }
}