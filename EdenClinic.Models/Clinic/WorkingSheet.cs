namespace EdenClinic.Models
{
    using EdenClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table(nameof(WorkingSheet))]
    public partial class WorkingSheet
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SheetID { get; set; }

        [StringLength(20)]
        public string SheetDate { get; set; }

        [StringLength(15)]
        public string SheetDay { get; set; }

        public Guid? PersonID { get; set; }
        public Person Person { get; set; }
        
        [StringLength(10)]
        public DateTime StartTime { get; set; }

        [StringLength(10)]
        public DateTime EndTime { get; set; }

        
    }
}
