using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Game
{
	[Serializable]
	public class GameMatrix
	{                                         
		private int[,] gameBord;
		private int[] collArray;
		private Point[] victoryVec;
		private ArrayList undoList,redoList;
		private int diskCounter,victoryFlag,m_vCount;
		
		public GameMatrix()
		{
			gameBord=new int[6,7];
			collArray=new int[7];
			victoryVec=new Point[7];
			undoList=new ArrayList();
			redoList=new ArrayList();
			victoryFlag=0;
			m_vCount=4;
			Reset();
		}
		
		public int GetBorg(int i, int j)
		{
			if(gameBord[i,j]!=0)
				return gameBord[i,j];
			else
				return 0;
		}
		
		public bool SetBord(int col, int player, bool redoFlag)
		{
			if(collArray[col]<6)
			{
				diskCounter++;
				int row=collArray[col];
				gameBord[5-row,col]=player;
				collArray[col]+=1;
				if(redoFlag)
				{
					undoList.Add(new Point(5-row,col));
					redoList.Clear();
				}
				return true;
			}
			else
			{
				MessageBox.Show("Collume is already Full !!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}
		public void Reset()
		{
			diskCounter=0;
			for(int i=0;i<6;i++)
				for(int j=0;j<7;j++)
					gameBord[i,j]=0;
			for(int k=0;k<7;k++)
				collArray[k]=0;
			victoryFlag=0;
			undoList.Clear();
			redoList.Clear();
		}
		
		public Point GetVictoryPath(int i)
		{
			return victoryVec[i];
		}

		#region Victory Search
		public void CheckVictory(int current)
	    {
		   int i,j,k,m,vFlag=1;
		
		   // Loop to check rows
		   for(i=0;i<6 && vFlag==1;i++)
			   for(j=0;j<(7-m_vCount+1) && vFlag==1;j++)
				   if(gameBord[i,j]==current)
				   {
					   victoryVec[0]=new Point(i,j);
					   for(k=1;k<m_vCount;k++)
					   if(gameBord[i,j+k]!=current)
						   break;
					   else
					   victoryVec[k]=new Point(i,j+k);
					   if(k==m_vCount)
						   vFlag=0;
				   }
		   // Loop to check collums
		   for(j=0;j<7 && vFlag==1;j++)
			   for(i=0;i<(6-m_vCount+1) && vFlag==1;i++)
				   if(gameBord[i,j]==current)
				   {
					   victoryVec[0]=new Point(i,j);
					   for(k=1;k<m_vCount;k++)
					   if(gameBord[i+k,j]!=current)
						   break;
					   else
						   victoryVec[k]=new Point(i+k,j);
					   if(k==m_vCount)
						   vFlag=0;
				   }

		   // Loop to check diagonals
		   for(i=0;i<=(6-m_vCount) && vFlag==1;i++)
		   {
			   j=i+1;
			   for(m=0;m<=(7-j-m_vCount) && vFlag==1;m++) 
			   {
				   if(gameBord[m,j+m]==current) // checking j diagonals  --> \  
				   {
					   victoryVec[0]=new Point(m,j+m);
					   for(k=1;k<m_vCount;k++)
						   if(gameBord[m+k,j+m+k]!=current)
							   break;
						   else
							   victoryVec[k]=new Point(m+k,j+m+k);
					   if(k==m_vCount)
					   {
						   vFlag=0;
						   break;
					   }
				   }
				   if(gameBord[m,6-j-m]==current) // checking j diagonals  --> /  
				   {
					   victoryVec[0]=new Point(m,6-j-m);
					   for(k=1;k<m_vCount;k++)
						   if(gameBord[m+k,6-j-m-k]!=current)
							   break;
						   else
							   victoryVec[k]=new Point(m+k,6-j-m-k);
						if(k==m_vCount)
						{
							vFlag=0;
							break;
						}
				   }
				   if(gameBord[i+m,m]==current) // checking i diagonals  --> \  
				   {
					   victoryVec[0]=new Point(i+m,m);
					   for(k=1;k<m_vCount;k++)
						   if(gameBord[i+m+k,m+k]!=current)
							   break;
						   else
							   victoryVec[k]=new Point(i+m+k,m+k);
					   if(k==m_vCount)
					   {
						   vFlag=0;
						   break;
					   }
				   }
				   if(gameBord[i+m,6-m]==current) // checking i diagonals  --> /  
				   {
					   victoryVec[0]=new Point(i+m,6-m);
					   for(k=1;k<m_vCount;k++)
						   if(gameBord[i+m+k,6-m-k]!=current)
							   break;
						   else
							   victoryVec[k]=new Point(i+m+k,6-m-k);
					   if(k==m_vCount)
						   vFlag=0;
				   }
			   }
			}
			if(vFlag==0)
			   victoryFlag=1;
			else
			   if(diskCounter<42)
				   victoryFlag=0;
			   else 
				   victoryFlag=4;
	   }
		#endregion
		
		#region Matrix Properties
		public int GameWinType
		{
			get
			{
				return m_vCount;
			}
			set
			{
				m_vCount=value;
			}
		}

		public int IsWinner
		{
			get
			{
				return victoryFlag;
			}
			set
			{
				victoryFlag=value;
			}
		}		
		public int DiskCounter
		{
			get
			{
				return diskCounter;
			}
		}
		
		public Point UndoLast
		{
			get
			{
				if(diskCounter==0)
					return new Point(-1,-1);
				Point p=(Point)undoList[undoList.Count-1];
				gameBord[p.X,p.Y]=0;
				diskCounter--;
				collArray[p.Y]-=1;
				redoList.Add(undoList[undoList.Count-1]);
				undoList.RemoveAt(undoList.Count-1);
				return p;
			}
		}
		
		public Point RedoLast
		{
			get
			{
				if(redoList.Count==0)
					return new Point(-1,-1);
				undoList.Add(redoList[redoList.Count-1]);
				redoList.RemoveAt(redoList.Count-1);
				return (Point)undoList[undoList.Count-1];
			}
		}

			public Point LastUsedCell
		{
			get
			{
				return (Point)undoList[undoList.Count-1];
			}
		}
	
		public int IsRedoable
		{
			get
			{
				return redoList.Count;
			}
		}

		public int VictoryType
		{
			get
			{
				return m_vCount;
			}
			set
			{
				m_vCount=value;
			}
		}
		#endregion
		
	}
}
