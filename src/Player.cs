using System;
using System.Drawing;

namespace Game
{
	[Serializable]
	public class Player
	{
		private string name;
		private Color pColor;
		[NonSerialized] private Brush pBrush;
		[NonSerialized] static Brush tBrush=new TextureBrush(new Bitmap("..\\..\\back2.jpg"));
		[NonSerialized] static Brush bBrush=Brushes.White;

		private int score;
		public Player(string nm, Color color)
		{
			this.Name=nm;
			this.Score=0;
			this.pColor=color;
			this.CBrush=new SolidBrush(pColor);
		}
		public static Brush DefualtBrush()
		{
			return tBrush;
		}

		public static void SwapBrush()
		{
			Brush tmp = Player.tBrush;
			Player.tBrush = Player.bBrush;
			Player.bBrush = tmp;
		}
				
		#region Player properties
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name=value;
			}
		}

		public Brush CBrush
		{
			get
			{
				return pBrush;
			}
			set
			{
				pBrush=value;
			}
		}

		public int Score
		{
			get
			{
				return score;
			}
			set
			{
				score=value;
			}
		}

		public Color CColor
		{
			get
			{
				return pColor;
			}
			set
			{
				pColor=value;
			}
		}
		public Color SetPlayerBrush
		{
			set
			{
				pColor=value;
				pBrush=new SolidBrush(pColor);
			}
		}

		#endregion
	}
}
