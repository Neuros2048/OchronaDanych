﻿using System.ComponentModel.DataAnnotations;
using Bankowosc.Shared.validator;

namespace Bankowosc.Shared.Dto;

public class ChangePasswordDto
{
    [Required]
    [MaxLength(40, ErrorMessage = "Za długa wartość")]
    public string LastPassword { get; set; }
    [Required,PasswordValidator]
    [MaxLength(40, ErrorMessage = "Za długa wartość")]
    public string NewPassword { get; set; }
    [Required]
    [Compare("NewPassword",ErrorMessage = "Hasła nie są takie same")]
    [MaxLength(40, ErrorMessage = "Za długa wartość")]
    public string ConfirmPassword { get; set; }
}