namespace Nox.Presentation.Api;

internal class MultipleEdgesGraph<TNode, TEdge> where TNode : notnull
{
    public Dictionary<TNode, Dictionary<TNode, List<TEdge>>> Edges { get; } = new();

    public void AddNode(TNode node)
    {
        if (!Edges.ContainsKey(node))
        {
            Edges[node] = new Dictionary<TNode, List<TEdge>>();
        }
    }

    public void AddEdge(TNode source, TNode destination, TEdge edge)
    {
        if (!Edges.ContainsKey(source))
        {
            AddNode(source);
        }

        if (!Edges.ContainsKey(destination))
        {
            AddNode(destination);
        }

        if (!Edges[source].ContainsKey(destination))
        {
            Edges[source][destination] = new List<TEdge>();
        }

        Edges[source][destination].Add(edge);
    }

    public IEnumerable<TEdge> GetEdges(TNode source, TNode destination)
    {
        if (Edges.ContainsKey(source) && Edges[source].ContainsKey(destination))
        {
            return Edges[source][destination];
        }

        return Array.Empty<TEdge>();
    }    
}
