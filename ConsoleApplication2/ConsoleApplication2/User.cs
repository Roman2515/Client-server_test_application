using System;

namespace SocketClient
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            Dt = DateTime.Now;
            value = rand.Next(-100, 101) / 10f;
        }
        public Guid Id;
        public string user;
        public DateTime Dt;
        public float value;
        static private Random rand = new Random();
        public void Print()
        {
            Console.WriteLine("Guid: {0}\nUser: {1}\nDateTime: {2}\nValue: {3}\n", Id, user, Dt, value);
        }
    }
}
