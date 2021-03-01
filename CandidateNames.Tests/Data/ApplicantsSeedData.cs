namespace CandidateNames.Tests.Data
{
    public class ApplicantsSeedData
    {
        public static string[] DirtyDeveloperCandidates => new[]
        {
            "Viki, Sharer",
            "Jule, Goldblatt",
            "Mao, Aldana",
            "Lorretta, Roman",
            "Rebecca",
            "Long ,,Pigford",
            "Gudrun&nbsp;&nbsp;  ,Caughman"
        };

        public static string[] DirtyTesterCandidates => new[]
        {
            "Jones, David",
            "Charles ,,John",
            "Susan",
            "Scarlet, Solis",
            "Matthews ,Meg"
        };

        public static string[] CleanCandidates => new[]
        {
            "Viki, Sharer",
            "Jule, Goldblatt",
            "Mao, Aldana",
            "Lorretta, Roman",
            "Jones, David",
            "Scarlet, Solis"
        };
    }
}
