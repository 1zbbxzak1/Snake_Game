//Р: Полякова Юлия
using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Model
    {
        public List<Point> Snake { get; set; }
        public Point Food { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Score { get; set; }
        public int BestScore { get; set; }
        public bool IsPaused { get; set; }
        public bool IsGameOver { get; set; }
        private Random Random { get; set; }

        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Down { get; set; }
        public bool Up { get; set; }
        public bool UpLeft { get; set; }
        public bool DownLeft { get; set; }
        public bool DownRight { get; set; }
        public bool UpRight { get; set; }

        public Model()
        {
            Snake = new List<Point>();
            Food = new Point();
            Random = new Random();
        }

        public void PlaceFood()
        {
            do
            {
                Food = new Point { X = Random.Next(2, Width), Y = Random.Next(2, Height) };
            }
            while (IsFoodOnSnake()); // Проверка, находится ли яблоко на туловище змейки
        }

        private bool IsFoodOnSnake()
        {
            foreach (Point segment in Snake)
            {
                if (segment.X == Food.X && segment.Y == Food.Y)
                {
                    return true; // Яблоко находится на туловище змейки
                }
            }
            return false; // Яблоко не находится на туловище змейки
        }

        public bool CheckSelfCollision()
        {
            for (int j = 1; j < Snake.Count; j++)
            {
                if (Snake[0].X == Snake[j].X && Snake[0].Y == Snake[j].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOutOfBounds()
        {
            return Snake[0].X <= 0 || Snake[0].X >= Width || Snake[0].Y <= 0 || Snake[0].Y >= Height;
        }
    }
}
