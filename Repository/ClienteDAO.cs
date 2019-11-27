﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository {
    public class ClienteDAO {

        private readonly Context _context;
        public ClienteDAO(Context context) {
            _context = context;
        }
        public Cliente BuscarPorId(int id) {
            return _context.Clientes.Find(id);
        }
        public List<Cliente> ListarTodos() {
            return _context.Clientes.ToList();
        }
        public bool Cadastrar(Cliente cliente) {
            if (BuscarPorCpf(cliente) == null) {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Cliente BuscarPorCpf(Cliente cliente) {
            return _context.Clientes.FirstOrDefault
                (x => x.Cpf.Equals(cliente.Cpf));
        }

    }
}
