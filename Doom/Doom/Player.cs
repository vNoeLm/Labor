using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class Player
    {
        public Position Pos { get; set; }
        public ConsoleSprite Sprite { get; set; }
        public double FillingRatio { get; set; }
        public int BFGCells { get; set; } = 2;
        public bool Alive { get; set; }
        public int CombatPoints { get; set; }

        private int _MaxHealth = 100;
        public int MaxHealt { 
            get { return _MaxHealth; }
            set 
            {
                _MaxHealth = 100 + (CombatPoints / 10);
            }
        }

        private int _hitPoint;
        public int HitPoint
        {
            get { return _hitPoint; }
            set
            {
                _hitPoint = Math.Clamp(value, 0, _MaxHealth);
            }
        }

        private int _Ammo;
        public int Ammo
        {
            get { return _Ammo; }
            set
            {
                _Ammo = Math.Clamp(value, 0, _MaxAmmo);
            }
        }

        private int _MaxAmmo = 10;
        public int MaxAmmo
        {
            get { return _MaxAmmo; }
            set
            {
                _MaxAmmo = 10 + (CombatPoints / 50);
            }
        }

        public int SightRange { get; set; }

        public Player(int PosX, int PosY)
        {
            this.Pos = new Position(PosX, PosY);
            this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            this.FillingRatio = 0.4;
            this.Alive = true;
            this.HitPoint = 100;
            this.SightRange = 8;
            this.Ammo = 5;

        }

        public void Shoot()
        {
            if (this.Ammo > 0)
            {
                this.Ammo -= 1;
            }
        }

        public void AddCombatPoints(int CombaitPoint)
        {
            this.CombatPoints += CombaitPoint;
        }

        public void TakeDamage(int damage)
        {
            this.HitPoint -= damage;
            if (this.HitPoint <= 0)
            {
                this.Alive = false;
            }
        }   
    }
}
