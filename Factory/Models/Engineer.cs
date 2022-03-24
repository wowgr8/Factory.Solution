using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEngineerMachine = new HashSet<EngineerMachine>();
      this.JoinEngineerLicense = new HashSet<EngineerLicense>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<EngineerMachine> JoinEngineerMachine { get; set; }
    public virtual ICollection<EngineerLicense> JoinEngineerLicense { get; set; }
  }
}