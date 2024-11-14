using Microsoft.EntityFrameworkCore;

namespace ZeneApp.Models
{
    public class Zene
    {
        public int Id { get; }
        public required string Title { get; set; }
        public required string Performer { get; set; }
        public uint YearOfPublishing { get; set; }
        public uint Length { get; set; }
        public uint Priority { get; set; }
    }
}
