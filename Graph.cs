using System;
using System.Collections.Generic;

namespace on_graph
{
    public class Graph
    {
        private List<Edge> MyEdgesList;

        public List<Edge> my_graph
        {
            get { return MyEdgesList; }
            set { MyEdgesList = value; } 
        }

        public Graph()
        {
            my_graph = new List<Edge>();
        }

        public Graph(Graph AnotherGraph)
        {
            my_graph = new List<Edge>();
            List<Edge> newList = new List<Edge>(AnotherGraph.my_graph.Count);
            AnotherGraph.my_graph.ForEach((item) =>
            {
                newList.Add(new Edge(item));
            });
        }

        public int Infinity() //evaluates required value for solving algorithm
        {
            int INF = 1;
            foreach (var temp in my_graph)
                INF += Math.Abs(temp.edge_cost);
            return INF;
        }

        public void AddEdge(Edge AnotherEdge)
        {
            if (my_graph.Contains(AnotherEdge))
                Console.WriteLine("An edge already exists in a graph.");
            else
                my_graph.Add(AnotherEdge);
        }

        public void DeleteEdge(Edge AnotherEdge)
        {
            my_graph.Remove(AnotherEdge);
        }

        public void DeleteEdge(uint Position)
        {
            my_graph.RemoveAt(Convert.ToInt32(Position));
        }

        public void ResetGraph()
        {
            my_graph.Clear();
        }

        public int Solving(int VertexCount, int VertexStart, int VertexFinish) //Bellman–Ford algorithm
        {
            int INF = Infinity();

            if (VertexStart < 0 || VertexFinish < 0 || VertexCount < 0 || VertexStart > VertexCount || VertexFinish > VertexCount) //checking for correctness
            {
                Console.WriteLine("[public int Solving()]: wrong parameters.");
                return -(INF);
            }
            
	        List<int> DistanceList = new List<int>(VertexCount + 1);
            for (int i = 0; i < VertexCount + 1; ++i)
                DistanceList.Add(INF);
            DistanceList[VertexStart] = 0;

            int x;
            for (int i = 0; i < VertexCount; ++i)
            {
                x = -1;
                for (int j = 0; j < my_graph.Count; ++j)
                    if (DistanceList[my_graph[j].first_vertex] < INF)
                        if (DistanceList[my_graph[j].last_vertex] > DistanceList[my_graph[j].first_vertex] + my_graph[j].edge_cost)
                        {
                            DistanceList[my_graph[j].last_vertex] = Math.Max(-INF, DistanceList[my_graph[j].first_vertex] + my_graph[j].edge_cost);
                            x = my_graph[j].last_vertex;
                        }
            }
            return DistanceList[VertexFinish];
        }
    }
}