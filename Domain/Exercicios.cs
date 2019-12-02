using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Exercicios")]
    public class Exercicios
    {
        [Key]
        
        public int ExercicioId { get; set; }
        public string NomeExercicio { get; set; }
        public string Categoria { get; set; }


    }
}
