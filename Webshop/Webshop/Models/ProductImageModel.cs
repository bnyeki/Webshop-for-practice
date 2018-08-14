using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class ProductImageModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Termékkép")]
        public HttpPostedFileBase DataInHttpPostedFileBase { get; set; }

        [DisplayName("Termékkép")]
        public string SourceString { get; set; }











    }
}