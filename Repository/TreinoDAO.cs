﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class TreinoDAO {

        private readonly Context _context;
        public TreinoDAO(Context context) {
            _context = context;
        }
        public Treino BuscarPorId(int id) {
            return _context.Treinos.Find(id);
        }
        public List<Treino> ListarTodos() {
            return _context.Treinos.Include(x=>x.NomeExercicio).ToList();
        }
        public bool Cadastrar(Treino treino) {
            
                _context.Treinos.Add(treino);
                _context.SaveChanges();
                return true;
            
        }

        
    }
}
