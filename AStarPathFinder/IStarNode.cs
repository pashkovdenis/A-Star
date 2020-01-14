using System;
using System.Collections.Generic;
using System.Text;

namespace AStarPathFinder
{ 
    public  interface IStarNode: IEquatable<IStarNode>, IComparable<IStarNode> 
    { 
        IList<IStarEdge> GetEdges();

        float Weight { get; set; }

        float TravelScore { get; set; }

        IList<IStarNode> PathToMe { set; get; }

        bool IsVisited { get; set; }

        int Depth { get; set; }
    }

}
