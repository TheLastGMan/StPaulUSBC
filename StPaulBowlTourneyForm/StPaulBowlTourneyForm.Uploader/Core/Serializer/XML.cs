using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace StPaulBowlTourneyForm.Core.Serializer
{
	public class XML
	{
		public byte[] SerializeXml<T>(T source)
		{
			var ser = new XmlSerializer(typeof(T));
			using (var ms = new MemoryStream())
			{
				ser.Serialize(ms, source);
				return ms.GetBuffer();
			}
		}

		public T DeserializeXml<T>(Stream decodeStream)
		{
			//setup
			byte[] obuffer = new byte[decodeStream.Length];
			decodeStream.Read(obuffer, 0, obuffer.Length);
			decodeStream.Position = 0;
			string data = Encoding.UTF8.GetString(obuffer);

			//check if we can DeSerialize
			var ser = new XmlSerializer(typeof(T));
			var xmlRdr = XmlReader.Create(decodeStream);
			if (!ser.CanDeserialize(xmlRdr))
				throw new Exception("Unable to read input stream");

			//give result
			return (T)ser.Deserialize(xmlRdr);
		}

		public T DeserializeXml<T>(string xmlData, Encoding encoding)
		{
			byte[] buffer = encoding.GetBytes(xmlData);
			using (var ms = new MemoryStream(buffer))
				return DeserializeXml<T>(new MemoryStream(buffer));
		}
	}
}
