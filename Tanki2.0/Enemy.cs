using System;
using System.Threading;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Enemy : Character
        {
            public Enemy(int x, int y) : base(x, y)
            {
                Lifes = 1;
            }

            public void Behavior(Field field, BulletCollection bullets)
            {
                Random rnd = new Random();
                Thread.Sleep(1);
                int doActions = rnd.Next(0, 2);
                if (doActions == 0)
                {
                    int doStep = rnd.Next(0, 2);
                    if (doStep == 0)
                    {
                        int stepDirection = rnd.Next(0, 4);
                        int dx = 0, dy = 0;
                        switch (stepDirection)
                        {
                            case 0:
                                dx--;
                                break;
                            case 1:
                                dy--;
                                break;
                            case 2:
                                dx++;
                                break;
                            case 3:
                                dy++;
                                break;
                        }
                        Rotate(dx, dy);
                        if(field.CanMakeStep(X + dx, Y + dy))
                            MakeStep(dx, dy);
                    }

                    int doShot = rnd.Next(0, 3);
                    if (doShot == 0)
                    {
                        bullets.Add(new Bullet(X, Y, direction, true));
                    }
                }
            }
        }
    }
}