//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NotifyServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sport
    {
    
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] SportIcon { get; set; }
    
        public virtual ICollection<MedalList> MedalLists { get; set; }
    }
}