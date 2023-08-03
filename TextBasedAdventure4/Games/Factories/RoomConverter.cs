//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//namespace TextBasedAdventure4.Games.Factories
//{
//    internal class RoomConverter : JsonConverter<Room>
//    {
//        public override Room? ReadJson(JsonReader reader, Type objectType, Room? existingValue, bool hasExistingValue, JsonSerializer serializer)
//        {
//            JObject jObject = JObject.Load(reader);
//            var room = jObject.ToObject<Room>();

//        }

//        public override void WriteJson(JsonWriter writer, Room? value, JsonSerializer serializer)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
