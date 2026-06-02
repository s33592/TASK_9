namespace TASK_9.DTOs
{
    public class AppUserDto
    {
        public string Email { get; set; } = string.Empty;
        public int NoteCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
