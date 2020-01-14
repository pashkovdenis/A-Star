using AStarPathFinder;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstarAlgoritm.Models
{
    public class Node : IStarNode
    {
        private string _Data;
        private float _Weight;
        private List<IStarEdge> _Edges;

        public IList<IStarNode> PathToMe { get; set; }

        public Node(string data , float weight)
        {
            _Data = data;
            _Weight = weight;
            PathToMe = new List<IStarNode>(); 
            _Edges = new List<IStarEdge>();  
        } 
        public bool Equals(IStarNode other) => _Data == ((Node)other)._Data;

        public IList<IStarEdge> GetEdges() => _Edges;
         
        public void AddEdge(Edge e) => _Edges.Add(e); 
         
        public float GetWeight() => _Weight;

        public void SetWeight(float weight) => _Weight = weight;

        public int Depth { get; set; } 

        public float Heat { get; set; }
        private string BuildPath()
        {
            var builder = new StringBuilder();

            foreach (var node in PathToMe)
            {
                builder.AppendFormat("->{0}", ((Node)node)._Data);
            }

            return $"{_Data} -   {builder.ToString()}";
        }  
        public override string ToString()
        {
            return BuildPath();  
        }
        
        public int CompareTo(IStarNode other)
        {
            return TravelScore.CompareTo(other.TravelScore);
        } 
       
        public bool IsVisited { get; set; }
        public float Weight { get; set; }
        public float TravelScore { get; set; }
    }
}
