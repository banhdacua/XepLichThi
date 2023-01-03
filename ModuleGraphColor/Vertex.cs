namespace ModuleGraphColor;

public class Vertex
{
    public int vertex_id;
    public char vertex_name;
    public int vertex_rate;
    public int color = 0;
    public bool colored = false;

    public Vertex(int Id, char Name, int Rate)
    {
        this.vertex_id = Id;
        this.vertex_name = Name;
        this.vertex_rate = Rate;
    }

    public void setColor(int Color)
    {
        this.color = Color;
        this.colored = true;
    }
}