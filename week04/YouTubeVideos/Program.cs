using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "How to Choose the Perfect Football Jersey",
            "Jersey Central",
            360);

        video1.AddComment(new Comment("Mukanya", "The quality of these jerseys looks really good."));
        video1.AddComment(new Comment("Marlon KO", "The price is actually reasonable for a good quality jersey."));
        video1.AddComment(new Comment("Magagu", "The new Barcelona home kit looks amazing. I definitely want one."));

        Video video2 = new Video(
            "The most entertaining match of Football",
            "Football World",
            240);

        video2.AddComment(new Comment("Oswald", "Carrick is not a good coach"));
        video2.AddComment(new Comment("Tanatswa", "Erling Haaland was offside."));
        video2.AddComment(new Comment("George", "Manchester is blue."));

        Video video3 = new Video(
            "How to Build a C# Program",
            "Luis Adam",
            450);

        video3.AddComment(new Comment("Grace", "Excellent tutorial."));
        video3.AddComment(new Comment("Amanda", "This helped with my assignment."));
        video3.AddComment(new Comment("Mariama", "Very clear explanation."));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}