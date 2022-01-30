﻿using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo()
        {

        }

        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request)
        {
            if(request == null)
            {
                AddNotification("Adicionar", ResourceMessage.X0_E_Obrigatorio.ToFormat("AdicionarJogoRequest"));
                return null;
            }

            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            
            if (this.IsInvalid())
            {
                return null;
            }

            jogo = _repositoryJogo.Adicionar(jogo);
            
            return (AdicionarJogoResponse)jogo;
        }

        public ResponseBase AlterarJogo(AlterarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Alterar", Resources.ResourceMessage.X0_E_Obrigatorio.ToFormat("AlterarJogoRequest"));
                return null;
            }

            var jogo = _repositoryJogo.ObterPorId(request.Id);

            if(jogo == null)
            {
                AddNotification("Id", ResourceMessage.Dados_Nao_Encontrados);
                return null;
            }

            jogo.Alterar(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogo.Editar(jogo);

            return (ResponseBase)jogo;
        }

        public ResponseBase ExcluirJogo(Guid id)
        {
            if(id == null)
            {
                AddNotification("Id", ResourceMessage.Dados_Nao_Encontrados);
                return null;
            }

            var jogo = _repositoryJogo.ObterPorId(id);

            if (jogo == null)
            {
                AddNotification("Id", ResourceMessage.Dados_Nao_Encontrados);
                return null;
            }

            _repositoryJogo.remover(jogo);

            return new ResponseBase()
            {
                Message = ResourceMessage.Operacao_Realizada_Com_Sucesso
            };
        }

        public IEnumerable<JogoResponse> ListarJogo()
        {
            return _repositoryJogo.Listar().ToList().Select(jogo => (JogoResponse)jogo).ToList();
        }
    }
}
