using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

namespace Game
{
	[Serializable]
	public class Environment
	{
		private int rad,dy,shift;
		private bool turn;
		private Point lastPoint;
		private Color pBackGround;
		private bool imageFlag;

		public Environment(bool whoStart)
		{
			shift=5;
			this.InitializeEnvironment(whoStart);
		}
		public void InitializeEnvironment(bool trn)
		{
			turn=trn;
			imageFlag=true;
			pBackGround=System.Drawing.SystemColors.Info;
			lastPoint=new Point(-1,-1);
		}

		#region Environment properties
		public int Rad
		{
			get
			{
				return rad;
			}
			set
			{
				rad=value;
			}
		}
		public int Dy
		{
			get
			{
				return dy;
			}
			set
			{
				dy=value;
			}
		}
		
		public int Shift
		{
			get
			{
				return shift;
			}
			set
			{
				shift=value;
			}
		}
		
		public Point LastPoint
		{
			get
			{
				return lastPoint;
			}
			set
			{
				lastPoint=value;
			}
		}
		public bool Turn
		{
			get
			{
				return turn;
			}
			set
			{
				turn=value;
			}
		}
		
		public Color PBackGround
		{
			get
			{
				return pBackGround;
			}
			set
			{
				pBackGround=value;
			}
		}
		
		public bool ImageFlag
		{
			get
			{
				return imageFlag;
			}
			set
			{
				imageFlag=value;
			}
		}
		#endregion

	}
}
