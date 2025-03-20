using System.Runtime.InteropServices;

public class Network
{
    public List<Node> nodes = new List<Node>();

    private List<Node> visitedNodes = new List<Node>();

    public Network(int numNodes)
    {
        CreateElements(numNodes);
    }

    public void Connect(int num1, int num2)
    {
        Node n1 = GetNode(num1);
        Node n2 = GetNode(num2);

        if(num1 < 0 || GetNode(num1) == null || num2 < 0 || GetNode(num2) == null || num1 == num2)
            throw new Exception("Invalid element to connect. Must contain in elements range or be a positive integer.");

        n1.Connect(n2);
        n2.Connect(n1);
    }

    public void Diconnect(int num1, int num2)
    {
        Node n1 = GetNode(num1);
        Node n2 = GetNode(num2);

        if(num1 < 0 || GetNode(num1) == null || num2 < 0 || GetNode(num2) == null || num1 == num2)
            throw new Exception("Invalid element to disconnect. Must contain in elements range or be a positive integer.");

        n1.Disconnect(n2);
        n2.Disconnect(n1);
    }

    public bool Query(int num1, int num2)
    {
        if(num1 < 0 || GetNode(num1) == null || num2 < 0 || GetNode(num2) == null || num1 == num2)
            throw new Exception("Invalid element to query. Must contain in elements range or be a positive integer.");

        Node node = GetNode(num1);

        visitedNodes.Clear();

        return BFS(node, num2) > 0 ? true : false;
    }

    public int LevelConnection(int num1, int num2)
    {
        if(num1 < 0 || GetNode(num1) == null || num2 < 0 || GetNode(num2) == null || num1 == num2)
            throw new Exception("Invalid element to get level connection. Must contain in elements range or be a positive integer.");

        Node node = GetNode(num1);

        visitedNodes.Clear();

        return BFS(node, num2);
    }

    private void CreateElements(int numNodes)
    {
        if(numNodes <= 0) throw new Exception("Invalid number of elements to create a graph.");

        for(int i = 1; i <= numNodes; i++){
            Node e = new Node(i);
            nodes.Add(e);
        }
    }

    private Node GetNode(int nodeInfo)
    {
        foreach (Node n in nodes){
            if(nodeInfo == n.info){
                return n;
            }
        }
        return null;
    }

    private int BFS(Node pivot, int goal)
    {
        Queue<Node> queue = new Queue<Node>();
        int[] levels = new int[nodes.Count];
        Node? next = null;
        int levelCount = 0;

        queue.Enqueue(pivot);

        while(queue.Count > 0)
        {
            next = queue.Dequeue();

            foreach (Node n in next.connections)
            {
                if(!visitedNodes.Contains(n))
                {
                    visitedNodes.Add(n);
                    levelCount = levels[next.info - 1] + 1;
                    levels[n.info - 1] = levelCount;
                    queue.Enqueue(n);

                    if(n.info == goal)
                    {
                        return levelCount;
                    }
                }
            }
        }
        return 0;
    }
}

public class Node
{
    public int info;
    public List<Node> connections;

    public Node(int nodeInfo){
        info = nodeInfo;
        connections = new List<Node>();
    }

    public void Connect(Node n)
    {
        if(HasConnection(n))
            throw new Exception("You tried connect elements that already connected. Try another combination.");

        connections.Add(n);
    }

    public void Disconnect(Node n)
    {
        connections.Remove(n);
    }

    public bool HasConnection(Node n)
    {
        return connections.Contains(n);
    }

    public override string ToString()
    {
        return this.info.ToString();
    }
}