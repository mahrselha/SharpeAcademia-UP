using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Repository
{
    public class ExercicioDAO
    {
        private readonly Context _context;
        public ExercicioDAO(Context context)
        {
            _context = context;
        }
        public Exercicios BuscarPorId(int id)
        {
            return _context.Exercicios.Find(id);
        }

        public List<Exercicios> ListarTodos()
        {
            return _context.Exercicios.ToList();
        }

        public bool Cadastrar(Exercicios exercicios)
        {

            _context.Exercicios.Add(exercicios);
            _context.SaveChanges();
            return true;

        }




    }
}
