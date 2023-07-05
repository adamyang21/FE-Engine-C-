using System;
using FEEngine.Engine;
using FEEngine.Enums;

namespace FEEngine.Actors {
    public class AllyUnit : Actor {
        //METHODS
        public AllyUnit(string name, char displayCharacter, Dictionary<BaseStat, int> statMap) : base(name, displayCharacter, statMap, Team.ALLY) {}
    }
}