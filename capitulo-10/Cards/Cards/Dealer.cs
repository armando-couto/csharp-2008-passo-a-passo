namespace Cards
{
	class Dealer
	{
		public static void Deal(Pack pack, Game game)
		{
			game.Clear();

			Hand[] hands = 
			{ 
				game.North(), 
				game.South(), 
				game.West(),
				game.East()
			};

			int handIndex = 0;

			while (!pack.IsEmpty())
			{
				PlayingCard card = pack.Deal();
				hands[handIndex].Accept(card);

				handIndex++;
				handIndex %= 4;
			}
		}
	}
}