using System;

namespace Attribute.Common.Attributes.Enumeration
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataValueAttribute : System.Attribute
    {
        #region [-- CONSTRUCTORS --]

        public DataValueAttribute(string dataValue)
        {
            this._dataValue = dataValue;
        }

        #endregion


        #region [-- PROPERTIES --]

        public string DataValue
        {
            get { return this._dataValue; }
            set { this._dataValue = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private string _dataValue;

        #endregion
    }
}
