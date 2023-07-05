using System;
using FEEngine.Actors;
using FEEngine.Enums;

namespace FEEngine.Engine {
    public class Display {
        //ATTRIBUTES
        private GameMap gameMap;



        //METHODS
        public Display() {
            this.gameMap = new GameMap(5, 3, '.');

            Dictionary<BaseStat, int> statMap = new Dictionary<BaseStat, int>();
            statMap[BaseStat.LEVEL] = 1;
            statMap[BaseStat.MAXHP] = 18;
            statMap[BaseStat.STRENGTH] = 4;
            statMap[BaseStat.MAGIC] = 0;
            statMap[BaseStat.SKILL] = 6;
            statMap[BaseStat.SPEED] = 8;
            statMap[BaseStat.LUCK] = 3;
            statMap[BaseStat.DEFENCE] = 2;
            statMap[BaseStat.RESISTANCE] = 0;
            statMap[BaseStat.CONSTITUTION] = 4;
            statMap[BaseStat.WEIGHT] = 3;
            statMap[BaseStat.MOVEMENT] = 6;
            AllyUnit testUnit = new AllyUnit("Adam", 'A', statMap);
            Position position = this.gameMap.getPositionAt(1, 1);
            this.gameMap.addPlayerUnit(testUnit, position);
        }

        public string toString() {
            return this.gameMap.toString();
        }

        public void movementTest(int x, int y) {
            this.gameMap.movePlayerUnit("Adam", this.gameMap.getPositionAt(x, y));
        }

        // public string[] displayOptions() {
        //     string[] options = {"Move"};
        // }
    }
}