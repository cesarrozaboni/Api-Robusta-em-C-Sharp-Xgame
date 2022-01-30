using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogo : IRepositoryBase<Jogo, Guid>
    {
        //Jogador AutenticarJogador(string email, string senha);

        //Jogador AdicionarJogador(Jogador jogador);

        //IEnumerable<Jogador> ListarJogador();

        //Jogador ObeterJogadorPorId(Guid id);

        //void AlterarJogador(Jogador jogador);
    }
}
