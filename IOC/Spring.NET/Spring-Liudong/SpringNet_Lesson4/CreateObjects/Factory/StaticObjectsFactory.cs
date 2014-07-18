﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateObjects
{
    public static class StaticObjectsFactory
    {
        public static PersonDao CreateInstance()
        {
            return new PersonDao();
        }
    }
}
