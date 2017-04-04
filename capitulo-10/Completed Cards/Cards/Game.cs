namespace Cards
{
	class Game
	{
		public Hand North()
		{
			return north;
		}

		public Hand South()
		{
			return south;
		}

		public Hand West()
		{
			return west;
		}

		public Hand East()
		{
			return east;
		}

		public void Clear()
		{
			north.Clear();
			south.Clear();
			west.Clear();
			east.Clear();
		}

		public void ReturnHandsTo(Pack pack)
		{
			north.ReturnCardsTo(pack);
			south.ReturnCardsTo(pack);
			west.ReturnCardsTo(pack);
			east.ReturnCardsTo(pack);
		}

		private Hand north = new Hand(), 
			         south = new Hand(), 
			         west = new Hand(), 
			         east = new Hand();
	}
}