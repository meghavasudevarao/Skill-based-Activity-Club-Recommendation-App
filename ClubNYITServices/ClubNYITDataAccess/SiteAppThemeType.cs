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
    
    public partial class SiteAppThemeType
    {
        public string CompanyID { get; set; }
        public int SiteID { get; set; }
        public int AppID { get; set; }
        public bool hasDefaultTheme { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
    
        public virtual Application Application { get; set; }
    }
}
