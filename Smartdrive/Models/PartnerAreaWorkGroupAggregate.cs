namespace Smartdrive.Models
{
    public class PartnerAreaWorkGroupAggregate
    {
        public int PawoPatrEntityid { get; set; }
        public int PawoUserEntityid { get; set; }
        public string? PawoArwgCode { get; set; }
        public string? CityName { get; set;}
        public string? ProvinceName { get; set;}
        public string? PartnerName { get; set;}
        public string? ZoneName {  get; set;}

        public string? Status { get; set;}
    }
}
