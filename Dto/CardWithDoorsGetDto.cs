namespace DoorsSecurity.Dto
{
    public class CardWithDoorsGetDto : CardGetDto
    {
        public ICollection<DoorGetDto>? Doors { get; set; }
    }
}