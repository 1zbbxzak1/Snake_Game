//Р: Полякова Юлия
namespace Snake
{
    partial class Snake_Form
    {
        public System.Windows.Forms.PictureBox picture;
        public System.Windows.Forms.Label Score;
        public System.Windows.Forms.Label BestScore;
        public System.Windows.Forms.Label instructions;
        private System.ComponentModel.IContainer comp = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (comp != null))
            {
                comp.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comp = new System.ComponentModel.Container();
            this.picture = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.BestScore = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();

            this.picture.BackColor = System.Drawing.Color.White;
            this.picture.Location = new System.Drawing.Point(9, 9);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(790, 420);
            this.picture.TabIndex = 1;

            //Обычный счет съеденных яблок
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(620, 455);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(76, 15);
            this.Score.TabIndex = 2;
            this.Score.Text = "Счет: 0";
 
            //Лучший счет, когда проиграл
            this.BestScore.AutoSize = true;
            this.BestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestScore.Location = new System.Drawing.Point(565, 485);
            this.BestScore.Name = "BestScore";
            this.BestScore.Size = new System.Drawing.Size(130, 20);
            this.BestScore.TabIndex = 2;
            this.BestScore.Text = "Наилучший результат";

            //Инструкции к игре
            this.instructions.AutoSize = false;
            this.instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.Location = new System.Drawing.Point(9, 440);
            this.instructions.Name = "txtInstr";
            this.instructions.Size = new System.Drawing.Size(130, 300);
            this.instructions.Width = 500;
            this.instructions.Height = 200;
            this.instructions.TabIndex = 3;
            this.instructions.Text =
                "Нажмите Space, чтобы запустилась игра.\n\n" +
                "Управление:\n\n" +
                "кнопка W - змейка бежит вверх,\n" +
                "кнопка A - змейка бежит влево,\n" +
                "кнопка S - змейка бежит вниз,\n" +
                "кнопка D - змейка бежит вправо,\n" +
                "кнопка U - змейка бежит по диагонали влево вверх,\n" +
                "кнопка I - змейка бежит по диагонали влево вниз,\n" +
                "кнопка O - змейка бежит по диагонали вправо вниз,\n" +
                "кнопка P - змейка бежит по диагонали вправо вверх,\n" +
                "кнопка Esc - поставить игру на паузу/продолжить игру.";

            //Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 610);
            this.Controls.Add(this.BestScore);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.picture);
            this.Name = "Snake_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Устанавливаем позицию формы по центру экрана
            this.Text = "Snake Game upgraded";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}