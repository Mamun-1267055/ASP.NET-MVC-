using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Work1.Models.viewmodel
{
    public class EmpVM
    {

        public int EmpId { get; set; }
        [Required, StringLength(50), Display(Name = "Name")]
        public string EmpName { get; set; }
        [Required]
        public int Phone { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        public HttpPostedFileBase image { get; set; }
     

    }
   

}