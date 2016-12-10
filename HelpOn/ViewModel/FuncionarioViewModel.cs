using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelpOn.Web.ViewModel
{
    public class FuncionarioViewModel
    {
        public SelectList ListaNivel { get; set; }

        public string Mensagem { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

        public int IDFuncionario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
    
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Senha deve conter entre 6 e 10 caracteres.")]
        public string Senha { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        [Required]
        [Display(Name = "Nível")]
        public int IDNivel { get; set; }

        public virtual Nivel Nivel { get; set; }
    }
}