using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class License
  {
    public License()
    {
      this.JoinEngineerLicense = new HashSet<EngineerLicense>();
    }

    public int LicenseId { get; set; }
    public string Type { get; set; }
    public virtual ICollection<EngineerLicense> JoinEngineerLicense { get; set; }
  }
}