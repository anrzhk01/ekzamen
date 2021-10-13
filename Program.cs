using System;

class GFG
{
	static int V = 7;
	int minDistance(int[] dist,
					bool[] sptSet)
	{
		int min = int.MaxValue, min_index = -1;

		for (int v = 0; v < V; v++)
			if (sptSet[v] == false && dist[v] <= min)
			{
				min = dist[v];
				min_index = v;
			}

		return min_index;
	}

	void printSolution(int[] dist, int n)
	{
		Console.Write("Расстояние до вершины "
					+ "из источника\n");
		for (int i = 0; i < V; i++)
			Console.Write(i + " \t\t " + dist[i] + "\n");
	}

	void dijkstra(int[,] graph, int src)
	{
		int[] dist = new int[V];
		bool[] sptSet = new bool[V];

		for (int i = 0; i < V; i++)
		{
			dist[i] = int.MaxValue;
			sptSet[i] = false;
		}

		dist[src] = 0;
		for (int count = 0; count < V - 1; count++)
		{
			int u = minDistance(dist, sptSet);
			sptSet[u] = true;
			for (int v = 0; v < V; v++)
				if (!sptSet[v] && graph[u, v] != 0 &&
					dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
					dist[v] = dist[u] + graph[u, v];
		}
		printSolution(dist, V);
	}

	public static void Main()
	{
		int[,] graph = new int[,] { { 0, 2, 4, 10, 0, 0, 0},
									{ 2, 0, 11, 0, 5, 0, 0},
									{ 4, 11, 0, 3, 0, 1, 0 },
									{ 10, 0, 3, 0, 8, 7, 9},
									{ 0, 5, 0, 8, 0, 0, 6},
									{ 0, 0, 1, 7, 0, 0, 6},
									{ 0, 0, 0, 9, 6, 6, 0}};
		GFG t = new GFG();
		t.dijkstra(graph, 0);
	}
}
