using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public partial class Question
    {
        public string Traloi { get; set; }
        public bool IsCorrect
        {
            get
            {
                if (this.Traloi == null) return false;
                else return this.Traloi.Equals(this.Answer);
            }
        }
    }
}
