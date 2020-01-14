using AStarPathFinder;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstarAlgoritm.Models
{
    public class Edge : IStarEdge
    {
     

        public Edge(IStarNode from, IStarNode to, float weight)
        {
            Weight = weight;
            Source = from;
            Child = to;
        }

        public IStarNode Source { get; } 
        public IStarNode Child { get; }
        public float Weight { get; set; }
    }
}
