using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagement.Models
{
    public class AuditClientPortfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuditId { get; set; }
        [Required(ErrorMessage = "AuditorID Must be provided")]
        public int AuditorId { get; set; }
        
        [Required(ErrorMessage = "PortfolioName Must be provided")]
        [StringLength(50, MinimumLength = 2)]
        public string PortfolioName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int AuditorFK { get; set; }
    }
}
