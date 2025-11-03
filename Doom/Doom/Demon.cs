using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    enum DemonType
    {
        Imp,
        ZombieMan,
        Mancubus
    }
    enum DemonStateType
    {
        Idle,
        Move,
        Attack
    }
    internal class Demon
    {
        public Position Pos { get; set; }
        public ConsoleSprite Sprite { get; set; }
        public DemonType Type { get; set; }
        public double FillinRatio { get; set; }
        private int _Health;
        public int Health
        {
            get { return _Health; }
            set
            {
                _Health = Math.Clamp(value, 0, 100);
            }
        }
        public bool Alive { get; set; }
        public int SightRange { get; set; }
        public int AttackRange { get; set; }
        public DemonStateType State { get; set; }

        public Demon(int PosX, int PosY, DemonType type)
        {
            this.Pos = new Position(PosX, PosY);
            this.Type = type;
            SetInitialProperties();
            this.Alive = true;
            this.State = DemonStateType.Idle;
        }

        private void SetInitialProperties()
        {
            switch (this.Type)
            {
                case DemonType.Imp:
                    this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.White, 'o');
                    this.FillinRatio = 0.4;
                    this.Health = 60;
                    this.SightRange = 6;
                    this.AttackRange = 3;
                    break;
                case DemonType.ZombieMan:
                    this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Red, 'o');
                    this.FillinRatio = 0.4;
                    this.Health = 20;
                    this.SightRange = 3;
                    this.AttackRange = 1;
                    break;
                case DemonType.Mancubus:
                    this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Magenta, 'O');
                    this.FillinRatio = 0.96;
                    this.Health = 600;
                    this.SightRange = 9;
                    this.AttackRange = 6;
                    break;
            }
        }

        public void UpdateState(Player player)
        {
            double distanceToPlayer = Position.Distance(this.Pos, player.Pos);
            if (distanceToPlayer <= this.AttackRange)
            {
                this.State = DemonStateType.Attack;
            }
            else if (distanceToPlayer <= this.SightRange)
            {
                this.State = DemonStateType.Move;
            }
            else
            {
                this.State = DemonStateType.Idle;
            }
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.Alive = false;
            }
        }
    }
}
