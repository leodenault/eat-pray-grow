namespace Assets.src {
	public class FoodMonsterImpl : FoodMonster {
		private int food;
		
		public FoodMonsterImpl() {
			food = 0;
		}

		public int getCurrentFood() {
			return food;
		}
	}
}
