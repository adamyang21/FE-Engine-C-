using System;

namespace FEEngine.Engine {
    public class ActorPositionMapping {
        //ATTRIBUTES
        private Dictionary<Position, Actor> positionToActor;
        private Dictionary<Actor, Position> actorToPosition;



        //METHODS
        public ActorPositionMapping() {
            this.positionToActor = new Dictionary<Position, Actor>();
            this.actorToPosition = new Dictionary<Actor, Position>();
        }

        public void addActor(Actor actor, Position position) {
            if (actorToPosition.ContainsKey(actor)) {
                throw new Exception("Cannot add an actor that already exists");
            }
            if (positionToActor.ContainsKey(position)) {
                throw new Exception("Cannot add a position that already exists");
            }
            this.actorToPosition[actor] = position;
            this.positionToActor[position] = actor;
        }

        public void removeActor(Actor actor) {
            Position position = actorToPosition[actor];
            this.actorToPosition.Remove(actor);
            this.positionToActor.Remove(position);
        }

        public void moveActor(Actor actor, Position newPosition) {
            if (this.positionToActor.ContainsKey(newPosition)) {
                throw new Exception("Cannot move actor to a location with another existing actor.");
            }

            Position oldPosition = this.actorToPosition[actor];
            this.actorToPosition[actor] = newPosition;
            this.positionToActor.Remove(oldPosition);
            this.positionToActor[newPosition] = actor;
        }

        public bool containsActor(Actor actor) {
            return this.actorToPosition.ContainsKey(actor);
        }

        public bool locationHasActor(Position position) {
            return this.positionToActor.ContainsKey(position);
        }

        public Actor getActorAtPosition(Position position) {
            return this.positionToActor[position];
        }

        public Position getActorLocation(Actor actor) {
            return this.actorToPosition[actor];
        }

        public bool positionHasGivenActor(Position position, Actor actor) {
            return this.positionToActor[position] == actor;
        }

        public void tickActors() {
            foreach (KeyValuePair<Actor, Position> pair in this.actorToPosition) {
                Actor actor = pair.Key;
                actor.tick();
            }
        }
    }
}