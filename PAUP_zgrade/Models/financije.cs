﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAUP_zgrade.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; 
 

    [Table("financije")]

    public partial class financije
    {
        [Display(Name = "ID financije")]
        [Key]
        public int idfinancije { get; set; }

        [Required(ErrorMessage = "Datum je obavezan podatak")]
        [DataType(DataType.Date)]
        // ako ne napisemo fiksno ovaj format Google Chrome nece dobro prikazati datumsko po
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public System.DateTime datumFinancije { get; set; }

        [Display(Name = "Vrijednost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public decimal vrijednostFinancije { get; set; }

        [Display(Name = "Zgrada financijske transakcije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public int zgradaFinancija { get; set; }

        [Display(Name = "Opis financijske transakcije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string opisFinancije { get; set; }

        [Display(Name = "Obavljena trasakcija?")]
        [Required]
        public sbyte obavljenPosao { get; set; }
    }
}
