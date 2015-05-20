using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ObjectExtensions
{
    public static class ObjectSerializerExtensions
    {
        /// <summary>
        /// Serialize an object to JSON.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string toJSON(this object obj)
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
            var result = (T)serializer.DeserializeObject(json);
            return result;
        }

        /// <summary>
        /// Serialize an object to an XML string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string toXML(this object obj)
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
            return (T)serializer.Deserialize(stringReader);
        }
    }
}
