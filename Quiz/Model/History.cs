//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quiz.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public Nullable<int> UserId { get; set; }
        public string SubId { get; set; }
        public Nullable<int> NumberQuest { get; set; }
        public Nullable<int> NumberAns { get; set; }
        public Nullable<int> NumberCorrect { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual User User { get; set; }
    }
}
