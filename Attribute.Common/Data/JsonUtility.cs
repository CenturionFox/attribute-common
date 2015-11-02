using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Attribute.Common.Data
{
    /// <summary>
    ///     Utility for serializing and deserializing Json data.
    /// </summary>
    public static class JsonUtility
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        /// Deserialzes a <typeparamref name="TObj" /> from a
        /// </summary>
        /// <typeparam name="TObj">The type of the object.</typeparam>
        /// <param name="inputStream">The input stream.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Unable to deserialize as an abstract type.</exception>
        public static TObj DeserializeObject<TObj>(Stream inputStream)
        {
            if (typeof(TObj).IsAbstract)
            {
                throw new ArgumentException("Unable to deserialize as an abstract type.", nameof(TObj));
            }

            var serializer = new DataContractJsonSerializer(typeof(TObj));

            return (TObj)serializer.ReadObject(inputStream);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <typeparam name="TObj">The type of the object.</typeparam>
        /// <param name="jsonObject">The json object.</param>
        /// <param name="outputStream">The output stream.</param>
        public static void SerializeObject<TObj>(TObj jsonObject, ref Stream outputStream)
        {
            var serializer = new DataContractJsonSerializer(typeof(TObj));

            serializer.WriteObject(outputStream, jsonObject);
        }

        #endregion
    }
}
