//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    
    public  class MedicineSearch
    {
       
        public int MSID { get; set; }
        public string DeviceId { get; set; }
        public int MedicineID { get; set; }
        public int Count { get; set; }
        public int IsActive { get; set; }
    
        //public  ICollection<Notification> Notifications { get; set; }
       
        //public Pharmacy Pharmacy { get; set; }
    }
}
