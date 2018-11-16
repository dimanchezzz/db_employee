namespace Course_kepeer_1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resource_info
    {
        public int Id { get; set; }

        public int? User_id { get; set; }

        public string User { get; set; }

        public string Resource { get; set; }

        public string Login_resource { get; set; }

        public string Password_resource { get; set; }

        public virtual User_info User_info { get; set; }
    }
}
