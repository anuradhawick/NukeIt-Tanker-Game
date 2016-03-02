using NukeIt_Tanker.GameEntity;
using System.Timers;
namespace Tanker.GameEntity
{
    class TimeKeeper
    {
        private MainGrid mg;
        private Timer timer;
        public TimeKeeper(MainGrid mg)
        {
            this.mg = mg;
            this.timer = new Timer();
        }
    }
}
