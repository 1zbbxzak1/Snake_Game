//Р: Полякова Юлия
namespace Snake
{
    class Direction
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static int WidthSnake { get; set; }
        public static int HeightSnake { get; set; }

        public static string directions;

        public Direction()
        {
            Width = 30;
            Height = 30;
            WidthSnake = 30;
            HeightSnake = 30;
            directions = "right";
        }
    }
}