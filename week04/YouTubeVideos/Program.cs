using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();
        Video video1 = new Video("My First Video", "Daniel Si", 300);
        video1.AddComment(new Comment("Miguel", "Chulada!"));
        video1.AddComment(new Comment("Luis", "Uff, hermoso!"));
        video1.AddComment(new Comment("Pepe", "Sigue sigue!"));
        videos.Add(video1);
        
        Video video2 = new Video("Cooking", "Tenney ", 900);
        video2.AddComment(new Comment("Freddy", "Perfecta receta!"));
        video2.AddComment(new Comment("Chile", "Es el mejor video que he visto!"));
        video2.AddComment(new Comment("Adrian", "Vamos por mas recetas"));
        video2.AddComment(new Comment("Fernando", "Perfecto, se me antojo una!"));
        videos.Add(video2);

        Video video3 = new Video("Construyendo con Daniel", "Daniel Rey", 400);
        video3.AddComment(new Comment("Silvia", "El mejor proyecto"));
        video3.AddComment(new Comment("Ruth", "Si exactamente como lo esperaba"));
        video3.AddComment(new Comment("Gabriel", "Si se puede amigo!"));
        videos.Add(video3);
        
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}