Player player = new Player(15,40,'@');

Renderer renderer = new Renderer();
renderer.Draw(player.X, player.Y, player.Model);

class Player
{
    public char Model { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Player (int x, int y, char model)
    {
        X = x;
        Y = y;
        Model = model;
    }
}

class Renderer
{
    public void Draw(int x, int y, char model)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(x, y);
        Console.WriteLine(model);
    }
}