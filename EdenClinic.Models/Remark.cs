namespace EdenClinic.Models
{
    using EdenClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Remark))]
    public partial class Remark : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RemarkID { get; set; }

        public string RemarkDescription { get; set; }

        public Guid? PersonID { get; set; }

        [ForeignKey("UserID")]
        public Person Person { get; set; }
    }
}
