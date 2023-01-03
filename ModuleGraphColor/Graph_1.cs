namespace ModuleGraphColor;

public struct Graph_1 {
    public Graph_1(int ID, int Rates, int[] Connect, int Color, bool Colored)
    {
        // trong cấu trúc có bao nhiêu trường dữ liệu, thuộc tính
        // phải khởi tạo hết trong hàm tạo (thiếu sẽ lỗi)
        vertex_id = ID;
        vertex_rates = Rates;
        connect = Connect;
        color = Color;
        colored = Colored;
    }

    public int vertex_id;
    public int vertex_rates;
    public int[] connect;
    public int color;
    public bool colored;
}