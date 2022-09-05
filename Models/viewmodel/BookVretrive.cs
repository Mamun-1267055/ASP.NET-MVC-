using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work1.Models.viewmodel
{
    public class BookVretrive
    {
        public int bookid { get; set; }
        [Required]
        public DateTime checkingdate { get; set; }
        [Required]
        public DateTime? checkingOut { get; set; }
        [Required]
        public string duration { get; set; }


        ////get 
        ////{
        ////    return checkingOut.HasValue ? (checkingOut.Value - checkingdate).Days + 1: 0;
        ////}}
        public decimal cost { get; set; }
        public bool roomStatus { get; set; }
        
        public string picturePath { get; set; }
   
        public string roomType1 { get; set; }
        [Required]
        public string custname { get; set; }
        public string phone { get; set; }
        //public int RoomCost { get; set; }

        public decimal RoomCost2
        {
            get
            {
                return  int.Parse(duration)*cost;




            }
        }

    }
}