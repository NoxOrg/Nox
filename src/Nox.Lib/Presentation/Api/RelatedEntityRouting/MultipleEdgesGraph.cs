namespace Nox.Presentation.Api;

internal sealed class MultipleEdgesGraph<TNode, TEdge> where TNode : notnull
{
    private Dictionary<TNode, Dictionary<TNode, List<TEdge>>> _nodes { get; } = new();

    public bool TryAddNode(TNode node)
    {
        if (!_nodes.ContainsKey(node))
        {
            _nodes[node] = new Dictionary<TNode, List<TEdge>>();
            return true;
        }
        return false;
    }

    public void AddEdge(TNode source, TNode destination, TEdge edge)
    {
        if (!_nodes[source].TryGetValue(destination, out List<TEdge>? edges))
        {
            edges = new List<TEdge>();
            _nodes[source][destination] = edges;
        }

        edges.Add(edge);
    }

    public IEnumerable<TEdge> GetEdges(TNode source, TNode destination)
    {
        if (_nodes.TryGetValue(source, out Dictionary<TNode, List<TEdge>>? nodeValue) &&
            nodeValue.TryGetValue(destination, out List<TEdge>? edges))
        {
            return edges;
        }

        return Array.Empty<TEdge>();
    }

    public bool TryGetNodeValue(TNode node, out Dictionary<TNode, List<TEdge>> value)
    {
        if(!_nodes.TryGetValue(node, out var nodeList))
        {
            value = new();
            return false;
        }

        value = nodeList;
        return true;
    }
}
