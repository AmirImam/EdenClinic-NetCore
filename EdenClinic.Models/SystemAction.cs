namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(SystemAction))]
    public partial class SystemAction
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ActionID { get; set; }

        public Guid? PersonID { get; set; }
        public Person Person { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        public DateTime ActionDate { get; set; }
        public string ActionJson { get; set; }
    }
}
