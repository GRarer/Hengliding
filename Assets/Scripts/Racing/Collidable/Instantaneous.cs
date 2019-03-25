namespace Racing.Collidables {
	public abstract class Instantaneous : RaceCollidable {

		public override void applyGeneralEffect(Glider glider) {
			//TODO: Do general boost things here
			//Luckily, destory waits until after the current update loop, so applySpecificEffect will still execute
			Destroy(this.gameObject);
		}
	}
}