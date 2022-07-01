using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Room
    {
        public long RoomNo {  get; set; } 
        public string RoomActivity { get; set; }
        public string RoomStatus { get; set; }
    }
}