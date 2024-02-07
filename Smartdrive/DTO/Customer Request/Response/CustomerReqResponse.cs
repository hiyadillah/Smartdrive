using Smartdrive.Models;

namespace Smartdrive.DTO.Customer_Request.Response
{
	public record CustomerReqResponse()
	{
		public int CreqEntityid { get; set; }
		public DateTime? CreqCreateDate { get; set; }
		public string? CreqStatus { get; set; }
		public string? CreqType { get; set; }
		public DateTime? CreqModifiedDate { get; set; }
		public int? CreqCustEntityid { get; set; }
		public int? CreqAgenEntityid { get; set; }
		public virtual EmployeeAreaWorkgroupDto? CreqAgen { get; set; }
		public virtual UserDto? CreqCust { get; set; }
	};

	public record UserDto()
	{
		public int UserEntityid { get; set; }
		public string? UserName { get; set; }
	}

	public record EmployeeAreaWorkgroupDto()
	{
		public int EawgEntityid { get; set; }
		public string? EawgStatus { get; set; }
		public string? EawgArwgCode { get; set; }
	}
}
