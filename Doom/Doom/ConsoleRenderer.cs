using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class ConsoleRenderer
    {

        public Game Game { get; set; }

        public ConsoleRenderer(Game Game)
        {
            this.Game = Game;
        }
        public void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            for (int i = 0; i < this.Game.Items.Count; i++)
            {
                RenderSingleSprite(this.Game.Items[i].ItemSprite, this.Game.Items[i].ItemPos);
            }
            for (int i = 0; i < this.Game.Demons.Count; i++)
            {
                RenderSingleSprite(this.Game.Demons[i].Sprite, this.Game.Demons[i].Pos);
            }
            RenderSingleSprite(this.Game.Player.Sprite, this.Game.Player.Pos);
        }

        private void RenderSingleSprite(ConsoleSprite sprite, Position pos)
        {
            if (pos.PosX < 0 ||
                pos.PosY < 0 ||
                pos.PosX >= Console.WindowWidth ||
                pos.PosY >= Console.WindowHeight)
            {
                return;
            }
            Console.BackgroundColor = sprite.Background;
            Console.ForegroundColor = sprite.ForeGround;
            Console.SetCursorPosition(pos.PosX, pos.PosY);
            Console.WriteLine(sprite.Symbol);
        }
    }
}
