namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
		public Pack()
		{
			for (int pips = PlayingCard.Ace; pips <= PlayingCard.King; ++pips)
			{
				Accept(new PlayingCard(Suit.Clubs, pips));
				Accept(new PlayingCard(Suit.Diamonds, pips));
				Accept(new PlayingCard(Suit.Hearts, pips));
				Accept(new PlayingCard(Suit.Spades, pips));
			}
		}

		public bool IsEmpty()
		{
			return cards.Count == 0;
		}

		public PlayingCard Deal()
		{
			if (cards.Count == 0)
			{
				throw new InvalidOperationException("can't deal from empty pack");
			}
			PlayingCard dealt = (PlayingCard)cards[0];
			cards.RemoveAt(0);
			return dealt;
		}

		public void Accept(PlayingCard card)
		{
			cards.Add(card);
		}

		public void Clear()
		{
			cards.Clear();
		}

		public void Shuffle()
		{
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int cardToSwap = random.Next(cards.Count - 1);
                object temp = cards[i];
                cards[i] = cards[cardToSwap];
                cards[cardToSwap] = temp;
            }
		}

        private ArrayList cards = new ArrayList();
	}
}