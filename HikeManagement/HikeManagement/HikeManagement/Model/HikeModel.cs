using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HikeManagement.Model
{
    public class HikeModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Parking { get; set; }
        public string Description { get; set; }
        public string Length {  get; set; }
        public string Level { get; set; }   
        public string Cost { get; set; }
        public string Weather { get; set; }
    }
}
