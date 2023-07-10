//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exercise_2.DB
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Publisher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publisher()
        {
            this.Comic = new HashSet<Comic>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string WEB_Site_Link { get; set; }
        public string Country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comic> Comic { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"WEB-site: {WEB_Site_Link}");
            sb.AppendLine($"Country: {Country}");

            return sb.ToString();
        }
    }
}
