//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public long id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string video_link { get; set; }
        public string img_link { get; set; }
        public string text { get; set; }
        public System.DateTime date { get; set; }
        public long view_count { get; set; }
    
        public virtual NewsType NewsType { get; set; }
    }
}