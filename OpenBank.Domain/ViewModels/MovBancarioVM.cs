﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class MovBancarioVM
    {
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public decimal Valor { get; set; }
    }
}