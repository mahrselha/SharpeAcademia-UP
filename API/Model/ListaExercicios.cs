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

            exercicios.Nome = "Leg Press 45 graus";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Agachamento Smitch";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Cadeira Extensora";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Abdutor";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Adutor";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Crucifixo";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "CrossOver";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Supino Reto";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Remada";
            exercicios.Categoria = "Costas";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Rosca Direta";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Rosca Invertida";
            exercicios.Categoria = "Braço";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Elevação Pelve";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Puxada Triângulo";
            exercicios.Categoria = "Ombro";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Stiff";
            exercicios.Categoria = "Costa";
            listaexercicios.Add(exercicios);
            exercicios = new Exercicios();
            exercicios.Nome = "Panturrilha";
            exercicios.Categoria = "Perna";
            listaexercicios.Add(exercicios);


            return listaexercicios;
        }
    }
}
