using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistense
{
    public class XGameContext : DbContext
    {
        public XGameContext() : base("XGameConnectionString")//string de conexao c/ banco aula 13
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }
                
        //mapeamento de tabelas do entity
        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        public IDbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //seta o schema default
            //modelBuilder.HasDefaultSchema("Apoio");

            //remove a pluralização dos nomes da tabela
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //remove exclusão em cascate
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //setar para usar varchar ao inves de nvarchar

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //caso esqueça de colocar o tamanho do campo ira usar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            #region Adiciona entidades mapeadas - automaticamente via assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            #region Adiciona entidades mapeadas - automaticamente via namespace

            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace == "AlertaBrasil.Domain.Entities.DomainViagem")
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Ativator.CreateInstance(type);
            //        modelBuilder.Configurations.Add(instance);
            //    });
            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
