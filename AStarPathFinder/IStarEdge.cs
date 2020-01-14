using System;
using System.Collections.Generic;
using System.Text;

namespace AStarPathFinder
{

    public interface IStarEdge 
    {  
        IStarNode Source { get; }  
        IStarNode Child { get; } 
        
        float Weight { get; set; }


    }   



}
