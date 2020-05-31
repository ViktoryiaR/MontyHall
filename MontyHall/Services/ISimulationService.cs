namespace MontyHall.Services
{
    public interface ISimulationService
    {
        public float Simulate(int numberOfGames, bool isChangeStrategy);
    }
}