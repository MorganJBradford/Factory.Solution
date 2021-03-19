using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      JoinEntities = new HashSet<Repair>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public DateTime InstallationDate { get; set; }
    public virtual ICollection<Repair> JoinEntities { get; }
  }
}