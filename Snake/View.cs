//Р: Полякова Юлия
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    internal class View
    {
        private readonly Model _model;
        private readonly PictureBox _pictureBox;
        private readonly Image _foodImage;

        public View(Model model, PictureBox picture)
        {
            _model = model;
            _pictureBox = picture;
            _pictureBox.Paint += UpdatePicture;
            _foodImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\apple.png");
        }

        public void UpdatePicture(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            DrawSnake(canvas, Direction.WidthSnake, Direction.HeightSnake);
            DrawFood(canvas, Direction.Width, Direction.Height);
        }

        private void DrawSnake(Graphics canvas, int width, int height)
        {
            for (int i = 0; i < _model.Snake.Count; i++)
            {
                Brush snakeColor = (i == 0) ? Brushes.ForestGreen : Brushes.LimeGreen;
                canvas.FillRectangle(snakeColor, new Rectangle(
                    _model.Snake[i].X * width,
                    _model.Snake[i].Y * height,
                    width,
                    height
                ));
            }
        }

        private void DrawFood(Graphics canvas, int width, int height)
        {
            canvas.DrawImage(_foodImage, new Rectangle(
                _model.Food.X * width,
                _model.Food.Y * height,
                width,
                height
            ));
        }
    }
}
