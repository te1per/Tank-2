namespace Tanki2._0
{
    internal partial class Program
    {
        class LevelLoader
        {
            private string[] field;

            public LevelLoader(int level)
            {
                field = new FileStorer($"../../Levels/{level}.txt").Result;
            }

            public void LoadField(out Field cellField, out Player player, out CharacterCollection enemies)
            {
                cellField = new Field(field[0].Length, field.Length);
                enemies = new CharacterCollection();
                player = new Player(0, 0);
                for (int y = 0; y < field.Length; y++)
                {
                    for (int x = 0; x < field[y].Length; x++)
                    {
                        switch (field[y][x])
                        {
                            case '#':
                                cellField[x, y] = new Wall();
                                break;
                            case ' ':
                                cellField[x, y] = new Empty();
                                break;
                            case 'E':
                                enemies.Add(new Enemy(x, y));
                                goto case ' ';
                            case 'P':
                                player = new Player(x, y);
                                goto case ' ';
                            default:
                                cellField[x, y] = new DestroyedObject();
                                break;
                        }
                    }
                }
            }
        }

    }
}