using System;
using System.Text;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Converters
{
    public class MacroCaseEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string enumString = value.ToString();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < enumString.Length; i++)
            {
                char c = enumString[i];
                if (char.IsUpper(c) && i > 0)
                {
                    builder.Append('_');
                }

                builder.Append(c);
            }

            string macroCase = builder.ToString().ToUpperInvariant();
            writer.WriteValue(macroCase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string enumString = reader.Value.ToString().Replace("_", "").ToLower();

                foreach (var name in Enum.GetNames(objectType))
                {
                    if (name.ToLowerInvariant() == enumString)
                    {
                        return Enum.Parse(objectType, name);
                    }
                }

                throw new JsonSerializationException($"Unknown enum value of '{enumString}'");
            }

            throw new JsonSerializationException($"Unexpected token {reader.TokenType}");
        }
    }
}