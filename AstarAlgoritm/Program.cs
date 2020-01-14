
using AstarAlgoritm.Models;
using AStarPathFinder;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace AstarAlgoritm
{
    class Program
    { 
       
   
        static void Main(string[] args)
        { 
            Console.WriteLine("A star Tests"); 
            while (true)
            {
                var timer = new Stopwatch(); 
                // abc  Node
                var a = new Node("A", 7);
                var b = new Node("B", 3);
                var c = new Node("C", 4);
                var d = new Node("D", 6);
                var e = new Node("E", 5);
                var f = new Node("F", 6);
                var s = new Node("S", 5); 
                var g1 = new Node("G1", 1);
                var g2 = new Node("G2", 1);
                var g3 = new Node("G3", 1);
            


                    a.AddEdge(new Edge(a, b, 3));
                    a.AddEdge(new Edge(a, g1, 9 ));
                    b.AddEdge(new Edge(b, a, 2 ));
                    b.AddEdge(new Edge(b, c, 1 ));
                    c.AddEdge(new Edge(c, g2, 5 ));

                    c.AddEdge(new Edge(c, g2, 5 ));
                    c.AddEdge(new Edge(c, g2, 6 ));
                    c.AddEdge(new Edge(c, g2, 6 ));

                    c.AddEdge(new Edge(c, g2, 7 ));
                    c.AddEdge(new Edge(c, g2, 8 ));

                    c.AddEdge(new Edge(c, g2, 5 ));

                    c.AddEdge(new Edge(c, f, 7 ));
                    c.AddEdge(new Edge(c, s, 6 ));
                    d.AddEdge(new Edge(d, e, 2 ));
                    d.AddEdge(new Edge(d, c, 2 ));
                    d.AddEdge(new Edge(d, s, 1 ));
                    e.AddEdge(new Edge(e, g3, 7 ));
                    f.AddEdge(new Edge(f, g3, 8 ));
                    f.AddEdge(new Edge(f, d, 2 ));
                    s.AddEdge(new Edge(s, d, 6 ));
                    s.AddEdge(new Edge(s, b, 9 ));
                    s.AddEdge(new Edge(s, a, 5 ));
               



                var ASearcher = new AStarPathFinder.TreePathEvaluator
                 (
                     (IStarEdge edge) =>    edge.Weight
                );

            
                timer.Start();
                var path = ASearcher.TravelPath(s, g2);
                timer.Stop();

             

                Console.WriteLine($"Time elapsed {timer.ElapsedMilliseconds}");
                 

                if (path != null && path.Any())
                {
                    foreach (var item in path)
                    {
                        Console.WriteLine($"{item.TravelScore} =  {item}");
                    } 
                }
                else
                {
                    Console.WriteLine("!!!!!!!! NOT FOUND ");  
                }  

                 

                Console.ReadLine();
            }
        }

 



    }
}
