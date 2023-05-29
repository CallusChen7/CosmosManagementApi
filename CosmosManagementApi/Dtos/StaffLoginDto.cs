using CosmosManagementApi.Models;

namespace CosmosManagementApi.Dtos
{
  public class StaffLoginDto
  {
    /// <summary>
    /// Account Name
    /// </summary>
    public string? AccountName { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    public string? Pwd { get; set; }
  }
}
