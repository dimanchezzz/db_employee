namespace Course_kepeer_1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_info()
        {
            Resource_info = new HashSet<Resource_info>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Answer { get; set; }

        [Required]
        [StringLength(100)]
        public string Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resource_info> Resource_info { get; set; }
    }
}
