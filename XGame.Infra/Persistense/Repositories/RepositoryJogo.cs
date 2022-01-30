using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using System.Data.Entity;
using XGame.Infra.Persistense.Repositories.Base;

namespace XGame.Infra.Persistense.Repositories
{
    public class RepositoryJogo : RepositoryBase<Jogo, Guid>, IRepositoryJogo
    {
        protected readonly XGameContext _xGameContext;

        public RepositoryJogo(XGameContext xGameContext) : base(xGameContext)
        {
            this._xGameContext = xGameContext;
        }

        //public Jogador AdicionarJogador(Jogador jogador)
        //{
        //    _xGameContext.Jogadores.Add(jogador);
        //    _xGameContext.SaveChanges();

        //    return jogador;
        //}
        
        
        //public void AlterarJogador(Jogador jogador)
        //{
        //    throw new NotImplementedException();
        //}

        //public Jogador AutenticarJogador(string email, string senha)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Jogador> ListarJogador()
        //{
        //    return _xGameContext.Jogadores.ToList();
        //}

        //public Jogador ObeterJogadorPorId(Guid id)
        //{
        //    throw new NotImplementedException();
        //}




        //exemplo de codigo, não estou usando no projeto
        public List<Jogador> montaQuery()
        {
            string nome = "cesar";
            string ultimoNome = "Rozaboni";
            string sexo = string.Empty;

            //monta uma query em tempo de execução - não utilizando dados em memoria
            //asnotracking remove o mapemanto do objeto
            IQueryable<Jogador> jogadores = _xGameContext.Jogadores.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(nome));
            }

            if (!string.IsNullOrEmpty(ultimoNome))
            {
                jogadores = jogadores.Where(x => x.Nome.UltimoNome.StartsWith(ultimoNome));
            }

            if (!string.IsNullOrEmpty(sexo))
            {
                jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(ultimoNome));
            }

            //dando um ToList vai até o banco buscar os dados
            return jogadores.ToList();
        }
    }
}
