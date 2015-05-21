using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ObjectExtensions
{
    public static class ObjectSerializerExtensions
    {
        /// <summary>
        /// Serialize an object to JSON.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// Deserialize a JSON to an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="json">JSON formatted string</param>
        /// <returns></returns>
        public static T DeserializeFromJSON<T>(this object obj, string json)
        {
            var serializer = new JavaScriptSerializer();
            obj = (T)serializer.DeserializeObject(json);
            return (T)obj;
        }

        /// <summary>
        /// Serialize an object to an XML string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToXML(this object obj)
        {
            var x = new XmlSerializer(obj.GetType());
            var stringwriter = new System.IO.StringWriter();
            x.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }

        /// <summary>
        /// Deserialize xml to an object of Type this.
        /// </summary>
        /// <typeparam name="T">The type you want to deserialize too.</typeparam>
        /// <param name="obj"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeFromXMLString<T>(this object obj, string xml)
        {
            var stringReader = new System.IO.StringReader(xml);
            var serializer = new XmlSerializer(typeof(T));
            obj = (T) serializer.Deserialize(stringReader);
            return  (T)obj;
        }

        /// <summary>
        /// This will serialize an object to binary in a memory stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this object obj)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            return stream;

        }

        /// <summary>
        /// This will deserialize a memory stream into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeserializeFromMemoryStream<T>(this object obj, MemoryStream stream)
        {
            var formatter = new BinaryFormatter();
            obj = (T)formatter.Deserialize(stream);
            return (T) obj;

        }

        /// <summary>
        /// This will serialize an object to a SOAP message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSoapMessage<T>(this object obj)
        {
            var stringWriter = new System.IO.StringWriter();
            var myTypeMapping = (new SoapReflectionImporter().ImportTypeMapping(typeof(T)));
            var serializer = new XmlSerializer(myTypeMapping);
            serializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();

        }

        /// <summary>
        /// This will deserialize a soap message to a class of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="SOAP"></param>
        /// <returns></returns>
        public static T DeserializeFromSoapMessage<T>(this object obj, string SOAP)
        {
            var myTypeMapping = (new SoapReflectionImporter().ImportTypeMapping(typeof(T)));
            var serializer = new XmlSerializer(myTypeMapping);
            obj = (T) obj;
            return (T) obj;
        }
    }
}
