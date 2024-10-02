using System;
using System.Collections.Generic;
using System.Drawing;

namespace FindPath.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[25, 25]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            foreach (var point in FindShortestPath(arr))
            {
                Console.WriteLine(point);
            }

            Console.ReadKey();
        }

        // BFS algoritm
        public static Point[] FindShortestPath(int[,] arr)
        {
            try
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                // Cardinal moves
                var cardinalDirections = new (int, int)[]
                {
                    (1, 0), (0, 1), (-1, 0), (0, -1)
                };

                // Diagonal moves 
                var diagonalDirections = new (int, int)[]
                {
                    (-1, -1), (-1, 1), (1, -1), (1, 1)
                };

                Queue<(int x, int y)> queue = new();
                bool[,] visited = new bool[rows, cols];
                (int x, int y)[,] parent = new (int, int)[rows, cols];

                queue.Enqueue((0, 0));
                visited[0, 0] = true;

                // Start point
                parent[0, 0] = (-1, -1);

                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();

                    if (x == rows - 1 && y == cols - 1)
                        break;

                    // Cardinal movemant
                    foreach (var (dx, dy) in cardinalDirections)
                    {
                        try
                        {
                            int newX = x + dx;
                            int newY = y + dy;

                            if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && !visited[newX, newY])
                            {
                                int value = arr[newX, newY];

                                visited[newX, newY] = true;
                                parent[newX, newY] = (x, y);
                                queue.Enqueue((newX, newY));
                            }
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine($"Index out of bounds: {ex.Message}");
                            break;
                        }
                    }

                    // Diagonal movement
                    foreach (var (dx, dy) in diagonalDirections)
                    {
                        try
                        {
                            int newX = x + dx;
                            int newY = y + dy;

                            if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && !visited[newX, newY])
                            {
                                int value = arr[newX, newY];

                                if (arr[x, y] != 0 && value != 0)
                                {
                                    visited[newX, newY] = true;
                                    parent[newX, newY] = (x, y);
                                    queue.Enqueue((newX, newY));
                                }
                            }
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine($"Index out of bounds: {ex.Message}");
                            continue;
                        }
                    }
                }

                // Backtrack
                try
                {
                    List<Point> path = new();
                    var (px, py) = (rows - 1, cols - 1);

                    while (parent[px, py] != (-1, -1))
                    {
                        path.Add(new Point(px, py));
                        (px, py) = parent[px, py];
                    }

                    path.Add(new Point(0, 0));
                    path.Reverse();

                    return path.ToArray();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Error during backtracking: {ex.Message}");
                    return Array.Empty<Point>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return Array.Empty<Point>();
            }
        }
    }
}
