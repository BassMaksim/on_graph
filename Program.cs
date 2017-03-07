using System;

namespace on_graph
{
    class Program
    {
        public static int __WAIT_IN_SECONDS_BEFORE_EXIT__ = 0;
        public static int __WAIT_IN_SECONDS_BEFORE_EXIT_FAILURE__ = 5; //in case of exception call

        public static string __FILEPATH__ = "C:";
        public static string __OUTPUT_FILENAME__ = "\\output.txt"; //input name of the file is "input.txt" in the same directory

        static void Main(string[] args) //assuming the number of vertexes is the number of crossroads
        {
            try
            {
                FileManager FM = new FileManager(true); //has 2 default boolean arguments: 1st - for file-off activity, 2nd - for accessing the console
                Graph MyOrientGraph = new Graph(); //create graph as list of edges
                Edge MyEdge = new Edge(); //create one edge in format <int FirstVertex, int LastVertex, int EdgeCost>

                for (int i = 0; i < FM.numberOfRoads; ++i) //the graph is filled by FileManager's scanned data
                {
                    MyEdge = MyEdge.Modify(FM.firstPoint[i], FM.lastPoint[i], FM.passTime[i]);
                    MyOrientGraph.AddEdge(MyEdge);
                }

                int Result = MyOrientGraph.Solving(FM.numberOfCrosses, FM.startPoint, FM.finishPoint);
                FM.FileRecorder(Result, MyOrientGraph.Infinity());

                System.Threading.Thread.Sleep(1000 * __WAIT_IN_SECONDS_BEFORE_EXIT__);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error occurred: " + e.Message);
                System.Threading.Thread.Sleep(1000 * __WAIT_IN_SECONDS_BEFORE_EXIT_FAILURE__);
                Environment.Exit(1);
            }
        }
    }
}
