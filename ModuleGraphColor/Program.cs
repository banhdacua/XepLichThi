// See https://aka.ms/new-console-template for more information

using ModuleGraphColor;


int vertex = 10;
int colorNum = 10;
int[] colorArray = new int[colorNum];
char vertex_1st_name = 'A';
int counter = 1;
var vertexs = new List<Vertex>();
var result = new List<Vertex>();
bool problem = false;
int[] RateList = new int[vertex];
int[] colorList;
Graph graf = new Graph(vertex);
for (int i = 0; i < colorNum; i++)
{
    colorArray[i] = i;
}

void connect(Graph graf)
{
    for (int i = 0; i < vertex; i++)
    {
        for (int j = 0; j < vertex; j++)
        {
            graf.delConnect(i, j);
        }
    }
    // tao Graph
    graf.addConnect(0, 1);
    graf.addConnect(0, 2);
    graf.addConnect(0, 3);
    graf.addConnect(1, 2);
    graf.addConnect(2, 3);
    graf.addConnect(2, 4);
    graf.addConnect(3, 5);
    graf.addConnect(4, 5);
    graf.addConnect(4, 6);
    graf.addConnect(4, 8);
    graf.addConnect(5, 9);
    graf.addConnect(6, 7);
    graf.addConnect(7, 8);
    graf.addConnect(8, 9);
}
// tao ket noi

void colorIt(int vertex, Graph graf, List<Vertex> vertexs, int[] RateList, List<Vertex> result)
{
    connect(graf);
    //ket noi do thi
    for (int i = 0; i < vertex; i++)
    {
        RateList[i] = 0;
        for (int j = 0; j < vertex; j++)
        {
            
            if (graf.graf[i, j] == true)
            {
                RateList[i]++;
            }
        }
    }
    for (int i = 0; i < vertex; i++)
    {
        vertexs.Add(new Vertex(i,vertex_1st_name, RateList[i]));
        vertex_1st_name++;
    }
    
    do
    {
        int biggest=0;
        int temp_rate = 0;
        //int vertexs_num = vertexs.Count;
        
        //find biggest
        for (int i = 0; i < vertexs.Count; i++)
        {
            if (vertexs[i].colored == false)
            {
                vertexs[i].vertex_rate = RateList[i];
                if (temp_rate < vertexs[i].vertex_rate)
                {
                    temp_rate = vertexs[i].vertex_rate;
                    biggest = i;
                    
                }
            }
        }//
        
        vertexs[biggest].setColor(colorArray[counter]);
        Console.WriteLine($"Biggest: {biggest}");
        //sort list
        //sort list
        var temp_vertexs = new List<Vertex>();
        foreach (var VARIABLE in vertexs)
        {
            if(VARIABLE.colored == false)
                temp_vertexs.Add(VARIABLE);
        }
        temp_vertexs.Sort((x,y) =>
        {
            return y.vertex_rate.CompareTo(x.vertex_rate);
        });
        var ID = new List<int>(); // List các ID không kề với biggest
        
        var check = vertexs.Count;
        for (int i = 0; i < temp_vertexs.Count; i++)
        {
            
            try
            {
                if (graf.graf[biggest, temp_vertexs[i].vertex_id] == false && biggest != temp_vertexs[i].vertex_id && temp_vertexs[temp_vertexs[i].vertex_id].colored == false)
                {
                    ID.Add(temp_vertexs[i].vertex_id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return;
                
            }
        }
        vertexs[ID[0]].setColor(colorArray[counter]);

        // setColor cho các đỉnh không kề
        var max = ID[0];
        for(int i = 0; i< ID.Count;i++)
        {
            if (graf.graf[max, ID[i]] == false && max != ID[i] && vertexs[ID[i]].colored == false)
            {
                vertexs[ID[i]].setColor(colorArray[counter]);

                for(int j = 0; j < ID.Count;j++)
                {
                    if (graf.graf[ID[i], ID[j]] == true)
                    {
                        ID.RemoveAt(j);
                    }
                }
            }
            
        }
        
        for (int i = 0; i < vertexs.Count; i++)
        {
            if (vertexs[i].colored == true)
            {
                result.Add(vertexs[i]);
            }
        }
        counter++;
    }
    while (result.Count < vertexs.Count);
        
}


Graph g = new Graph(10);

colorIt(vertex, g, vertexs, RateList, result);

foreach (Vertex v in result)
{
    Console.WriteLine($"ID: {v.vertex_id} -- Name: {v.vertex_name} -- Rate: {v.vertex_rate} -- Colored: {v.colored} -- Color:{v.color}  ");
}

for (int i = 0; i < vertex; i++)
{
    for (int j = 0; j < vertex; j++)
    {
        Console.Write($"{Convert.ToInt32(g.graf[i,j])} ");
    }
    Console.WriteLine();
}
