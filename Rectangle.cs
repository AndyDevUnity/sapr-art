using System.Drawing;

public class Rectangle
{
    public Color Color { get; set; }
    public Point TopLeft { get; set; }
    public Point TopRight { get; set; }
    public Point BotLeft { get; set; }
    public Point BotRight { get; set; }

    public Rectangle(Color color, Point topLeft, Point topRight, Point botLeft, Point botRight)
    {
        Color = color;
        TopLeft = topLeft;
        TopRight = topRight;
        BotLeft = botLeft;
        BotRight = botRight;
    }
}