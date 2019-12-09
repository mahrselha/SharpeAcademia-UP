using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain{
    [Table("Treino")]
    public class Treino {
        public Treino() {
            Exercicio = new Exercicios();
            Cliente = new Cliente();
            Professor = new Professor();
            }
        [Key]
        public int TreinoId { get; set; }
        public Exercicios Exercicio { get; set; } 
        public Cliente Cliente { get; set; }
        public Professor Professor { get; set; }
        

    } 
}
