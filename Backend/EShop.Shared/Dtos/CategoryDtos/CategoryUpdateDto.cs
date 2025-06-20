using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.Shared.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage = "Kategori id zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır.")]
        public string? Name { get; set; }

        [StringLength(300, ErrorMessage = "Kategori açıklaması en fazla 300 karakter olmalıdır.")]
        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Menüde yer alacak mı bilgisi zorunludur.")]
        public bool IsMenuItem { get; set; }
    }
}
