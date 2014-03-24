using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NHibernate;

namespace Huatongmis.Data
{
    public partial class HuatongmisDataContext
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