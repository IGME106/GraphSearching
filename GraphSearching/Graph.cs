﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Practice exercise 19
/// Class Description   : Actual graph
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : April 19, 2018
/// Filename            : Graph.cs
/// </summary>

namespace GraphSearching
{
    class Graph
    {
        public static Dictionary<string, Vertex> GraphDictionary { get; set; }
        public static List<Vertex> GraphList { get; set; }

        private int[,] adjMatrix = new int[26, 26]                                          // Create a pretty large adjacency matrix
            {   //A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
          /*A*/ { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*B*/ { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*C*/ { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*D*/ { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*E*/ { 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*F*/ { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*G*/ { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*H*/ { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*I*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*J*/ { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*K*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*L*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*M*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*N*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*O*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*P*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
          /*Q*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
          /*R*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
          /*S*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
          /*T*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
          /*U*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
          /*V*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
          /*W*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
          /*X*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 },
          /*Y*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
          /*Z*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }
            };

        /// <summary>
        /// Constructor
        /// </summary>
        public Graph()
        {
            GraphDictionary = new Dictionary<string, Vertex>();
            GraphList = new List<Vertex>();

            InstantiateVertexes();            
        }

        /// <summary>
        /// Create the vertices (this is pretty long)
        /// </summary>
        public void InstantiateVertexes()
        {
            Vertex vA = new Vertex("A");
            Vertex vB = new Vertex("B");
            Vertex vC = new Vertex("C");
            Vertex vD = new Vertex("D");
            Vertex vE = new Vertex("E");
            Vertex vF = new Vertex("F");
            Vertex vG = new Vertex("G");
            Vertex vH = new Vertex("H");
            Vertex vI = new Vertex("I");
            Vertex vJ = new Vertex("J");
            Vertex vK = new Vertex("K");
            Vertex vL = new Vertex("L");
            Vertex vM = new Vertex("M");
            Vertex vN = new Vertex("N");
            Vertex vO = new Vertex("O");
            Vertex vP = new Vertex("P");
            Vertex vQ = new Vertex("Q");
            Vertex vR = new Vertex("R");
            Vertex vS = new Vertex("S");
            Vertex vT = new Vertex("T");
            Vertex vU = new Vertex("U");
            Vertex vV = new Vertex("V");
            Vertex vW = new Vertex("W");
            Vertex vX = new Vertex("X");
            Vertex vY = new Vertex("Y");
            Vertex vZ = new Vertex("Z");

            GraphList.Add(vA);
            GraphDictionary.Add("A", vA);
            
            GraphList.Add(vB);
            GraphDictionary.Add("B", vB);

            GraphList.Add(vC);
            GraphDictionary.Add("C", vC);

            GraphList.Add(vD);
            GraphDictionary.Add("D", vD);

            GraphList.Add(vE);
            GraphDictionary.Add("E", vE);

            GraphList.Add(vF);
            GraphDictionary.Add("F", vF);

            GraphList.Add(vG);
            GraphDictionary.Add("G", vG);

            GraphList.Add(vH);
            GraphDictionary.Add("H", vH);

            GraphList.Add(vI);
            GraphDictionary.Add("I", vI);

            GraphList.Add(vJ);
            GraphDictionary.Add("J", vJ);

            GraphList.Add(vK);
            GraphDictionary.Add("K", vK);

            GraphList.Add(vL);
            GraphDictionary.Add("L", vL);

            GraphList.Add(vM);
            GraphDictionary.Add("M", vM);

            GraphList.Add(vN);
            GraphDictionary.Add("N", vN);

            GraphList.Add(vO);
            GraphDictionary.Add("O", vO);

            GraphList.Add(vP);
            GraphDictionary.Add("P", vP);

            GraphList.Add(vQ);
            GraphDictionary.Add("Q", vQ);

            GraphList.Add(vR);
            GraphDictionary.Add("R", vR);

            GraphList.Add(vS);
            GraphDictionary.Add("S", vS);

            GraphList.Add(vT);
            GraphDictionary.Add("T", vT);

            GraphList.Add(vU);
            GraphDictionary.Add("U", vU);

            GraphList.Add(vV);
            GraphDictionary.Add("V", vV);

            GraphList.Add(vW);
            GraphDictionary.Add("W", vW);

            GraphList.Add(vX);
            GraphDictionary.Add("X", vX);

            GraphList.Add(vY);
            GraphDictionary.Add("Y", vY);

            GraphList.Add(vZ);
            GraphDictionary.Add("Z", vZ);
        }

        /// <summary>
        /// Reset the search tree
        /// </summary>
        public void Reset()
        {
            foreach (Vertex vertex in GraphList)
            {
                vertex.Visited = false;
            }
        }
        
        /// <summary>
        /// Return the name (key) of the next unvisited vertex
        /// </summary>
        /// <param name="name">Name/Key of the Dictionary item to look for</param>
        /// <returns>Vertex of the next, previously unvisited vertex</returns>
        public Vertex GetAdjacentUnvisited(String name)
        {
            bool foundVisited = false;
            int indexOfVertexInList = 0;
            int incrementor = 0;
            Vertex returnValue = null;

            if (GraphDictionary.ContainsKey(name))                                          // Test if the key exists in the dictionary
            {
                indexOfVertexInList = GraphList.IndexOf(GraphDictionary[name]);             // Get the index of the vertex

                do                                                                          // Loop through vertices until one is found that
                {                                                                           // wasn't found before
                    if ((adjMatrix[indexOfVertexInList, incrementor] == 1) && (!GraphList[incrementor].Visited))
                    {
                        returnValue = GraphList[incrementor];                               // Return the next vertex
                        GraphList[incrementor].Visited = true;                              // Set it's "visited" property to true
                        foundVisited = true;                                                // Set the "found" variable to true to break the loop
                    }

                    incrementor++;                                                          // do/while incrementor

                } while ((!foundVisited) && (incrementor < adjMatrix.GetLength(1)));        // Once we find a vertex, or get to the end of the matrix, break
            }

            return returnValue;
        }

        /// <summary>
        /// Search for the next available vertex using DFS
        /// </summary>
        /// <param name="name">Name/Key of the Dictionary item to look for</param>
        public void DepthFirst(string name)
        {
            Stack<Vertex> graphStack = new Stack<Vertex>();
            Vertex tempVertex = null;

            Reset();                                                                        // Reset the "visited property of the vertexes"

            try
            {
                Console.WriteLine(name);

                graphStack.Push(GraphDictionary[name]);                                     // Print, and push the name provided
                GraphDictionary[name].Visited = true;

                do                                                                          // Continue the loop until all elements have been removed form the stack
                {
                    tempVertex = GetAdjacentUnvisited(graphStack.Peek().Name);              // Get the next unvisited vertex

                    if (tempVertex != null)
                    {
                        Console.WriteLine(tempVertex.Name);                                 // If the vertex is not null, print it and add to stack
                        graphStack.Push(tempVertex);
                    }
                    else
                    {
                        graphStack.Pop();                                                   // If the vertex has no further adjacencies, remove it from the stack
                    }

                    tempVertex = null;


                } while (graphStack.Count != 0);                                            // Continue the loop until all elements have been removed from the stack
            }
            catch (Exception DepthFirstException)                                           // Catch possible exceptions
            {
                if ((DepthFirstException is KeyNotFoundException) ||
                    (DepthFirstException is IndexOutOfRangeException))
                {
                    throw new IndexOutOfRangeException("The specified index does not exist");
                }
            }            
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
