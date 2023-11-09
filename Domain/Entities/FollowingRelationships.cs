using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FollowingRelationships
    {
        public int FollowingRelationshipId { get; set; }
        public int UserId { get; set; }
        public int FollowingId {  get; set; }
        public DateTime DateFollowed { get; set; }
    }
}
