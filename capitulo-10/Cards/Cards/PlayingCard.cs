namespace Cards
{
	class PlayingCard
	{
		public const int Ace = 1;
		public const int Jack = 11;
		public const int Queen = 12;
		public const int King = 13;

		public PlayingCard(Suit s, int p)
		{
			suit = s;
			pips = p;
		}
		public override string ToString()
		{
			string result = "";
			switch (pips)
			{
				case PlayingCard.Ace :
					result += "Ace"; 
					break;
				case PlayingCard.Jack :
					result += "Jack"; 
					break;
				case PlayingCard.Queen :
					result += "Queen"; 
					break;
				case PlayingCard.King :
					result += "King"; 
					break;
				default :
					result += pips.ToString();
					break;
			}
			result += " ";
			result += suit.ToString();

			return result;
		}
		private readonly Suit suit;
		private readonly int pips;
	}
}