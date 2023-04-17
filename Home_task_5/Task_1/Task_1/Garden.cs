using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_1;

internal class Garden
{
    private readonly List<Tree> _trees;

    public Garden(List<Tree> trees)
    {
        _trees = trees;
    }

    public static int Orientation(Tree p, Tree q, Tree r)
    {
        int val = (q.Y - p.Y) * (r.X - q.X) -
                (q.X - p.X) * (r.Y - q.Y);

        if (val == 0) return 0; // collinear
        return (val > 0) ? 1 : 2; // clock or counterclock wise
    }

    public List<Tree> GardenConvexHull()
    {
        // There must be at least 3 points
        if (_trees.Count < 3) 
        {
            return Enumerable.Empty<Tree>().ToList();
        }

        // Initialize Result
        List<Tree> hull = new List<Tree>();

        // Find the leftmost point
        int leftmostX = 0;
        for (int i = 0; i < _trees.Count; i++)
        {
            if (_trees[i].X < _trees[leftmostX].X)
            {
                leftmostX = i;
            }
        }
        
        // Start from leftmost point, keep moving 
        // counterclockwise until reach the start point
        // again. This loop runs O(h) times where h is
        // number of points in result or output.
        int p = leftmostX, q;
        do
        {
            // Add current point to result
            hull.Add(_trees[p]);

            // Search for a point 'q' such that 
            // orientation(p, q, x) is counterclockwise 
            // for all points 'x'. The idea is to keep 
            // track of last visited most counterclock-
            // wise point in q. If any point 'i' is more 
            // counterclock-wise than q, then update q.
            q = (p + 1) % _trees.Count;

            for (int i = 0; i < _trees.Count; i++)
            {
                // If i is more counterclockwise than 
                // current q, then update q
                if (Orientation(_trees[p], _trees[i], _trees[q])
                                                    == 2)
                    q = i;
            }

            // Now q is the most counterclockwise with
            // respect to p. Set p as q for next iteration, 
            // so that q is added to result 'hull'
            p = q;

        } while (p != leftmostX); // While we don't come to first 
                                  // point
        return hull;
    }

    public static double TreeDistanse(Tree tree1, Tree tree2)
    {
        return Math.Sqrt(Math.Pow((tree1.X-tree2.X), 2) + Math.Pow((tree1.Y - tree2.Y), 2));
    }

    public double HullLength()
    {
        double perimetr = 0;
        var hull = GardenConvexHull();
        for (int i = 0; i < hull.Count; i++)
        {
            
            if(i == hull.Count -1)
            {
                perimetr += TreeDistanse(hull[i], hull[0]);
            }
            else
            {
                perimetr += TreeDistanse(hull[i], hull[i + 1]);
            }
        }
        return perimetr;    
    }
    public static bool operator !=(Garden garden1, Garden garden2) => !(garden1 == garden2);
    public static bool operator ==(Garden garden1, Garden garden2) => garden1.HullLength() == garden2.HullLength();
    public static bool operator <(Garden garden1, Garden garden2) => garden1.HullLength() < garden2.HullLength();
    public static bool operator >(Garden garden1, Garden garden2) => garden1.HullLength() > garden2.HullLength();
    public static bool operator >=(Garden garden1, Garden garden2) => garden1.HullLength() >= garden2.HullLength();
    public static bool operator <=(Garden garden1, Garden garden2) => garden1.HullLength() <= garden2.HullLength();
}
