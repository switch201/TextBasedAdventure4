using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextBasedAdventure4.GameObjects.Factories
{
    public static class GameObjectFactory
    {
        private static string baseLevelPath = "Content";

        public static Room CreateRoom(string objectName)
        {
            var obj = JsonConvert.DeserializeObject<Room>(Util.Readfile($"{baseLevelPath}/Rooms/{objectName}.json"));
            obj.Name = objectName;
            return obj;
        }

        public static Game CreateGame(string objectName)
        {
            return JsonConvert.DeserializeObject<Game>(Util.Readfile($"{baseLevelPath}/{objectName}.json"), new GameConverter());
        }
    }
}
