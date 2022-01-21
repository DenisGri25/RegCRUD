using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace RegCRUD.Models
{
    public enum PositionName{
    [Display(Name ="Разработчик")]
    Dev,
    [Display(Name = "Тестировщик")]
    Qa,
    [Display(Name = "Бизнес-аналитик")]
    Ba,
    [Display(Name = "Менеджер")]
    Manager
    }

}