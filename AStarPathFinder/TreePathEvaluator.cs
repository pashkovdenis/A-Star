using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace AStarPathFinder
{ 
    public class TreePathEvaluator
    { 
        public delegate float DistanceBetweenEvaluater(IStarEdge edge);
        
        private readonly DistanceBetweenEvaluater _distanceEvaluater;   

        private readonly HashSet<IStarNode> _searchSet;

        private readonly Func<IStarEdge, float, bool> _evaluateComparer;

        public TreePathEvaluator(DistanceBetweenEvaluater evaluator, Func<IStarEdge, float, bool> evExp = null)
        { 
            _distanceEvaluater = evaluator; 
            _searchSet = new HashSet<IStarNode>();
            _evaluateComparer = evExp;
            _evaluateComparer ??= (edge, traversalScore) => edge.Child.TravelScore > 0 && edge.Child.TravelScore <= traversalScore ; 
        }

        public IEnumerable<IStarNode> TravelPath(IStarNode start, IStarNode goal = null)
        {
            _searchSet.Add(start);
              
            while (_searchSet.Count(x=>!x.IsVisited) > 0)
            {
                var current = _searchSet.Where(x=>!x.IsVisited)
                        .OrderBy(o => o.TravelScore) 
                        .FirstOrDefault();
                 
                current.IsVisited = true;

                var edges = current.GetEdges().Where(e => e.Child.IsVisited == false);
                 
                foreach (var edge in edges)
                {
                    EvaluatePath(current, edge);
                }

                yield return current;

                if (goal != null && current == goal)
                   break;
            } 
        }
         
        private void EvaluatePath(IStarNode from, IStarEdge edges)
        {  
            var travelScore =  from.TravelScore + _distanceEvaluater(edges);

            if (_evaluateComparer(edges,travelScore))
                return;

            edges.Child.PathToMe = from.PathToMe.ToList();

            from.Depth = edges.Child.PathToMe.Count;

            if (!edges.Child.PathToMe.Contains(from))
            {
                edges.Child.PathToMe.Add(from);
            }

            edges.Child.TravelScore = travelScore;

            _searchSet.Add(edges.Child);
        }
         
    }
}
