
using System.Drawing;
using System.IO;

Console.Write("Select the folder path: ");
var path = Console.ReadLine();

Console.Write("How many times you want flip the images? ");
var rotation = int.Parse(Console.ReadLine());

if (Directory.Exists(path))
{
    string[] files = Directory.GetFiles(path, "*.jpg"); 
    string[] pngFiles = Directory.GetFiles(path, "*.png"); 
    string[] allFiles = new string[files.Length + pngFiles.Length];
    files.CopyTo(allFiles, 0);
    pngFiles.CopyTo(allFiles, files.Length);

    foreach (string file in allFiles)
    {
        RotacionarImagem(file, rotation);
    }

    Console.WriteLine("Rotation is done!");
}
else{
    Console.WriteLine("Invalid path.");
}
Console.ReadKey();

static void RotacionarImagem(string imagePath, int rotations)
{
    try
    {
        using (Image image = Image.FromFile(imagePath))
        {
            for (int i = 0; i < rotations; i++)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            image.Save(imagePath);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to rotate {imagePath}: {ex.Message}");
    }
}

