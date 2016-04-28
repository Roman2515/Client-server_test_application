using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocketServer

{
    class UserContext : DbContext
    {
        public UserContext(string conectionString)
            : base(conectionString)
        { }

        public DbSet<User> Users { get; set; }
    }
}