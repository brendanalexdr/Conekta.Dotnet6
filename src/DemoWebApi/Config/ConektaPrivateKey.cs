﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Config;

public class ConektaPrivateKey
{
    public ConektaPrivateKey(string value)
    {
        Value = value;
    }

    public string Value { get; protected set; }
}