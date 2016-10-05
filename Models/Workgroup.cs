using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;

namespace FleetEntityFramework.Models
{
    public class Workgroup
    {
        [Key]
        public int WorkgroupId { get; set; }

        [Required]
        public DateTime Started { get; set; }
        [Required]
        public DateTime Expires { get; set; }

        public int CommisionedById { get; set; }
        public User CommisionedBy { get; set; }

        // The optinal room that the workgroup was configured for
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<WorkgroupWorkstation> Workstations { get; set; }
        public virtual ICollection<Application> AllowedApplications { get; set; }

        public static Expression<Func<Workgroup, bool>> IsInWorkgroup(Workstation workstation)
        {
            return workgroup => workgroup.Started < DateTime.Now && workgroup.Expires > DateTime.Now
                                && workgroup.Workstations
                                    .Where(w => !w.TimeRemoved.HasValue)
                                    .Select(w => w.Id)
                                    .Contains(workstation.WorkstationId);
        }

        public static Expression<Func<Workgroup, bool>> InProgress()
        {
            var now = DateTime.Now;
            return workgroup => workgroup.Started < now && workgroup.Started > now;
        }
        
        public static Expression<Func<WorkgroupWorkstation, bool>> IsInProgress()
        {
            var now = DateTime.Now;
            return ww => ww.Workgroup.Started < now && ww.Workgroup.Expires > now;
        }  
    }
}
