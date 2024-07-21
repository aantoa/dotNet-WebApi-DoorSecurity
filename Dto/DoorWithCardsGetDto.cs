namespace DoorsSecurity.Dto
{
    public class DoorWithCardsGetDto : DoorGetDto
    {
        public ICollection<CardGetDto>? Cards { get; set; }
    }
}