using System.ComponentModel.DataAnnotations;

namespace TASK_9.ViewModels
{
    public class AddNoteViewModel
    {
        [Required(ErrorMessage = "A title is always required for your note")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Note content can't be left empty")]
        public string Content { get; set; } = string.Empty;
    }
}
