using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoXamarin.DataBase;
using ToDoXamarin.Models;
using ToDoXamarin.Services;
using Xamarin.Forms;

namespace ToDoXamarin.Componentes
{
     /// <summary>
     /// Extende de Frame já se parece mais com um card
     /// </summary>
    public class CardTarefa : Frame
    {

        #region[SERVICES]
        TarefaService tarefaService = new TarefaService();
        #endregion

        public CheckBox chk { get; set; } = new CheckBox() { VerticalOptions = LayoutOptions.End };
        public Label lbl { get; set; } = new Label() { VerticalOptions = LayoutOptions.StartAndExpand };
        public TarefaModel Model { get; set; } = new TarefaModel();
        
        public Grid grid { get; set; } = new Grid()
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(){Width = new GridLength(90,GridUnitType.Star)},
                new ColumnDefinition(){Width = new GridLength(10,GridUnitType.Star)}
            }
        };    

        public CardTarefa(TarefaModel pModel, bool pPermiteEditar = false)
        {
            this.Model = pModel;

            DefineComponentes();            
            
        }

        private void DefineComponentes()
        {

            this.Padding = new Thickness(10,10);
            this.Margin = 5;
            this.BorderColor = Color.White;
            this.BackgroundColor = Color.Transparent;

            lbl.Text = this.Model.Descricao;            
            chk.IsChecked = this.Model.Concluida;
            chk.CheckedChanged += Marcado;
            grid.Children.Add(lbl,0,0);
            grid.Children.Add(chk,1,0);

            this.Content = grid;
        }
       
        /// <summary>
        /// vai setar a tarefa como pendente = false e tirar ela da pagina principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Marcado(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                var dbContext = new MyDBContext();
                this.Model.Concluida = !this.Model.Concluida;
                dbContext.Update(this.Model);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
  
        }
    }
}
