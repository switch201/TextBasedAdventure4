using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.GameObjects;

namespace TextBasedAdventure4.Games.Factories
{
    internal abstract class GameObjectConverter<T> : JsonConverter<T> where T : GameObject
    {
        protected T CreateGameObject(JObject gameObject)
        {
            T result = gameObject.ToObject<T>();
            var sucess = Enum.TryParse<ConsoleColor>((string)gameObject["Color"], true, out ConsoleColor color);
            return result;
        }
    }
}
