using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    internal class GameLogic
    {
        Random RNG = new Random();
        public Game Game { get; set; }

        public GameLogic(Game Game)
        {
            this.Game = Game;
        }
        private void UpdateDemons()
        {
            foreach (var demon in this.Game.Demons)
            {
                demon.UpdateState(this.Game.Player);
                if (demon.State == DemonStateType.Move)
                {
                    DemonMoveLogic(demon);
                }
                if (demon.State == DemonStateType.Attack)
                {
                    DemonAttackLogic(demon);
                }
                DemonIndirectInteractionLogic(demon);
            }
        }
        public void PlayerAttackLogic()
        {
            if (this.Game.Player.Ammo > 0)
            {
                List<Demon> nearbyDemons = GetDemonsWithinDistance(this.Game.Player.Pos, this.Game.Player.SightRange);
                foreach (var demon in nearbyDemons)
                {
                    double dist = Position.Distance(this.Game.Player.Pos, demon.Pos);
                    int DUD = RNG.Next(35, 106);
                    int dmg = (2 * DUD) / (1 + (int)dist);
                    demon.TakeDamage(dmg);
                    this.Game.Player.Shoot();
                    if (!demon.Alive)
                    {
                        switch (demon.Type)
                        {
                            case DemonType.Imp:
                                this.Game.Player.AddCombatPoints(3);
                                break;
                            case DemonType.ZombieMan:
                                this.Game.Player.AddCombatPoints(1);
                                break;
                            case DemonType.Mancubus:
                                this.Game.Player.AddCombatPoints(10);
                                break;
                        }
                    }
                }
            }
        }

        public void PlayerBFGAttackLogic()
        {
            if (this.Game.Player.BfgCell > 0)
            {
                List<Demon> nearbyDemons = GetDemonsWithinDistance(this.Game.Player.Pos, this.Game.Player.SightRange);
                foreach (var demon in nearbyDemons)
                {
                    double dist = Position.Distance(this.Game.Player.Pos, demon.Pos);
                    int DUD = RNG.Next(100, 801);
                    int dmg = (3 * DUD) / (1 + (int)dist);
                    demon.TakeDamage(dmg);
                    this.Game.Player.ShootBFG();
                    if (!demon.Alive)
                    {
                        switch (demon.Type)
                        {
                            case DemonType.Imp:
                                this.Game.Player.AddCombatPoints(3);
                                break;
                            case DemonType.ZombieMan:
                                this.Game.Player.AddCombatPoints(1);
                                break;
                            case DemonType.Mancubus:
                                this.Game.Player.AddCombatPoints(10);
                                break;
                        }
                    }
                }
            }
        }
        public void Move(Player player, Position MoveToPos)
        {
            double totalFillingRatio = GetTotalFillingRatio(MoveToPos);
            if (totalFillingRatio + player.FillingRatio <= 1.0)
            {
                player.Pos = MoveToPos;
            }
        }

        public void Move(Demon demon, Position MoveToPos)
        {
            double totalFillingRatio = GetTotalFillingRatio(MoveToPos);
            if (totalFillingRatio + demon.FillinRatio <= 1.0)
            {
                demon.Pos = MoveToPos;
            }
        }
        private double GetTotalFillingRatio(Position Pos)
        {
            List<GameItem> items = GetGameItemsWithinDistance(Pos, 0.0);
            List<Demon> demons = GetDemonsWithinDistance(Pos, 0.0);
            double totalFillingRatio = 0.0;
            foreach (var item in items)
            {
                totalFillingRatio += item.FillingRation;
            }
            foreach (var demon in demons)
            {
                totalFillingRatio += demon.FillinRatio;
            }
            return totalFillingRatio;
        }
        private List<Demon> GetDemonsWithinDistance(Position Pos, double distance)
        {
            List<Demon> nearbyDemons = new List<Demon>();
            foreach (var demon in this.Game.Demons)
            {
                double dist = Position.Distance(Pos, demon.Pos);
                if (dist <= distance)
                {
                    nearbyDemons.Add(demon);
                }
            }
            return nearbyDemons;
        }
        public List<GameItem> GetGameItemsWithinDistance(Position Pos, double distance)
        {
            List<GameItem> nearbyItems = new List<GameItem>();
            foreach (var item in this.Game.Items)
            {
                double dist = Position.Distance(Pos, item.ItemPos);
                if (dist <= distance)
                {
                    nearbyItems.Add(item);
                }
            }

            return nearbyItems;
        }
        private void DemonAttackLogic(Demon demon)
        {
            double dist = Position.Distance(this.Game.Player.Pos, demon.Pos);
            if (dist <= demon.AttackRange)
            {
                int DUD = 0;
                switch (demon.Type)
                {
                    case DemonType.Imp:
                        DUD = RNG.Next(3, 25);
                        break;
                    case DemonType.ZombieMan:
                        DUD = RNG.Next(3, 15);
                        break;
                    case DemonType.Mancubus:
                        DUD = RNG.Next(8, 64);
                        break;
                }
                this.Game.Player.TakeDamage(DUD);
            }
        }
        private void DemonMoveLogic(Demon demon)
        {
            bool validMove = false;
            Position targetPosition = demon.Pos;

            int PosX = 0;
            int PosY = 0;

            for (int attempts = 0; attempts < 3 && !validMove; attempts++)
            {
                PosX = demon.Pos.PosX + RNG.Next(-1, 2);
                PosY = demon.Pos.PosY + RNG.Next(-1, 2);

                if (PosX >= 0 && PosX < Console.WindowWidth &&
                    PosY >= 0 && PosY < Console.WindowHeight - 1)
                {
                    targetPosition = new Position(PosX, PosY);
                    validMove = true;
                }
            }

            if (validMove)
            {
                if (PosX != demon.Pos.PosX && PosY != demon.Pos.PosY)
                {
                    Position horizontalPos = new Position(PosX, demon.Pos.PosY);
                    double horizontalRatio = GetTotalFillingRatio(horizontalPos);

                    Position verticalPos = new Position(demon.Pos.PosX, PosY);
                    double verticalRatio = GetTotalFillingRatio(verticalPos);

                    if (horizontalRatio + demon.FillinRatio <= 1.0 ||
                        verticalRatio + demon.FillinRatio <= 1.0)
                    {
                        Move(demon, targetPosition);
                    }
                }
                else
                {
                    Move(demon, targetPosition);
                }
            }
        }
        private void CleanUpDemons()
        {
            List<Demon> demonsToRemove = new List<Demon>();
            foreach (var demon in this.Game.Demons)
            {
                if (!demon.Alive)
                {
                    demonsToRemove.Add(demon);
                }
            }
            foreach (var demon in demonsToRemove)
            {
                this.Game.Demons.Remove(demon);
            }
        }
        private void CleanUpGameItems()
        {
            List<GameItem> itemsToRemove = new List<GameItem>();
            foreach (var item in this.Game.Items)
            {
                if (!item.Avalaible)
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (var item in itemsToRemove)
            {
                this.Game.Items.Remove(item);
            }
        }

        public void PlayerDirectInteractionLogic(Position PlayerPos)
        {
            List<GameItem> items = GetGameItemsWithinDistance(PlayerPos, 1.0);
            Stopwatch sw = new Stopwatch();
            foreach (var item in items)
            {
                switch (item.Type)
                {
                    case ItemType.Door:
                        Interact(item);
                        Game.PlaySoundEffect(Game.SoundEffectType.Door);
                        break;
                    case ItemType.LevelExit:
                        Game.StopBackgroundMusic();
                        Game.PlaySoundEffect(Game.SoundEffectType.LevelComplete);
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(16);
                        }
                        Interact(item);
                        break;
                }
            }
        }

        public void Interact( GameItem item)
        {
            switch (item.Type)
            {
                case ItemType.Door:
                    if (item.FillingRation == 1.0)
                    {
                        item.FillingRation = 0.0;
                        item.ItemSprite.ForeGround = ConsoleColor.DarkYellow;
                        item.ItemSprite.Symbol = '|';
                    }
                    else
                    {
                        item.SetInitialProperties();
                    }
                    break;
                case ItemType.LevelExit:
                    Game.Exited = true;
                    break;
            }
        }

        public void PlayerIndirectInteractionLogic(Position PlayerPos)
        {
            List<GameItem> items = GetGameItemsWithinDistance(PlayerPos, 0.0);
            foreach (var item in items)
            {
                switch (item.Type)
                {
                    case ItemType.Ammo:
                        Game.Player.PickUpAmmo();
                        item.Avalaible = false;
                        break;
                    case ItemType.Medkit:
                        Game.Player.PickUpHealth();
                        item.Avalaible = false;
                        break;
                    case ItemType.BFGCell:
                        Game.Player.PickUpBFGCell();
                        item.Avalaible = false;
                        break;
                    case ItemType.ToxicWaste:
                        Game.Player.TakeDamage(5);
                        break;
                }
            }
        }

        public void DemonIndirectInteractionLogic(Demon demon)
        {
            List<GameItem> items = GetGameItemsWithinDistance(demon.Pos, 0.0);
            foreach (var item in items)
            {
                if (item.Type == ItemType.ToxicWaste)
                {
                    demon.TakeDamage(5);
                }
            }
        }

        public void UpdateGameState()
        {
            UpdateDemons();
            CleanUpGameItems();
            CleanUpDemons();
        }
    }
}
