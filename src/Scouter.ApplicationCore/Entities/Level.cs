using Scouter.ApplicationCore.Entities.Bases;
using System;

namespace Scouter.ApplicationCore.Entities
{
    public class Level : BaseEntity<Level>
    {
        public Level()
        {

        }
        public int Id { get; protected set; }
        public string LevelName { get; protected set; }
        public string LevelNameNote { get; protected set; }
       
    }
}