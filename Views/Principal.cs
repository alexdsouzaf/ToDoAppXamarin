using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoXamarin.Componentes;
using ToDoXamarin.DataBase;
using ToDoXamarin.Models;
using ToDoXamarin.Services;
using Xamarin.Forms;

namespace ToDoXamarin.Views
{
    public partial class Principal
    {
        #region[SERVICES]
        TarefaService tarefaService = new TarefaService();
        #endregion
        
        #region[COMPONENTES]
        Button btnConsultarEmAberto = new Button() { CornerRadius = 50 };
        Button btnConsultarTodas = new Button() { CornerRadius = 50 };
        Button btnAdicionar = new Button() { CornerRadius = 50 };
        StackLayout stackLayoutConsulta = new StackLayout();
        #endregion

        #region[EVENTOS]
        /// <summary>
        /// Busca apenas as tarefas pendentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                 var todasAsTarefas = await this.tarefaService.BuscarTarefas(false);
                stackLayoutConsulta.Children.Clear();
                foreach (var item in todasAsTarefas)
                {
                    stackLayoutConsulta.Children.Add(new CardTarefa(item));
                }
                
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }

        /// <summary>
        /// busca todas as tarefas sem filtrar por pendencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnConsultarTodas_Clicked(object sender, EventArgs e)
        {
            var todasAsTarefas = await this.tarefaService.BuscarTarefas(true);
            stackLayoutConsulta.Children.Clear();
            foreach (var item in todasAsTarefas)
            {
                stackLayoutConsulta.Children.Add(new CardTarefa(item));
            }
        }

        private async void AdicionarNovaTarefa(object sender, EventArgs e)
        {
            ChamarADD();
        }
        #endregion

        #region[METODOS]
        /// <summary>
        /// atribui as propriedades e eventos do componentes instaciados para a tela
        /// </summary>
        private void DefinindoComponentes()
        {
            //consultar tarefa apenas pendentes
            btnConsultarEmAberto.Clicked += Btn_Clicked;
            btnConsultarEmAberto.Text = "Consultar tarefas pendentes";

            //adicionar uma nova tarefa
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Clicked += AdicionarNovaTarefa;

            //consutlar todas as tarefas
            btnConsultarTodas.Clicked += BtnConsultarTodas_Clicked;
            btnConsultarTodas.Text = "Consultar todas as tarefas";
        }

        /// <summary>
        /// Abre um popup para preencher uma nova tarefa
        /// </summary>
        private async void ChamarADD()
        {
            var userInput = await DisplayPromptAsync("ATENÇÃO", "Descreva sua tarefa","Salvar","Cancelar","Fazer...");
            if (!string.IsNullOrEmpty( userInput ))
            {
                TarefaModel newTarefa = new TarefaModel();
                newTarefa.Descricao = userInput;
                try
                {
                    var dbContext = new MyDBContext();
                    await dbContext.AddAsync(newTarefa);
                    await dbContext.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    await DisplayAlert("ATENÇÃO", $"Algo deu errado aqui: {ex.Message}", "OK");
                }
            }
        }
        #endregion
    }
}
