using System;

namespace Attribute.Common.Attributes
{
    /// <summary>
    ///     Attribute for enumerations that should correspond to a specific
    ///     exception type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class BoundExceptionTypeAttribute : System.Attribute
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Specifies a bound exception type of the generic <see cref="System.Exception" /> exception.
        /// </summary>
        public BoundExceptionTypeAttribute()
            : this(typeof(Exception))
        {
        }

        /// <summary>
        ///     Specifies a bound exception of type <see cref="type" />.
        /// </summary>
        /// <param name="type">The exception type to bind.</param>
        public BoundExceptionTypeAttribute(Type type)
        {
            if (!type.IsSubclassOf(typeof(Exception)))
            {
                throw new ArgumentException("type");
            }

            this.BoundExceptionType = type;
        }

        /// <summary>
        ///     Specifies a bound exception of type <see cref="type" /> with a list of init parameters as defined by
        ///     <see cref="initParamTypes" />.
        /// </summary>
        /// <param name="type">The exception type to bind.</param>
        /// <param name="initParamTypes">A list of types that will be passed to the exception in order to instantiate it.</param>
        public BoundExceptionTypeAttribute(Type type, Type[] initParamTypes)
            : this(type)
        {
            this.InitParamTypes = initParamTypes;
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The exception type to bind.
        /// </summary>
        public Type BoundExceptionType { get; private set; }

        /// <summary>
        ///     The initialization parameter types. Each type in this list corresponds to a single parameter.
        /// </summary>
        public Type[] InitParamTypes
        {
            get { return this._initParamTypes; }
            set { this._initParamTypes = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private Type[] _initParamTypes =
        {
            typeof(string),
            typeof(Exception)
        };

        #endregion
    }
}
