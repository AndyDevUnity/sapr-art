using System.Drawing;

class Program
{
    static void Main()
    {
        List<Color> validColors = new List<Color>
        {
            Color.Red,
            Color.Green,
        };

        Rectangle mainRectangle = new Rectangle(Color.Brown, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 });

        List<Rectangle> secondaryRectangles = new List<Rectangle>
        {
            new Rectangle(Color.Red, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
            new Rectangle(Color.Red, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
            new Rectangle(Color.Green, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
            new Rectangle(Color.Green, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
            new Rectangle(Color.Blue, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
            new Rectangle(Color.Blue, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }, new Point { X = 0, Y = 0 }),
        };

        var filteredRectangles = secondaryRectangles
            .Where(rectangle => validColors.Contains(rectangle.Color))
            .Where(rectangle => rectangle.BotLeft.X >= mainRectangle.BotLeft.X && rectangle.BotLeft.Y >= mainRectangle.BotLeft.Y)
            .Where(rectangle => rectangle.TopLeft.X <= mainRectangle.TopLeft.X && rectangle.TopLeft.Y <= mainRectangle.TopLeft.Y)
            .ToList();

        string programmEnd = "Программа завершила работу с результатом:";

        string mainRectangleInfo = $"Главный прямоугольник: Цвет:{mainRectangle.Color}\n" +
                                   $"{DateTime.Now:yyMMdd hh:mm:ss} Верхний левый угол: ({mainRectangle.TopLeft.X},{mainRectangle.TopLeft.Y})\n" +
                                   $"{DateTime.Now:yyMMdd hh:mm:ss} Верхний правый угол: ({mainRectangle.TopRight.X},{mainRectangle.TopRight.Y})\n" +
                                   $"{DateTime.Now:yyMMdd hh:mm:ss} Нижний левый угол: ({mainRectangle.BotLeft.X},{mainRectangle.BotLeft.Y})\n" +
                                   $"{DateTime.Now:yyMMdd hh:mm:ss} Нижний правый угол: ({mainRectangle.BotRight.X},{mainRectangle.BotRight.Y})\n";

        string secondaryRectangleHeader = "Прямоугольники, учитываемые в главном прямоугольнике:";

        Console.WriteLine(programmEnd);
        Console.WriteLine(mainRectangleInfo);
        Console.WriteLine(secondaryRectangleHeader);

        LogToFile(programmEnd);
        LogToFile(mainRectangleInfo);
        LogToFile(secondaryRectangleHeader);

        foreach (var rect in filteredRectangles)
        {
            string infoSecondaryRectangle = $"Цвет: {rect.Color}, Нижний левый угол: ({rect.BotLeft.X},{rect.BotLeft.Y}), Верхний левый угол: ({rect.TopLeft.X},{rect.TopLeft.Y})";
            Console.WriteLine(infoSecondaryRectangle);
            LogToFile(infoSecondaryRectangle);
        }

        LogToFile("----------------------------------------------------------------------------\n");
        Console.ReadLine();
        //DeleteLogFile();
    }

    private static void LogToFile(string message)
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(projectPath, "Log.txt");

        if (File.Exists(filePath))
        {
            File.AppendAllText(filePath, $"{DateTime.Now:yyMMdd hh:mm:ss} {message}\n");
        }
    }

    private static void DeleteLogFile()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(projectPath, "Log.txt");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}