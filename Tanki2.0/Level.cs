using System;
using System.Runtime.Remoting.Activation;
using System.Threading;

namespace Tanki2._0
{
    internal partial class  Program 
    {
        class Level
        {
            private Field gameField;
            private Player player;
            private CharacterCollection enemies;
            private BulletCollection bullets;

            public Thread keyThread;
            public PressedKey key;

            public enum PressedKey
            {
                Left, Right, Up, Down, Fire, None
            }
            

            public bool Game;
            

            public Level(int level)
            {
                Console.CursorVisible = false;
                Game = true;
                StartThread();
                bullets = new BulletCollection();
                new LevelLoader(level).LoadField(out gameField, out player, out enemies);
            }

            public void PrintLevel()
            {
                gameField.Print();
                bullets.Print();
                player.Draw();
                LivesMessage();
            }

            public void UpdateField()
            {
                PlayerAction();
                PutCharactersOnField();
                ClearDestroyed();
                EnemiesActions();
                BulletsMove();
                Thread.Sleep(200);
            }

            private void PlayerAction()
            {
                int dx = 0, dy = 0;
                switch (key)
                {
                    case PressedKey.Up:
                        dy = -1;
                        break;
                    case PressedKey.Down:
                        dy = 1;
                        break;
                    case PressedKey.Left:
                        dx = -1;
                        break;
                    case PressedKey.Right:
                        dx = 1;
                        break;
                    case PressedKey.Fire:
                        bullets.Add(new Bullet(player.X, player.Y, player.CurrentDirection));
                        key = PressedKey.None;
                        break;
                }

                player.Rotate(dx, dy);
                if (gameField.CanMakeStep(player.X + dx, player.Y + dy))
                {
                    player.MakeStep(dx, dy);
                    key = PressedKey.None;
                }
            }

            private void PutCharactersOnField()
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    for (int x = 0; x < gameField.Width; x++)
                    {
                        if (!(gameField[x, y] is Wall) && 
                            !(gameField[x, y] is DestroyedObject))
                        {
                            gameField[x, y] = new Empty();
                        }
                    }
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    gameField[enemies[i].X, enemies[i].Y] = enemies[i];
                }

                gameField[player.X, player.Y] = player;
            }
            
            private void ClearDestroyed()
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    for (int x = 0; x < gameField.Width; x++)
                    {
                        if(gameField[x, y] is DestroyedObject)
                            gameField.MakeEmpty(x, y);
                    }
                }
            }

            private void EnemiesActions()
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    (enemies[i] as Enemy).Behavior(gameField, bullets);
                }
            }

            private void BulletsMove()
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    int dx = 0, dy = 0;
                    switch (bullets[i].CurrentDirection)
                    {
                        case Direction.Up:
                            dy--;
                            break;
                        case Direction.Down:
                            dy++;
                            break;
                        case Direction.Left:
                            dx--;
                            break;
                        case Direction.Right:
                            dx++;
                            break;
                    }
                    if(gameField.NotOutOfField(bullets[i].X + dx, bullets[i].Y + dy))
                        bullets[i].MakeStep();
                    else
                    {
                        bullets.Delete(i--);
                        continue;
                    }
                    int x = bullets[i].X;
                    int y = bullets[i].Y;

                    if (gameField[x, y] is Wall)
                    {
                        bullets.Delete(i--);
                        gameField.MakeDestroyed(x, y);
                    }
                    else if (gameField[x, y] is Player)
                    {
                        bullets.Delete(i--);
                        player.Lifes--;
                        if (player.Lifes == 0)
                        {
                            Lose();
                        }
                    }
                    else if (!bullets[i].EnemySource)
                    {
                        for (int j = 0; j < enemies.Count; j++)
                        {
                            if (enemies[j].X == x && enemies[j].Y == y)
                            {
                                enemies[j].Lifes--;
                                if (enemies[j].Lifes == 0)
                                {
                                    enemies.Delete(j);
                                    gameField.MakeDestroyed(x, y);
                                }

                                break;
                            }
                        }
                        if (enemies.Count == 0)
                        {
                            Win();
                        }
                    }
                }
            }

            private void Win()
            {
                Game = false;
                PrintLevel();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                ConsoleMessage(0, gameField.Height + 3, "You win! Congratulations!!");
            }

            private void Lose()
            {
                Game = false;
                PrintLevel();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleMessage(0, gameField.Height + 3, "You lose!! See you next time");
            }

            private void ConsoleMessage(int x, int y, string message)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(message);
            }

            private void LivesMessage()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleMessage(0, gameField.Height + 1, $"Lifes: {player.Lifes:00}");
            }

            private void StartThread()
            {
                key = PressedKey.None;
                keyThread = new Thread(KeysInput);
                keyThread.Start();
            }

            private void KeysInput()
            {
                while (Game)
                {
                    var currntKey = Console.ReadKey(true);
                    
                    switch (currntKey.Key)
                    {
                        case ConsoleKey.W:
                            key = PressedKey.Up;
                            break;
                        case ConsoleKey.A:
                            key = PressedKey.Left;
                            break;
                        case ConsoleKey.D:
                            key = PressedKey.Right;
                            break;
                        case ConsoleKey.S:
                            key = PressedKey.Down;
                            break;
                        case ConsoleKey.F:
                            key = PressedKey.Fire;
                            break;
                        default:
                            key = PressedKey.None;
                            break;
                    }
                }
            }
        }
    }
}