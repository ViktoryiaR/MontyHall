using System;

namespace MontyHall.Services
{
    public class SimulationService : ISimulationService
    {
        public float Simulate(int numberOfGames, bool isChangeStrategy)
        {
            var random = new Random();
            var numberOfWins = 0;

            var i = 0;

            while (i++ < numberOfGames)
            {
                var carDoorNumber = random.Next(3);
                var guessNumber = random.Next(3);

                if (isChangeStrategy ^ carDoorNumber == guessNumber)
                {
                    numberOfWins++;
                }
            }

            return (float)numberOfWins / numberOfGames;
        }
    }
}
