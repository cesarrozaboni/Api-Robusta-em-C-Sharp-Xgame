using XGame.Infra.Persistense;

namespace XGame.Infra.Transactions
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly XGameContext _context;

        public UnityOfWork(XGameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
