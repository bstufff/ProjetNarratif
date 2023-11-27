using ProjetNarratif.Rooms;
using System.Diagnostics;
namespace ProjetNarratif
{
    internal class Game
    {
        List<Room> rooms = new();
        internal Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        
        static string nextRoom = "";

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }
        
        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal string CurrentRoomOptions => currentRoom.CreateOptions();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }
        internal static void DisplayInv() {
            if (!(Room.inventory.Count == 0)) {
                Console.WriteLine("Inventaire : \n====================");
                foreach (Room.Item item in Room.inventory)
                {
                    Console.WriteLine($"{item.name} x {item.quantity}");
                }
                Console.WriteLine("\n");
            }
            
        }
        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
    }
}
