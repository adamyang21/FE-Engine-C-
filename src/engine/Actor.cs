using FEEngine.Enums;

namespace FEEngine.Engine {
    public abstract class Actor {
        //ATTRIBUTES
        protected string name;
        protected char displayCharacter;
        protected int level;
        protected int hp;
        protected int maxHp;
        protected int strength;
        protected int magic;
        protected int skill;
        protected int speed;
        protected int luck;
        protected int defence;
        protected int resistance;
        protected int constitution;
        protected int weight;
        protected int movement;
        protected Team team;
        //protected Clas class;
        //protected Item[] inventory;
        protected int equippedItemIndex;
        //ADD SKILL RELATED STUFF LATER



        //METHODS
        public Actor(string name, char displayCharacter, Dictionary<BaseStat, int> statMap, Team team) {
            this.name = name;
            this.displayCharacter = displayCharacter;
            this.level = statMap[BaseStat.LEVEL];
            this.maxHp = statMap[BaseStat.MAXHP];
            this.strength = statMap[BaseStat.STRENGTH];
            this.magic = statMap[BaseStat.MAGIC];
            this.skill = statMap[BaseStat.SKILL];
            this.speed = statMap[BaseStat.SPEED];
            this.luck = statMap[BaseStat.LUCK];
            this.defence = statMap[BaseStat.DEFENCE];
            this.resistance = statMap[BaseStat.RESISTANCE];
            this.constitution = statMap[BaseStat.CONSTITUTION];
            this.weight = statMap[BaseStat.WEIGHT];
            this.movement = statMap[BaseStat.MOVEMENT];
            this.team = team;

            this.hp = this.maxHp;
        }

        //public Actor(string characterFile, char displayCharacter)

        public string toString() {
            return 
                "Name: " + name + "\n" + 
                "Level: " + Convert.ToInt32(this.level) + "\n" + 
                "HP: " + Convert.ToInt32(this.hp) + "\n" + Convert.ToInt32(this.maxHp) + "\n" + 
                "Strength: " + Convert.ToInt32(this.strength) + "\n" + 
                "Magic: " + Convert.ToInt32(this.magic) + "\n" + 
                "Skill: " + Convert.ToInt32(this.skill) + "\n" + 
                "Speed: " + Convert.ToInt32(this.speed) + "\n" + 
                "Luck: " + Convert.ToInt32(this.luck) + "\n" + 
                "Defence: " + Convert.ToInt32(this.defence) + "\n" + 
                "Resistance: " + Convert.ToInt32(this.resistance) + "\n" + 
                "Constitution: " + Convert.ToInt32(this.constitution) + "\n" + 
                "Weight: " + Convert.ToInt32(this.weight) + "\n" + 
                "Movement: " + Convert.ToInt32(this.movement) + "\n"
            ;
        }

        public char getDisplayCharacter() {
            return this.displayCharacter;
        }

        public void setDisplayCharacter(char displayCharacter) {
            this.displayCharacter = displayCharacter;
        }

        public string getName() {
            return this.name;
        }

        public int getHp() {
            return this.hp;
        }

        public int getMaxHp() {
            return this.maxHp;
        }

        public int getStrength() {
            return this.strength;
        }

        public int getMagic() {
            return this.magic;
        }

        public int getSkill() {
            return this.skill;
        }

        public int getSpeed() {
            return this.speed;
        }

        public int getLuck() {
            return this.luck;
        }

        public int getDefence() {
            return this.defence;
        }

        public int getResistance() {
            return this.resistance;
        }

        public int getConstitution() {
            return this.constitution;
        }

        public int getWeight() {
            return this.weight;
        }

        public int getMovement() {
            return this.movement;
        }

        public Team getTeam() {
            return this.team;
        }

        public void setEquippedItemIndex(int equippedItemIndex) {
            this.equippedItemIndex = equippedItemIndex;
        }

        public void levelUp() {
            this.level++;
            //Do levelling up of stats
        }

        //public int calculateDamage()

        public void takeDamage(int damageTaken) {
            if (this.hp - damageTaken >= 0) {
                this.hp -= damageTaken;
            }
            else {
                this.hp = 0;
            }
        }

        public void heal(int healAmount) {
            if (this.hp + healAmount <= this.maxHp) {
                this.hp += healAmount;
            }
            else {
                this.hp = maxHp;
            }
        }

        public void tick() {}
    }
}