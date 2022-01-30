namespace XGame.Infra.Transactions
{
    public interface IUnityOfWork
    {
        void Commit();
    }
}
