//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealerManagement.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string License_Plate { get; set; }
        public string ChassisNo { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}