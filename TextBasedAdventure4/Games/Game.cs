using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TextBasedAdventure4.GameObjects
{
    public class Game
    {
        public Game()
        {
            Rooms = new List<Room>();
        }
        public List<Room> Rooms { get; private set; }

        public Player player;

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetObjectsRoom(GameObject gameObject)
        {
            return Rooms.Where(x => x.Contents.Contains(gameObject)).Single();
        }

        public void Start()
        {
            var player1 = new Player();
            player1.Name = "player1";
            this.player = player1;
            Rooms.First().AddObject(player1);
        }
    }
}
