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
                    else
                        Console.Write(". ");
                }
                Console.WriteLine("#" + i + "   ");
            }
        }

    }
}
