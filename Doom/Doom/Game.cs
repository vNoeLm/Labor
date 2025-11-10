using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Doom
{
    internal class Game
    {
        public enum SoundEffectType { BFG, Door, ItemPickup, Pain, PlayerDeath, Shotgun, LevelComplete }
        public Player Player { get; set; }
        public bool Exited { get; set; }

        public List<GameItem> Items { get; set; }
        public List<Demon> Demons { get; set; }

        public ConsoleRenderer Renderer { get; set; }
        public GameLogic Logic { get; set; }

        public Stopwatch StopWatchLogic { get; set; }
        public Stopwatch StopWatchRenderer { get; set; }

        public WindowsMediaPlayer MusicPlayer { get; set; }
        public WindowsMediaPlayer SfxPlayer { get; set; }

        public Game()
        {
            this.Player = new Player(0, 0, this);
            this.Exited = false;
            this.Items = new List<GameItem>();
            this.Demons = new List<Demon>();
            this.Renderer = new ConsoleRenderer(this, Player);
            this.Logic = new GameLogic(this);
            this.StopWatchLogic = new Stopwatch();
            this.StopWatchRenderer = new Stopwatch();
            this.MusicPlayer = new WindowsMediaPlayer();
            this.SfxPlayer = new WindowsMediaPlayer();
            PlayBackgroundMusic("sounds/doom_music.mp3");
        }

        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int newX = this.Player.Pos.PosX;
                int newY = this.Player.Pos.PosY;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        this.Exited = true;
                        break;
                    case ConsoleKey.W:
                        newY -= 1;
                        break;
                    case ConsoleKey.S:
                        newY += 1;
                        break;
                    case ConsoleKey.A:
                        newX -= 1;
                        break;
                    case ConsoleKey.D:
                        newX += 1;
                        break;
                    case ConsoleKey.E:
                        Logic.PlayerDirectInteractionLogic(Player.Pos);
                        break;
                    case ConsoleKey.F:
                        Logic.PlayerAttackLogic();
                        break;
                    case ConsoleKey.G:
                        Logic.PlayerBFGAttackLogic();
                        break;
                }

                if (newX >= 0 && newX < Console.WindowWidth &&
                    newY >= 0 && newY < Console.WindowHeight - 1)
                {
                    Logic.Move(this.Player, new Position(newX, newY));
                    Logic.PlayerIndirectInteractionLogic(Player.Pos);
                }
            }
            
        }

        public void LoadMapFromPlainText(string AccessPath)
        {
            FileStream fileStream = new FileStream(AccessPath, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            int[] dim = reader.ReadLine().Split(',').Select(int.Parse).ToArray();

            int y = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    char symbol = line[i];
                    Position pos = new Position(i, y);
                    switch (symbol)
                    {
                        case 'A':
                            GameItem ammo = new GameItem(pos, ItemType.Ammo);
                            Items.Add(ammo);
                            break;
                        case 'B':
                            GameItem bf = new GameItem(pos, ItemType.BFGCell);
                            Items.Add(bf);
                            break;
                        case 'D':
                            GameItem door = new GameItem(pos, ItemType.Door);
                            Items.Add(door);
                            break;
                        case 'E':
                            GameItem levelExit = new GameItem(pos, ItemType.LevelExit);
                            Items.Add(levelExit);
                            break;
                        case 'M':
                            GameItem hp = new GameItem(pos, ItemType.Medkit);
                            Items.Add(hp);
                            break;
                        case 'T':
                            GameItem waste = new GameItem(pos, ItemType.ToxicWaste);
                            Items.Add(waste);
                            break;
                        case 'W':
                            GameItem wall = new GameItem(pos, ItemType.Wall);
                            Items.Add(wall);
                            break;
                        case 'z':
                            Demon demon = new Demon(i, y, DemonType.ZombieMan);
                            Demons.Add(demon);
                            break;
                        case 'i':
                            Demon imp = new Demon(i, y, DemonType.Imp);
                            Demons.Add(imp);
                            break;
                        case 'm':
                            Demon mancubus = new Demon(i, y, DemonType.Mancubus);
                            Demons.Add(mancubus);
                            break;
                        case 'p':
                            this.Player.Pos = new Position(i, y);
                            break;
                        case '_':
                            // empty space
                            break;
                    }
                }
                y++;
            }
            
            reader.Close();
            fileStream.Close();
        }



        public void PlaySoundEffect(SoundEffectType SoundType)
        {
            switch (SoundType)
            {
                case SoundEffectType.Door:
                    SfxPlayer.URL = "sounds/door.mp3";
                    break;
                case SoundEffectType.ItemPickup:
                    SfxPlayer.URL = "sounds/item_pickup.mp3";
                    break;
                case SoundEffectType.Pain:
                    SfxPlayer.URL = "sounds/pain.mp3";
                    break;
                case SoundEffectType.PlayerDeath:
                    SfxPlayer.URL = "sounds/player_death.mp3";
                    break;
                case SoundEffectType.Shotgun:
                    SfxPlayer.URL = "sounds/shotgun.mp3";
                    break;
                case SoundEffectType.BFG:
                    SfxPlayer.URL = "sounds/bfg.mp3";
                    break;
                case SoundEffectType.LevelComplete:
                    SfxPlayer.URL = "sounds/level_complete.mp3";
                    break;
            }
            SfxPlayer.controls.play();

        }

        public void PlayBackgroundMusic(string Path)
        {
            MusicPlayer.URL = Path;
            MusicPlayer.settings.setMode("loop", true);
            MusicPlayer.controls.play();
        }

        public void StopBackgroundMusic()
        {
            MusicPlayer.controls.stop();
        }

        public void Run()
        {
            while (!this.Exited && this.Player.Alive)
            {
                StopWatchLogic.Start();
                StopWatchRenderer.Start();
                if (StopWatchLogic.ElapsedMilliseconds > 250)
                {
                    Logic.UpdateGameState();
                    StopWatchLogic.Restart();
                }
                if (StopWatchRenderer.ElapsedMilliseconds > 25)
                {
                    Renderer.RenderGame();
                    Renderer.RenderUI();
                    UserAction();
                    StopWatchRenderer.Restart();
                }
            }
        }


    }
}   
