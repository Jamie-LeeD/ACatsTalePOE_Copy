using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACatsTalePOE
{
    [Serializable]
    public class GameSaveData
    {
        public int noOfLevel;
        public int currentLevel;
        public Level level;

        public GameSaveData(int noLvl, int cLvl, Level lvl)
        {
            noOfLevel = noLvl;
            currentLevel = cLvl;
            level = lvl;
        }
    }
}
