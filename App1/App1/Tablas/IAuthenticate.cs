﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
}
