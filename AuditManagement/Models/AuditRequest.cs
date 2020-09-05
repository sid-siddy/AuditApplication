using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagement.Models
{
    public class AuditRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        //[ForeignKey("AuditorFK")]
        public int AuditorId { get; set; }
        public int ClientId { get; set; }
        public string AuditorComments { get; set; }
        public string ClientResponse { get; set; }
    }
}
