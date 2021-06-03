using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserEntity> Users { get; set; }
    }
}
