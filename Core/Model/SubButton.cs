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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class SubButton
    {
        public string SubId { get; set; }
        public string ButtonName { get; set; }
        public string Lable1 { get; set; }
        public string Lable2 { get; set; }
        public string ImgUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonIgnore]
        public virtual Subject Subject { get; set; }
    }
}
