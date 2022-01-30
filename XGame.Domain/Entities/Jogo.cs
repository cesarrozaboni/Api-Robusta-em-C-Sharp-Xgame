using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities.Base;
using XGame.Domain.Resources;

namespace XGame.Domain.Entities
{
    public class Jogo : EntityBase
    {
        protected Jogo()
        {

        }

        public Jogo(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;

            new AddNotifications<Jogo>(this)
                .IfNullOrInvalidLength(x => x.Nome, 1, 100, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Nome", "1", "100"))
                .IfNullOrInvalidLength(x => x.Descricao, 1, 255, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Descricao", "1", "255"))
                .IfNullOrInvalidLength(x => x.Genero, 1, 30, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Genero", "1", "30"));
                
        }

        public void Alterar(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;

            new AddNotifications<Jogo>(this)
                .IfNullOrInvalidLength(x => x.Nome, 1, 100, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Nome", "1", "100"))
                .IfNullOrInvalidLength(x => x.Descricao, 1, 255, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Descricao", "1", "255"))
                .IfNullOrInvalidLength(x => x.Genero, 1, 30, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Genero", "1", "30"));

        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Produtora { get; private set; }

        public string Distribuidora { get; private set; }

        public string Genero { get; private set; }

        public string Site { get; private set; }
    }
}   
