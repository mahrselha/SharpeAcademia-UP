using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain {
    [Table("Clientes")]
    public class Cliente {

        [Key]
        public int ClienteId { get; set; }
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Endereco { get; set; }
        [Display(Name = "CPF:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

    }
}
