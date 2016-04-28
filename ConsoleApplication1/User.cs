using System;

namespace SocketServer
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            user = "Margaret";
            Dt = DateTime.Now;
            value = rand.Next(-100, 101) / 10f;
        }
        public Guid Id { get; set; }
        public string user { get; set; }
        public DateTime Dt { get; set; }
        public float value { get; set; }
        private Random rand = new Random();
        public void Print()
        {
            Console.WriteLine("Guid: {0}\nUser: {1}\nDateTime: {2}\nValue: {3}\n", Id, user, Dt, value);
        }
    }
}
