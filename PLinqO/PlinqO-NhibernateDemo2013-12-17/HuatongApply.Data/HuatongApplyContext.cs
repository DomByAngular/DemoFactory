using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NHibernate;
using HuatongApply.Data;

namespace HuatongApply.Data
{
    public partial class HuatongApplyContext
    {
        // Place your custom code here.
        
        #region Override Methods

        protected override string GetConnectionString(string databaseName)
        {
            return base.GetConnectionString(databaseName);
        }

        #endregion
    }
}