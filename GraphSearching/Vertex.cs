﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice exercise 19
/// Class Description   : Graph Vertex
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : April 19, 2018
/// Filename            : Vertex.cs
/// </summary>

namespace GraphSearching
{
    class Vertex
    {
        public string Name { get; set; }
        public bool Visited { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the vertex to add</param>
        public Vertex (string name)
        {
            Name = name;
            Visited = false;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>Returns all the values in this class</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
