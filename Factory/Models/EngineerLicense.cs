namespace Factory.Models
{
  public class EngineerLicense
  {
    public int EngineerLicenseId { get; set; }
    public int EngineerId { get; set; }
    public int LicenseId { get; set; }
    public virtual Engineer Engineer { get; set; }
    public virtual License License { get; set; }
  }
}
