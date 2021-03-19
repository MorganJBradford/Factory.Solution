using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      JoinEntities = new HashSet<Repair>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
    public virtual ICollection<Repair> JoinEntities { get; }
  }
}