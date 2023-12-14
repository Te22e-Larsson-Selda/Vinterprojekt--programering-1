using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);

Random generator = new Random();
int starX = generator.Next( 1, 800 );
int starY ++ = starY;

string scene = "start";
Vector2 movement = new Vector2(0,0);

Texture2D background = Raylib.LoadTexture(@"Vinterproject, backgrund.png");

Texture2D starImage = Raylib.LoadTexture("Stjärna.png");
Rectangle starRect = new Rectangle(100, 100, 32, 32);
starRect.Width = starImage.Width;
starRect.Height = starImage.Height;

List<Rectangle> star = new();
star.Add(new Rectangle(760, 460, 32, 32));

Texture2D characterImage = Raylib.LoadTexture("Måln.png");
Rectangle characterRect = new Rectangle(100, 100, 32, 32);
characterRect.Width = characterImage.Width;
characterRect.Height = characterImage.Height;

int points = 0;
float speed = 5;


while (!Raylib.WindowShouldClose()){
    // --------------------------------------------------------------------------
    // GAME LOGIC
    // --------------------------------------------------------------------------

    if (scene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }
    else if (scene == "game")
    {
        movement = Vector2.Zero;

        // kod här: läsa in knapptryck, ändra på movement
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            movement.X = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            movement.Y = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            movement.Y = 1;
        }
        
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * speed;
        }

        characterRect.X += movement.X;
        characterRect.Y += movement.Y;

         if (characterRect.X < 0 || characterRect.X > 800 - 100)
        {
            characterRect.X -= movement.X;
        }
        if (characterRect.Y < 0 || characterRect.Y > 600 - 42)
        {
            characterRect.Y -= movement.Y;
        }

        if (Raylib.CheckCollisionRecs(characterRect, starRect))
        {
            points++;

        }

        foreach (Rectangle wall in star)
        {
            if (Raylib.CheckCollisionRecs(characterRect, starRect))
            {
                starRect.X = starX;
                starRect.Y = 0;
            }
        }
    }
    // --------------------------------------------------------------------------
    // RENDERING
    // --------------------------------------------------------------------------
    Raylib.BeginDrawing();
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.SKYBLUE);
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);
        Raylib.DrawText("Press SPACE to start", 200, 275, 32, Color.BLACK);
    }
    else if (scene == "game")
    {
        Raylib.ClearBackground(Color.BLUE);
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);

        Raylib.DrawTexture(characterImage, (int)characterRect.X, (int)characterRect.Y, Color.LIGHTGRAY);
        Raylib.DrawTexture(starImage,(int)starRect.X, (int)starRect.Y, Color.WHITE);
        Raylib.DrawText($"Points: {points}", 10, 10, 32, Color.DARKBLUE);

    }

    Raylib.EndDrawing();
}
