using System.ComponentModel.DataAnnotations;
namespace SlavesMPEI.Domain.Entities
{
    public enum ProgLang
    {
        [Display(Name = "C++")]
        CPlusPlus,

        [Display(Name = "C#")]
        CSharp,

        [Display(Name = "ASM")]
        Assembler
    }
}