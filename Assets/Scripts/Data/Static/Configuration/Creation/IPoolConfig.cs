namespace ToonShooterPrototype.Data.Static.Configuration.Creation
{
    public interface IPoolConfig
    {
        int StartCount { get; }
        int StartCapacity { get; }
        int MaxSize { get; }
        bool ThrowErrorIfItemAlreadyInPoolWhenRelease { get; }
    }
}