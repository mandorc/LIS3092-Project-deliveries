using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man
{
    internal class Manhattan
    {
        // We setup this variable before calling movetotarget
        public static int[,] pacmanMap = new int[500, 250];

        public void setMap(int[,] map)
        {
            pacmanMap = map;
        }

        static int[][] MoveToTarget(int[] currentPosition, int[] targetPosition, int nMovements)
        {
            int rows = pacmanMap.GetLength(0);
            int cols = pacmanMap.GetLength(1);

            int[,] distance = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    distance[i, j] = Math.Abs(i - targetPosition[0]) + Math.Abs(j - targetPosition[1]);
                }
            }

            int[][] nextMoves = new int[nMovements][];
            for (int k = 0; k < nMovements; k++)
            {
                int[] nextPosition = new int[2];
                int minDistance = int.MaxValue;
                for (int i = currentPosition[0] - 1; i <= currentPosition[0] + 1; i++)
                {
                    for (int j = currentPosition[1] - 1; j <= currentPosition[1] + 1; j++)
                    {
                        if (i >= 0 && i < rows && j >= 0 && j < cols)
                        {
                            if (pacmanMap[i, j] == 1)
                            {
                                continue;
                            }

                            if ((i == currentPosition[0] || j == currentPosition[1]) && distance[i, j] < minDistance)
                            {
                                minDistance = distance[i, j];
                                nextPosition[0] = i;
                                nextPosition[1] = j;
                            }
                        }
                    }
                }

                nextMoves[k] = nextPosition;
                currentPosition = nextPosition;
            }

            return nextMoves;
        }

        public int GetDirection(int[] currentPosition, int[] targetPosition)
        {
            int xDiff = targetPosition[0] - currentPosition[0];
            int yDiff = targetPosition[1] - currentPosition[1];

            if (xDiff == 0 && yDiff > 0)
            {
                return 1; //arriba
            }
            else if (xDiff == 0 && yDiff < 0)
            {
                return 2; //abajo
            }
            else if (xDiff > 0 && yDiff == 0)
            {
                return 3; //derecha
            }
            else if (xDiff < 0 && yDiff == 0)
            {
                return 4; //izquierda
            }
            else
            {
                return 0;
            }

        }

        public int[] NextMove(int[] currentP, int[] targetP, int nMovements)
        {

            int[][] nextMoves = MoveToTarget(currentP, targetP, nMovements);
            // Las direcciones que vamos a devolver
            int[] directions = new int[nMovements];
            int[] tempTarget = new int[2];
            int[] tempCurrent = new int[2];

            tempCurrent[0] = currentP[0];
            tempCurrent[1] = currentP[1];

            for (int i = 0; i < nextMoves.Length; i++)
            {
                tempTarget[0] = nextMoves[i][0];
                tempTarget[1] = nextMoves[i][1];

                directions[i] = GetDirection(tempCurrent, tempTarget);
                Console.WriteLine("Decide moverse hacia: " +directions[i]);
                // Posible falla
                tempCurrent[0] = tempTarget[0];
                tempCurrent[1] = tempTarget[1];
            }

            return directions;
        }
    }
}
