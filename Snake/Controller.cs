using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    internal class Controller
    {
        public Snake_Form Snake_Form { get; set; }
        public View View { get; set; }
        public Model Model { get; set; }

        public Timer _timer;

        public Controller()
        {
            Snake_Form = new Snake_Form(this)
            {
                KeyPreview = true
            };

            Model = new Model();
            View = new View(Model, Snake_Form.picture);

            Snake_Form.KeyDown += new KeyEventHandler(StartGame);
            Snake_Form.KeyDown += new KeyEventHandler((sender, e) => KeyIsDown(e, Model, _timer));
            Snake_Form.KeyUp += new KeyEventHandler((sender, e) => KeyIsUp(e, Model));

            _timer = new Timer { Interval = 220 };
            _timer.Tick += new EventHandler((x, y) => GameTimerEvent(Model, Snake_Form.picture, View));
        }

        public void StartGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                NewGame();
            }
        }

        public void NewGame()
        {
            Model.IsPaused = false;
            Model.IsGameOver = false;
            Model.Width = Snake_Form.picture.Width / Direction.Width - 1;
            Model.Height = Snake_Form.picture.Height / Direction.Height - 1;

            Model.Snake.Clear();

            Model.Score = 0;
            Snake_Form.Score.Text = "Счет: " + Model.Score;

            Point head = new() { X = 1, Y = 1 };
            Model.Snake.Add(head);

            for (int i = 0; i < 1; i++)
            {
                Point body = new();
                Model.Snake.Add(body);
            }

            Model.PlaceFood();

            _timer.Start();
        }

        public void EatenApple()
        {
            Model.Score += 1;

            Snake_Form.Score.Text = "Счет: " + Model.Score;

            Point body = new()
            {
                X = Model.Snake[^1].X,
                Y = Model.Snake[^1].Y
            };

            Model.Snake.Add(body);

            Model.PlaceFood();
        }

        public void IsGameOver()
        {
            Model.IsGameOver = true;
            _timer.Stop();

            if (Model.Score > Model.BestScore)
            {
                Model.BestScore = Model.Score;
                Snake_Form.BestScore.Text = "Наилучший результат: " + Environment.NewLine + Model.BestScore;
                Snake_Form.BestScore.ForeColor = Color.Red;
                Snake_Form.BestScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        public void KeyIsDown(KeyEventArgs e, Model model, Timer timer)
        {
            if (e.KeyCode == Keys.A && Direction.directions != "right")
            {
                model.Left = true;
            }
            if (e.KeyCode == Keys.D && Direction.directions != "left")
            {
                model.Right = true;
            }
            if (e.KeyCode == Keys.W && Direction.directions != "down")
            {
                model.Up = true;
            }
            if (e.KeyCode == Keys.S && Direction.directions != "up")
            {
                model.Down = true;
            }
            if (e.KeyCode == Keys.U && Direction.directions != "down" && Direction.directions != "downright" && Direction.directions != "downleft")
            {
                Direction.directions = "upleft";
            }
            if (e.KeyCode == Keys.I && Direction.directions != "right" && Direction.directions != "upright" && Direction.directions != "downright")
            {
                Direction.directions = "downleft";
            }
            if (e.KeyCode == Keys.O && Direction.directions != "up" && Direction.directions != "upright" && Direction.directions != "upleft")
            {
                Direction.directions = "downright";
            }
            if (e.KeyCode == Keys.P && Direction.directions != "left" && Direction.directions != "upleft" && Direction.directions != "downleft")
            {
                Direction.directions = "upright";
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (!model.IsGameOver)
                {
                    if (model.IsPaused)
                    {
                        timer.Start();
                        model.IsPaused = false;
                    }
                    else
                    {
                        timer.Stop();
                        model.IsPaused = true;
                    }
                }
            }
        }

        public void KeyIsUp(KeyEventArgs e, Model model)
        {
            if (e.KeyCode == Keys.A)
            {
                model.Left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                model.Right = false;
            }
            if (e.KeyCode == Keys.W)
            {
                model.Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                model.Down = false;
            }
            if (e.KeyCode == Keys.U)
            {
                model.UpLeft = false;
            }
            if (e.KeyCode == Keys.I)
            {
                model.DownLeft = false;
            }
            if (e.KeyCode == Keys.O)
            {
                model.DownRight = false;
            }
            if (e.KeyCode == Keys.P)
            {
                model.UpRight = false;
            }
        }

        public void GameTimerEvent(Model model, PictureBox picture, View view)
        {
            UpdateDirection();
            if (model.IsOutOfBounds())
            {
                IsGameOver();
                Direction.directions = "right";
            }
            else
            {
                MoveSnake(model);

                if (model.Snake[0].X == model.Food.X && model.Snake[0].Y == model.Food.Y)
                {
                    EatenApple();
                }

                if (model.CheckSelfCollision())
                {
                    IsGameOver();
                }
            }
            picture.Invalidate();
        }

        private void UpdateDirection()
        {
            if (Model.Left)
            {
                Direction.directions = "left";
            }
            if (Model.Right)
            {
                Direction.directions = "right";
            }
            if (Model.Down)
            {
                Direction.directions = "down";
            }
            if (Model.Up)
            {
                Direction.directions = "up";
            }
            if (Model.UpLeft)
            {
                Direction.directions = "upleft";
            }
            if (Model.DownLeft)
            {
                Direction.directions = "downleft";
            }
            if (Model.DownRight)
            {
                Direction.directions = "downright";
            }
            if (Model.UpRight)
            {
                Direction.directions = "upright";
            }
        }

        private void MoveSnake(Model model)
        {
            for (int i = model.Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Direction.directions)
                    {
                        case "left":
                            model.Snake[i].X--;
                            break;
                        case "right":
                            model.Snake[i].X++;
                            break;
                        case "down":
                            model.Snake[i].Y++;
                            break;
                        case "up":
                            model.Snake[i].Y--;
                            break;
                        case "upleft":
                            model.Snake[i].X--;
                            model.Snake[i].Y--;
                            break;
                        case "downleft":
                            model.Snake[i].X--;
                            model.Snake[i].Y++;
                            break;
                        case "downright":
                            model.Snake[i].X++;
                            model.Snake[i].Y++;
                            break;
                        case "upright":
                            model.Snake[i].X++;
                            model.Snake[i].Y--;
                            break;
                    }

                    if (model.Snake[i].X < 0)
                    {
                        model.Snake[i].X = model.Width;
                    }
                    if (model.Snake[i].X > model.Width)
                    {
                        model.Snake[i].X = 0;
                    }
                    if (model.Snake[i].Y < 0)
                    {
                        model.Snake[i].Y = model.Height;
                    }
                    if (model.Snake[i].Y > model.Height)
                    {
                        model.Snake[i].Y = 0;
                    }
                }
                else
                {
                    model.Snake[i].X = model.Snake[i - 1].X;
                    model.Snake[i].Y = model.Snake[i - 1].Y;
                }
            }
        }
    }
}