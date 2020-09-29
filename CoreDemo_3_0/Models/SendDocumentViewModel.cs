using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Models
{
    public class SendDocumentViewModel
    {
        public SendDocumentFormModel Form { get; set; }
    }
    public class SendDocumentFormModel
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [DisplayName("Signer Email")]
        public string SignerEmail { get; set; }

        [Required]
        [DisplayName("Signer Name")]
        public string SignerName { get; set; }

        [Required]
        public string File { get; set; }
        //[Required]
        //public HttpPostedFileBase File { get; set; }
    }
}
