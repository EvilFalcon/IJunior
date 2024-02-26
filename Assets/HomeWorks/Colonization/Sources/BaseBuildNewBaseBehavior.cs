public class BaseBuildNewBaseBehavior : IBaseBehavior
{
    private int _copperCountForNewBase = 5;
    private Base _base;
    private bool _isSent;

    public BaseBuildNewBaseBehavior(Base currentBase)
    {
        _base = currentBase;
    }

    public void Enter()
    {
        _isSent = false;
    }

    public void Run()
    {
        if (_isSent == false && _base.TryBuildNewBase(_copperCountForNewBase))
        {
            _isSent = true;
        }
        else if (_isSent == false && _base.TryBuildNewBase(_copperCountForNewBase) == false)
        {
            _base.ReserveWorkerForBuldingNewBase(_copperCountForNewBase);
        }
    }
}
