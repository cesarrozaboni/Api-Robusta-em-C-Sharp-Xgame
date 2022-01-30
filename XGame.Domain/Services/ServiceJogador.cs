using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Enum;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
           
            Jogador jogador = new Jogador(nome, email, request.Senha);

            AddNotifications(nome, email, jogador);

            if (_repositoryJogador.Existe(x => x.Email.Endereco.Equals(request.Email)))
            {
                AddNotification("e-mail", ResourceMessage.Ja_Existe_Um_X0_Chamado_X1.ToFormat("e-mail", request.Email));
            }

            if(this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.Adicionar(jogador);
            return (AdicionarJogadorResponse) jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", ResourceMessage.X0_E_Obrigatorio.ToFormat("AutenticarAlterarJogadorRequestdorRequest"));
            }
            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);
            //Jogador jogador = _repositoryJogador.ObeterJogadorPorId(request.Id);

            if(jogador == null)
            {
                AddNotification("ID", ResourceMessage.Dados_Nao_Encontrados);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador);

            //se possuir notifications é invalido
            if (IsInvalid())
            {
                return null;
            }

            //persiste no banco de dados
            _repositoryJogador.Editar(jogador);
            //_repositoryJogador.AlterarJogador(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", ResourceMessage.X0_E_Obrigatorio.ToFormat("AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, "123456");

            AddNotifications(jogador, email);

            //se possuir notifications é invalido
            if (jogador.IsInvalid())
            {
                
                return null;
            }

            //persiste no banco de dados
            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco && x.Senha == jogador.Senha);
            //jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorReponse> ListarJogador()
        {

            return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorReponse)jogador).ToList();
         
            //return _repositoryJogador.ListarJogador().ToList().Select(jogador => (JogadorReponse)jogador).ToList();
        }

        public ResponseBase ExcluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);    

            if(jogador == null)
            {
                AddNotification("Id", ResourceMessage.Dados_Nao_Encontrados);
                return null;
            }

            _repositoryJogador.remover(jogador);
            return new ResponseBase(); 
        }

    }
}
