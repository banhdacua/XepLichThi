namespace ModuleGraphColor;

public class Graph
{
    private int vertex;
    public bool[,] graf;
    public Graph(int x)
    {
        this.vertex = x;
        this.graf = new bool[x, x];
        
    }

    public void addConnect(int v, int w)
    {
        graf[v, w] = true;
        graf[w, v] = true;
    }

    public void delConnect(int v, int w)
    {
        graf[v, w] = false;
        graf[w, v] = false;
    }

    
}