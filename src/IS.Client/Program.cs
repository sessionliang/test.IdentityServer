﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = DMWebClient.GetClientToken();
            DMWebClient.CallApi(token);
        }
    }
}
