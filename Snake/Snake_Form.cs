//Р: Полякова Юлия
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    internal partial class Snake_Form : Form
    {
        public readonly Controller _controller;

        public Snake_Form(Controller controller)
        {
            InitializeComponent();

            _ = new Direction();

            _controller = controller;
            _controller.Snake_Form = this;

            BackColor = Color.AliceBlue;
        }
    }
}