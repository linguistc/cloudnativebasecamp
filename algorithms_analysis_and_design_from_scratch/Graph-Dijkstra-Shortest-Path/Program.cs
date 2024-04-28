using System;
using System.Collections.Generic;


internal class Program
{

    public class clsVertex
    {
        public string Name;
        public bool Visited;

        public double TotalLength;
        public clsVertex SourceOFTotalLength;

        public clsEdge[] VertexLinks;
    }

    public class clsEdge
    {
        public double Weight;
        public clsVertex Source;
        public clsVertex Destination;

        public clsEdge(clsVertex Source, clsVertex Destination, double Weight = 0)
        {
            this.Source = Source;
            this.Destination = Destination;
            this.Weight = Weight;
        }
    }

    public class clsGraph
    {
        private int _LastIndex = 0;
        public clsVertex[] Vertices;

        public clsGraph(string[] Names)
        {
            Vertices = new clsVertex[Names.Length];
            foreach (string name in Names)
            {
                this.Vertices[_LastIndex] = new clsVertex();
                this.Vertices[_LastIndex].Name = name;
                ++_LastIndex;
            }
        }

        public void AddEdges(int VertexIndex, int[] Destinations)
        {
            this.Vertices[VertexIndex].VertexLinks = new clsEdge[Destinations.Length];
            for (int i = 0; i < Destinations.Length; ++i)
            {
                this.Vertices[VertexIndex].VertexLinks[i] =
                    new clsEdge(this.Vertices[VertexIndex],
                    this.Vertices[Destinations[i]]);
            }

        }

        public void AddEdges(int VertexIndex, int[] Destinations, double[] Weights)
        {
            this.Vertices[VertexIndex].VertexLinks = new clsEdge[Destinations.Length];

            for(int i = 0;i < Destinations.Length; ++i)
            {
                Vertices[VertexIndex].VertexLinks[i] =
                    new clsEdge(this.Vertices[VertexIndex], this.Vertices[Destinations[i]], Weights[i]);
            }
        }



        public void BFS()
        {
            Console.WriteLine("BFS From Graph Class:");
            int v = this.Vertices.Length;

            Queue<clsVertex> queue = new Queue<clsVertex>(v);

            queue.Enqueue(this.Vertices[0]);
            this.Vertices[0].Visited = true;

            clsVertex CurrentVertex;
            clsEdge[] Destinations;

            while (queue.Count > 0)
            {
                CurrentVertex = queue.Dequeue();
                if (CurrentVertex.VertexLinks != null)
                {

                    Destinations = CurrentVertex.VertexLinks;

                    for (int i = 0; i < Destinations.Length; ++i)
                    {
                        if (!Destinations[i].Destination.Visited)
                        {
                            queue.Enqueue(Destinations[i].Destination);
                            Destinations[i].Destination.Visited = true;
                            Console.WriteLine(CurrentVertex.Name + " -> " + Destinations[i].Destination.Name);
                        }
                    }
                }
            }

            ResetVertices();
        }

        public void DFS()
        {
            Console.WriteLine("DFS From Graph Class:");
            DFSRecursion(this.Vertices[0]);
            ResetVertices();
        }
        public void DFSRecursion(clsVertex CurrentVertex)
        {
            CurrentVertex.Visited = true;
            clsEdge[] Destinations = CurrentVertex.VertexLinks;

            if (CurrentVertex.VertexLinks != null)
            {

                for (int i = 0; i < Destinations.Length; ++i)
                {
                    if (!Destinations[i].Destination.Visited)
                    {
                        Console.WriteLine(CurrentVertex.Name + " -> " + Destinations[i].Destination.Name);
                        DFSRecursion(Destinations[i].Destination);
                    }
                }
            }
        }

        public void Dijkstra()
        {
            Console.WriteLine("Dijkstra From Graph Class:");

            for (int i = 1; i < this.Vertices.Length; ++i)
            {
                this.Vertices[i].TotalLength = double.MaxValue;
            }

            clsVertex CurrentVertex;
            for (int i = 0;i < this.Vertices.Length; ++i)
            {
                CurrentVertex = this.Vertices[i];
                clsEdge[] Destinations = CurrentVertex.VertexLinks;

                if (Destinations == null) continue;

                clsEdge CurrentEdge;
                for (int j = 0;  j < Destinations.Length; ++j)
                {
                    CurrentEdge = Destinations[j];

                    double NewLength = CurrentVertex.TotalLength + CurrentEdge.Weight;

                    if(NewLength < CurrentEdge.Destination.TotalLength)
                    {
                        CurrentEdge.Destination.TotalLength = NewLength;
                        CurrentEdge.Destination.SourceOFTotalLength = CurrentVertex;
                    }
                }

            }

            string path = this.Vertices[this.Vertices.Length - 1].Name;
            clsVertex v = this.Vertices[this.Vertices.Length-1];

            while (v.SourceOFTotalLength != null)
            {
                path = v.SourceOFTotalLength.Name + " -> " + path;
                v = v.SourceOFTotalLength;
            }

            Console.WriteLine(this.Vertices[this.Vertices.Length - 1].TotalLength);
            Console.WriteLine(path);

            this.ResetVertices();
        }

        public void ResetVertices()
        {
            foreach (clsVertex V in this.Vertices)
                V.Visited = false;
        }
    }

    static void Main(string[] args)
    {
        clsGraph graph = new clsGraph(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" });
        graph.AddEdges(0, new int[] { 1, 2, 3 }, new double[] { 2, 4, 3 });

        graph.AddEdges(1, new int[] { 4, 5, 6 }, new double[] { 7, 4, 6 });
        graph.AddEdges(2, new int[] { 4, 5, 6 }, new double[] { 3, 2, 4 });
        graph.AddEdges(3, new int[] { 4, 5, 6 }, new double[] { 4, 1, 5 });

        graph.AddEdges(4, new int[] { 7, 8 }, new double[] { 1, 4 });
        graph.AddEdges(5, new int[] { 7, 8 }, new double[] { 6, 3 });
        graph.AddEdges(6, new int[] { 7, 8 }, new double[] { 3, 3 });

        graph.AddEdges(7, new int[] { 9 }, new double[] { 3 });
        graph.AddEdges(8, new int[] { 9 }, new double[] { 4 });



        graph.BFS();
        graph.DFS();
        graph.Dijkstra();
        Console.ReadKey();
    }
}
