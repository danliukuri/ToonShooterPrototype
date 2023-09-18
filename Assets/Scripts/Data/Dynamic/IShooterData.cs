namespace ToonShooterPrototype.Data.Dynamic
{
    public interface IShooterData
    {
        float ShotAccuracy { get; }
        float ShootRange { get; }
        float ShootDelay { get; }
        float ShootHeight { get; }
    }
}