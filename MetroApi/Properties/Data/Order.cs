//using system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace METROAPI;
  [Table("order", Schema = "public")]
public class Order
{
    [Key]
    public int OrderID { get; set; }
    
    public string FromLocation { get; set; }
    
    public string ToLocation { get; set; }
    public int TicketPrice { get; set; }
    
      public DateTime Date { get; set; }
      
}
