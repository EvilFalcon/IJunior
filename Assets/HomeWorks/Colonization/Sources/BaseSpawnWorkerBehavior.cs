public class BaseSpawnWorkerBehavior : IBaseBehavior
{
    private int _copperForSpawnWorker = 3;
    private Base _base;

    public BaseSpawnWorkerBehavior(Base currentbase)
    {
        _base = currentbase;
    }

    public void Enter() { }

    public void Run()
    {
        if (_base.TryPayCopper(_copperForSpawnWorker))
        {
            _base.SpawnWorker();
        }
    }
}
