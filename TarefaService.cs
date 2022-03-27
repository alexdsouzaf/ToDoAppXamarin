using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoXamarin.DataBase;
using ToDoXamarin.Models;

namespace ToDoXamarin.Services
{
    public class TarefaService
    {
        /// <summary>
        /// foi criado mas talvez nem precisa
        /// </summary>
        public TarefaService() { }

        public async Task<List<TarefaModel>> BuscarTarefas(bool pTodas)
        {
            using (var contexto = new MyDBContext())
            {
                if (pTodas)
                    return contexto.Tarefas.ToList();
                else
                    return contexto.Tarefas.Where(p => !p.Concluida).OrderBy(o => o.Id).ToList();
            }
            
        }
    }
}
