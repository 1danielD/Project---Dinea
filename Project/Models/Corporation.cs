using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Project.Models
{
    public class Corporation
    {
        public int ID { get; set; }

        [Display(Name = "Location name")]

        public string Location { get; set; }
        public string Department { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Task { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int CorporationID { get; set; }
        public Department GetDepartment { get; set; }
    } //navigation property


}

