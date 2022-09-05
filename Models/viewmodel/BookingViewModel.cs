using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Work1.Models.viewmodel
{
    public class BookingVM
    {
        public int bookid { get; set; }
        [Required, Display(Name = "Cheak Date"), Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime checkingdate { get; set; }
        [Required, Display(Name = "Cheak Out Date"), Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime checkingOut { get; set; }
        [Required, Display(Name = "Duration")]
        public string duration { get; set; }
        //public int duration { get
        //    {

        //        return checkingOut.HasValue ? (checkingOut.Value - checkingdate).Days + 1 : 0;
        //    } }
        [Display(Name = "Cost")]
        [Required, Column(TypeName = "money"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal cost { get; set; }
        [Required, StringLength(50), Display(Name = "Name")]
        public string custname { get; set; }
      [Required]
        public string phone { get; set; }
      
        public bool roomStatus { get; set; }
      
        public string roomType1 { get; set; }
        public int RoomCost { get; set; }
        //public decimal RoomCost
        //{
        //    get
        //    {
        //        return cost * duration;




        //    }
        //}
        public HttpPostedFileBase Image { get; set; }

    }
}