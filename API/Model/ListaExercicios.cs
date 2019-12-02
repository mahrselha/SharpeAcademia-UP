using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Threading.Tasks;

namespace API.Model
{
    public class ListaExercicios
    {
        public static List<Exercicios> CarregaLista()
        {
            List<Exercicios> listaexercicios = new List<Exercicios>();


            Exercicios exercicios = new Exercicios();

            exercicios.NomeExercicio = "Leg Press 45 graus";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Agachamento Smitch";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Cadeira Extensora";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Abdutor";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Adutor";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Crucifixo";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "CrossOver";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Supino Reto";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Remada";
            exercicios.Categoria = "Costas";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Rosca Direta";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Rosca Invertida";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Elevação Pelve";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Puxada Triângulo";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Stiff";
            exercicios.Categoria = "Costa";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.NomeExercicio = "Panturrilha";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);


            return listaexercicios;
        }
    }
}
