using System;

namespace Attribute.Common.Attributes.Enumeration
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayValueAttribute : System.Attribute
    {
        #region [-- CONSTRUCTORS --]

        public DisplayValueAttribute(string displayValue)
        {
            this._displayValue = displayValue;
        }

        #endregion


        #region [-- PROPERTIES --]

        public string DisplayValue
        {
            get { return this._displayValue; }
            set { this._displayValue = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private string _displayValue;

        #endregion
    }
}
