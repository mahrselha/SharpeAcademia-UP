using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProfessorDAO {

        private readonly Context _context;
        public ProfessorDAO(Context context) {
            _context = context;
        }
        public Professor BuscarPorId(int id) {
            return _context.Professores.Find(id);
        }
        public List<Professor> ListarTodos() {
            return _context.Professores.ToList();
        }
        public bool Cadastrar(Professor Professor) {
            if (BuscarPorCpf(Professor) == null) {
                _context.Professores.Add(Professor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Professor BuscarPorCpf(Professor Professor) {
            return _context.Professores.FirstOrDefault
                (x => x.Cpf.Equals(Professor.Cpf));
        }
        public void Remover(int id) {
            _context.Professores.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Professor p) {
            _context.Professores.Update(p);
            _context.SaveChanges();
        }

    }
}
