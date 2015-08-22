public class FoodMonsterImpl : FoodMonster {
	private static FoodMonsterImpl INSTANCE;
		
	private int food;
		
	private FoodMonsterImpl() {
		food = 0;
	}

	public static FoodMonster GetInstance() {
		if (INSTANCE == null) {
			INSTANCE = new FoodMonsterImpl();
		}
		return INSTANCE;
	}

	public int getCurrentFood() {
		return food;
	}

	public void eatFood(){
		food++;
	}
}
