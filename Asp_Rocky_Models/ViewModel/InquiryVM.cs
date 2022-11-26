using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp_Rocky_Models.ViewModel
{
    public class InquiryVM
    {
        public InquiryHeader InquiryHeader { get; set; }
        public IEnumerable<InquiryDetail> InquiryDetail { get; set; }
    }
}
