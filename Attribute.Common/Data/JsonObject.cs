using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Attribute.Common.Data
{
    /// <summary>
    /// Base class for JSON-serialized objects.
    /// </summary>
    [DataContract]
    public abstract class JsonObject
    {
        /// <summary>
        /// Deserialzes a <typeparamref name="TObj"/> from a 
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static TObj DeserializeObject<TObj>(Stream inputStream) where TObj : JsonObject
        {
            if (typeof(TObj).IsAbstract)
            {
                throw new ArgumentException("Unable to deserialize as an abstract type.", nameof(TObj));
            }

            var serializer = new DataContractJsonSerializer(typeof(TObj));

            return (TObj)serializer.ReadObject(inputStream);
        }

        public static void SerializeObject<TObj>(TObj jsonObject, ref Stream outputStream) where TObj : JsonObject
        {
            var serializer = new DataContractJsonSerializer(typeof(TObj));

            serializer.WriteObject(outputStream, jsonObject);
        }
    }
}
