using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Work1.Models
{
    public class BookRoom
    {
        [Key]
        [Display(Name = "bookid")]
        public int bookid { get; set; }
        [Required]
        public DateTime checkingdate { get; set; }
        [Required]
        public DateTime checkingOut { get; set; }
        [Required]
        public string duration { get; set; }
        public decimal cost { get; set; }
        //nev
        public virtual  Room Room { get; set; }
        public virtual  Customers Customers { get; set; }


    }
    public partial class Room
    {
        [Key, ForeignKey("BookRoom")]
        [Display(Name = "bookid")]
        public int bookid { get; set; }
        public bool roomStatus { get; set; }
        [Required]
        public string picturePath { get; set; }
        public string roomType1 { get; set; }
        //nev
        public virtual  BookRoom BookRoom { get; set; }
    }
    public partial class Customers
    {
        [Key, ForeignKey("BookRoom")]
        [Display(Name = "bookid")]
        public int bookid { get; set; }
        [Required, StringLength(40), Display(Name = "Customer Name")]
        public string custname { get; set; }
        public string phone { get; set; }
        //nev
        public virtual BookRoom BookRoom { get; set; }
    }
    public class HotelRoomContext : DbContext
    {
        public DbSet<BookRoom> BookRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customers>  Customers { get; set; }
    }

}