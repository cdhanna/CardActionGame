using System.Collections.Generic;
using CardActionGame.Enemy;
using Microsoft.Xna.Framework;

namespace CardActionGame.Core;

public partial class World
{
    public List<EnemyEntity> enemies = new List<EnemyEntity>();

    public List<int> enemyIndexesToRemove = new List<int>();
    
    public EnemyEntity AddEnemy(EnemyEntity enemy)
    {
        enemy.eId = enemies.Count;
        enemies.Add(enemy);
        return enemy;
    }

    void UpdateEnemies(GameTime gt)
    {
        var plr = player;
        for (var i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            
            if (RectBounds.Intersects(ref plr.bounds, ref plr.transform, ref enemy.bounds, ref enemy.transform))
            {
                enemy.sprite.color = Color.Red;
                enemyIndexesToRemove.Add(i);
            }
            else
            {
                enemy.sprite.color = Color.Blue;
            }

            var toPlayer = player.transform.position - enemy.transform.position;
            var dir = toPlayer;
            dir.Y = 0;
            dir.Normalize();

            enemy.transform.position +=  .1f * Vector2.UnitX * dir.X * gt.ElapsedGameTime.Milliseconds;
            
            // enemy.transform.position += .1f * Vector2.UnitX * gt.ElapsedGameTime.Milliseconds;
            enemies[i] = enemy;
        }


        for (var i = enemyIndexesToRemove.Count - 1; i >= 0; i--)
        {
            enemies.RemoveAt(enemyIndexesToRemove[i]);
        }
        
        enemyIndexesToRemove.Clear();
        
    }

    void DrawEnemies()
    {
        spriteBatch.Begin();
        for (var i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];

            enemy.sprite.Draw(ref enemy.transform, spriteBatch);
        }
        spriteBatch.End();
    }
}