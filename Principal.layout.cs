using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoXamarin.DataBase;
using Xamarin.Forms;

namespace ToDoXamarin.Views
{
    public partial class Principal : ContentPage
    {
        
        public Principal()
        {
            this.DefinindoComponentes();


            Content = new StackLayout
            {
                
                Children = {
                    new Label { Text = "Bem-vindo ao meu TO-DO LIST APP com Xamarin!" , HorizontalTextAlignment = TextAlignment.Center, Margin = 10, Padding = 10, FontSize = 17},
                    btnConsultarEmAberto,
                    btnConsultarTodas,
                    btnAdicionar,
                    new Label { Text = "Lista de Tarefas", Padding = 5, Margin = 5, FontSize = 17},
                    new ScrollView {
                        Content = stackLayoutConsulta
                    },
                    
                }
            };
        }


    }
}