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
        public bool Alive { get; set; }
        public int CombatPoints { get; set; }

        public Game Game { get; set; }

        private int _MaxHealth = 100;
        public int MaxHealt { 
            get { return _MaxHealth; }
            set 
            {
                _MaxHealth = 100 + (CombatPoints / 10);
            }
        }
        private int _BfgCell;
        public int BfgCell
        {
            get { return _BfgCell; }
            set { _BfgCell = Math.Clamp(value, 0, _MaxBfgCell); } 
        }

        public int _MaxBfgCell = 3;
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

        public Player(int PosX, int PosY, Game Game)
        {
            this.Pos = new Position(PosX, PosY);
            this.Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            this.FillingRatio = 0.4;
            this.Alive = true;
            this.HitPoint = 100;
            this.SightRange = 8;
            this.Ammo = 5;
            this.CombatPoints = 0;  
            this.BfgCell = 0; 
            this.Game = Game;
        }

        public void Shoot()
        {
            if (this.Ammo > 0)
            {
                this.Ammo -= 1;
                Game.PlaySoundEffect(Game.SoundEffectType.Shotgun);
            }
        }

        public void ShootBFG()
        {
            if (this.BfgCell > 0)
            {
                this.BfgCell -= 1;
                Game.PlaySoundEffect(Game.SoundEffectType.BFG);
            }
        }

        public void AddCombatPoints(int CombatPoint)
        {
            this.CombatPoints += CombatPoint;
        }

        public void TakeDamage(int damage)
        {
            this.HitPoint -= damage;
            Game.PlaySoundEffect(Game.SoundEffectType.Pain);
            if (this.HitPoint <= 0)
            {
                Game.PlaySoundEffect(Game.SoundEffectType.PlayerDeath);
                Thread.Sleep(1000);
                this.Alive = false;
            }
        }   

        public void PickUpAmmo()
        {
            this.Ammo += 5;
            Game.PlaySoundEffect(Game.SoundEffectType.ItemPickup);
        }

        public void PickUpHealth()
        {
            this.HitPoint += 10;
            Game.PlaySoundEffect(Game.SoundEffectType.ItemPickup);
        }

        public void PickUpBFGCell()
        {
            this.BfgCell += 1;
            Game.PlaySoundEffect(Game.SoundEffectType.ItemPickup);
        }
    }
}
