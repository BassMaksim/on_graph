using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace on_graph
{
    public class Edge : IEquatable<Edge>
    {
        private int FirstVertex, LastVertex, EdgeCost;

        public int first_vertex
        {
            get { return FirstVertex; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                FirstVertex = value;
            }
        }
        public int last_vertex
        {
            get { return LastVertex; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                LastVertex = value;
            }
        }
        public int edge_cost
        {
            get { return EdgeCost; }
            set { EdgeCost = value; }
        }

        public Edge()
        {
        }

        public Edge(int __first_vertex, int __last_vertex, int __edge_cost)
        {
            if (__first_vertex == __last_vertex)
                Console.WriteLine("\nInput different vertex numbers, please!");
            else
            {
                first_vertex = __first_vertex;
                last_vertex = __last_vertex;
                edge_cost = __edge_cost;
            }
        }

        public Edge(Edge AnotherEdge)
        {
            first_vertex = AnotherEdge.first_vertex;
            last_vertex = AnotherEdge.last_vertex;
            edge_cost = AnotherEdge.edge_cost;
        }

        public Edge Modify(int __first_vertex, int __last_vertex, int __edge_cost)
        {
            if (__first_vertex == __last_vertex)
            {
                Console.WriteLine("\nInput different vertex numbers, please!");
                return this;
            }
            else
            {
                Edge NewEdge = new Edge(__first_vertex, __last_vertex, __edge_cost);
                return NewEdge;
            }
        }

        public bool Equals(Edge AnotherEdge)
        {
            if (first_vertex == AnotherEdge.first_vertex && last_vertex == AnotherEdge.last_vertex && edge_cost == AnotherEdge.edge_cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return first_vertex.ToString() + " " + last_vertex.ToString() + " |" + edge_cost.ToString();
        }
    }
}