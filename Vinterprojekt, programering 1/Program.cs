using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);

string scene = "start";

Texture2D background = Raylib.LoadTexture(@"backgrund.png");

while (!Raylib.WindowShouldClose())
{
    if (scene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
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
        Raylib.DrawText("Press SPACE to start", 10, 10, 32, Color.BLACK);
    }


    Raylib.EndDrawing();

}
