using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KUDOS.Controllers.InsertRequest
{
    public class EmailInsertRequest
    {
        [Required]
        public string from { get; set; }

        [Required]
        public string subject  { get; set; }

        [Required]
        public string content { get; set; }

    }
}