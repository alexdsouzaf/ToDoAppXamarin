using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoXamarin.Models
{
    public class TarefaModel
    {

        public string Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; } = false;
    }
}