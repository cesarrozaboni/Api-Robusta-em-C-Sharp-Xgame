using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enum;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {

        [Obsolete("Only needed for serialization and materialization", true)]
        public Jogador()
        {

        }
        
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6, 6, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Senha", "6", "32"));

            if (IsValid())
            {
                senha = Senha.ConvertToMD5();
            }
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            //Id = new Guid();
            Status = EnumSituacaoJogador.EmAndamento;

            new AddNotifications<Jogador>(this).
                IfNullOrInvalidLength(x => x.Senha, 6, 6, ResourceMessage.X0_E_Obrigatorio_E_Deve_Ter_Entre_X0_e_X1_Caracteres.ToFormat("Senha", "6", "32"));

            if (IsValid())
            {
                senha = Senha.ConvertToMD5();
            }
            
            AddNotifications(Nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this).IfFalse(status == EnumSituacaoJogador.Ativo, "Só é possivel alterar jogador ativo");

            AddNotifications(Nome, email);
        }

        public Guid Id { get; private set; }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

       

    }
}
