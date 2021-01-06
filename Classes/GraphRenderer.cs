using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Classes
{
    public static class GraphRenderer
    {
        public static void RenderGraph(Graph graph)
        {
            for (int i = graph.GetGraph().GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < graph.GetGraph().GetLength(1); j++)
                {
                    if (graph.GetGraph()[j, i] == 1)
                        Console.Write("x ");
                    else if (graph.GetGraph()[j, i] == 2)
                        Console.Write("█ ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine("#" + i + "   ");
            }

            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        public static void RenderGraphClusters(Graph graph)
        {
            for (int i = graph.GetGraph().GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < graph.GetGraph().GetLength(1); j++)
                {
                    if (graph.GetGraph()[j, i] == 1)
                        Console.Write("x ");
                    else if (graph.GetGraph()[j, i] == 2)
                        Console.Write("█ ");
                    else if (graph.GetGraph()[j, i] == 10)
                        Console.Write("1 ");
                    else if (graph.GetGraph()[j, i] == 11)
                        Console.Write("2 ");
                    else if (graph.GetGraph()[j, i] == 12)
                        Console.Write("3 ");
                    else if (graph.GetGraph()[j, i] == 12)
                        Console.Write("4 ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine("#" + i + "   ");
            }

            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

    }
}
