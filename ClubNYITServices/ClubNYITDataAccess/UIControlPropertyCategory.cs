//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubNYITDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class UIControlPropertyCategory
    {
        public long UIControlPropertyID { get; set; }
        public int UIControlID { get; set; }
        public int UIPropertyCategoryID { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
    
        public virtual UIPropertyCategory UIPropertyCategory { get; set; }
    }
}
