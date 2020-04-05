using Scouter.ApplicationCore.Entities.Bases;
using System;

namespace Scouter.ApplicationCore.Entities
{

    public class Position : BaseEntity<Position>
    {
        public Position()
        {

        }

        public int Id { get; protected set; }
        public string PositionName { get; protected set; }
        public string PositionNameNote { get; protected set; }
       
    }
}