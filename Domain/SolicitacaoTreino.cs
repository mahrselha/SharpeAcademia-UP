using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class SolicitacaoTreino
    {
        [Key]
        public int SolicitacaoID { get; set; }
        public Cliente ClienteId { get; set; }
        public string Objetivo { get; set; }

    }
}
