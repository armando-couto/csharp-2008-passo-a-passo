namespace Cards
{
	using System;
	using System.Collections;

	class Hand
	{
		public void Accept(PlayingCard dealt)
		{
			cards.Add(dealt);
		}

		public void Clear()
		{
			cards.Clear();
		}

		public override string ToString()
		{
			string result = "";
			foreach (PlayingCard card in cards)
			{
				result += card.ToString();
				result += "\r\n";
			}

			return result;
		}

		public void ReturnCardsTo(Pack pack)
		{
            foreach (PlayingCard card in cards)
            {
                pack.Accept(card);
            }
            cards.Clear();
		}

		private ArrayList cards = new ArrayList();
	}
}