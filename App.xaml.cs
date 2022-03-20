using System;
using ToDoXamarin.DataBase;
using ToDoXamarin.Models;
using ToDoXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new Principal();
        }

        protected override void OnStart()
        {
            //isso aqui é só um teste pra ter algum registro logo ao iniciar, esse codigo será removido
            try
            {
                //var contexto = new MyDBContext();                
                //TarefaModel teste = new TarefaModel { Id = "1", Descricao = "teste", Pendente = true };
                //contexto.Add(teste);
                //contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                var v = ex.Message;
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
