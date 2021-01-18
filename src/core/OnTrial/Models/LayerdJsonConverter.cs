using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnTrial
{
    public class LayerdJsonConverter : JsonConverter
    {
        public override bool CanRead => base.CanRead;

        public override bool CanWrite => base.CanWrite;

        public override bool CanConvert(Type pTypeToConvert) => true;

        public override object ReadJson(JsonReader pReader, Type pObjectType, object pExistingValue, JsonSerializer pSerializer)
        {
            return this.ProcessToken(pReader);
        }

        public override void WriteJson(JsonWriter pWriter, object pValue, JsonSerializer pSerializer)
        {
            if (pSerializer != null)
                pSerializer.Serialize(pWriter, pValue);
        }

        private object ProcessToken(JsonReader pReader)
        {
            object processedObject = null;

            if (pReader == null)
                throw new ArgumentNullException();

            if (pReader.TokenType == JsonToken.StartObject)
            {
                Dictionary<string, object> dictionaryValue = new Dictionary<string, object>();
                while (pReader.Read() && pReader.TokenType != JsonToken.EndObject)
                {
                    //First read the key and capture the keys value before we read the reader again
                    string key = pReader.Value.ToString();

                    //Then read the reader again.
                    pReader.Read();
                    dictionaryValue.Add(key, this.ProcessToken(pReader));
                }
                processedObject = dictionaryValue;
            }
            else if (pReader.TokenType == JsonToken.StartArray)
            {
                List<object> arrayValue = new List<object>();
                while (pReader.Read() && pReader.TokenType != JsonToken.EndArray)
                {
                    arrayValue.Add(this.ProcessToken(pReader));
                }

                processedObject = arrayValue.ToArray();
            }
            else
                processedObject = pReader.Value;

            return processedObject;
        }
    }
}
