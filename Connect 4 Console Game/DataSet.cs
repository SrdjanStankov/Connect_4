using System;

namespace Connect_4_Console_Game
{
	public class DataSet
	{
		private static int colCount = 7;
		private static int rowCount = 6;

		private readonly char[,] mat = new char[rowCount, colCount];

		public DataSet()
		{
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < colCount; j++)
				{
					mat[i, j] = '0';
				}
			}
		}

		public bool AddCharOnCol(char c, int col)
		{
			if (col > colCount || col < 1)
			{
				return false;
			}

			col--;

			for (int i = rowCount - 1; i >= 0; i--)
			{
				if (mat[i, col] == '0')
				{
					mat[i, col] = c;
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Proverava da li ima 4 ista dijagonalno u levu stranu
		/// </summary>
		/// <returns>
		/// vraca karkater koji se javlja 4 puta
		/// '~' karakter znaci nema 4 u redu 
		/// </returns>
		private char Check4DiagLeft()
		{
			char prethodni = '0';
			char nadjeni = '~';
			int diag = 0;

			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < colCount; j++)
				{
					if (mat[i, j] != '0')
					{
						prethodni = mat[i, j];

						for (int k = i, l = j; k < rowCount && l >= 0; k++, l--)
						{
							if (k == i && l == j)
							{
								nadjeni = '~';
								continue;
							}

							if (diag == 3)
							{
								diag = 0;
								return nadjeni;
							}

							if (mat[k, l] == prethodni)
							{
								diag++;
								nadjeni = prethodni;
							}
							else
							{
								diag = 0;
								nadjeni = '~';
								break;
							}
						}
						if (diag == 3)
						{
							diag = 0;
							return nadjeni;
						}
						else
						{
							nadjeni = '~';
							diag = 0;
						}
					}
				}

			}
			return nadjeni;
		}

		/// <summary>
		/// Proverava da li ima 4 ista dijagonalno u desnu stranu
		/// </summary>
		/// <returns>
		/// vraca karkater koji se javlja 4 puta
		/// '~' karakter znaci nema 4 u redu 
		/// </returns>
		private char Check4DiagRight()
		{
			char prethodni = '0';
			char nadjeni = '~';
			int diag = 0;

			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < colCount; j++)
				{
					if (mat[i, j] != '0')
					{
						prethodni = mat[i, j];
						for (int k = i, l = j; k < rowCount && l < colCount; k++, l++)
						{
							if (diag == 4)
							{
								diag = 0;
								return nadjeni;
							}

							if (mat[k, l] == prethodni)
							{
								diag++;
								nadjeni = prethodni;
							}
							else
							{
								diag = 0;
								nadjeni = '~';
								break;
							}
						}
						if (diag == 4)
						{
							diag = 0;
							return nadjeni;
						}
						else
						{
							nadjeni = '~';
							diag = 0;
						}
					}
				}
			}
			return nadjeni;
		}
		/// <summary>
		/// Proverava da li ima 4 ista u koloni
		/// </summary>
		/// <returns>
		/// vraca karkater koji se javlja 4 puta u redu
		/// '~' karakter znaci nema 4 u redu 
		/// </returns>
		private char Check4InColumns()
		{
			char prethodni = '0';
			char nadjeni = '~';
			int inCol = 0;

			for (int i = 0; i < colCount; i++)
			{
				for (int j = 0; j < rowCount; j++)
				{
					Console.WriteLine(mat[j, i] + " " + nadjeni);
					if (inCol == 3)     // ima 4 u redu
					{
						inCol = 0;
						return nadjeni;
					}

					if (j == 0)     // uzimam prvog za prethodnika
					{
						prethodni = mat[j, i];
						inCol = 0;
						nadjeni = '~';
						continue;
					}

					if (mat[j, i] == '0')
					{
						inCol = 0;
						prethodni = mat[j, i];
						nadjeni = '~';
						continue;
					}

					if (prethodni == mat[j, i])
					{
						inCol++;
						nadjeni = prethodni;
					}
					else
					{
						inCol = 0;
						nadjeni = '~';
						prethodni = mat[j, i];
					}
				}
			}
			if (inCol == 3)
			{
				return nadjeni;
			}
			else
			{
				return '~';
			}
		}
		/// <summary>
		/// Proverava da li ima 4 ista u redu
		/// </summary>
		/// <returns>
		/// vraca karkater koji se javlja 4 puta u redu
		/// '~' karakter znaci nema 4 u redu 
		/// </returns>
		private char Check4InRows()
		{
			char prethodni = '0';
			char nadjeni = '~';
			int inRow = 0;

			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < colCount; j++)
				{
					if (inRow == 3)     // ima 4 u redu
					{
						inRow = 0;
						return nadjeni;
					}

					if (j == 0)     // uzimam prvog za prethodnika
					{
						prethodni = mat[i, j];
						inRow = 0;
						nadjeni = '~';
						continue;
					}

					if (mat[i, j] == '0')
					{
						inRow = 0;
						prethodni = mat[i, j];
						nadjeni = '~';
						continue;
					}

					if (prethodni == mat[i, j])
					{
						inRow++;
						nadjeni = prethodni;
					}
					else
					{
						inRow = 0;
						prethodni = mat[i, j];
						nadjeni = '~';
					}
				}
			}
			if (inRow == 3)
			{
				return nadjeni;
			}
			else
			{
				return '~';
			}
		}

		/// <summary>
		/// Proverava da li postoje 4 ista karaktera dijagonalno, horizontalno ili vertikalno
		/// </summary>
		/// <returns>
		/// <para>ako nadje vraca karakter</para>
		/// <para>ako ne nadje vraca '~'</para>
		/// </returns>
		public char Check4()
		{
			char nadjen = '~';
			if ((nadjen = Check4InRows()) != '~')
			{
				Console.WriteLine("Rows");
				return nadjen;
			}
			if ((nadjen = Check4InColumns()) != '~')
			{
				Console.WriteLine("Columns");
				return nadjen;
			}
			if ((nadjen = Check4DiagLeft()) != '~')
			{
				Console.WriteLine("Diag Left");
				return nadjen;
			}
			if ((nadjen = Check4DiagRight()) != '~')
			{
				Console.WriteLine("Diag Right");
				return nadjen;
			}
			return nadjen;
		}

		/// <summary>
		/// lepo ispisuje matricu
		/// </summary>
		public override string ToString()
		{
			string s = "";

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					s += mat[i, j] + " ";
				}
				s += '\n';
			}

			return s;
		}
	}
}