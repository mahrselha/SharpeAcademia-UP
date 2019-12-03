using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain{
    [Table("Treino")]
    public class Treino {
        [Key]
        public int TreinoId { get; set; }
        public List<Exercicios> NomeExercicio { get; set; } 
        public Cliente Cliente { get; set; }
        public Professor Professor { get; set; }
       
    } 
}
