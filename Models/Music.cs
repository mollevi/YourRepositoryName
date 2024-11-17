using Microsoft.EntityFrameworkCore;

namespace ZeneApp.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Performer { get; set; }
        public uint YearOfPublishing { get; set; }
        public uint Length { get; set; }
        public uint Priority { get; set; }
    }
}
