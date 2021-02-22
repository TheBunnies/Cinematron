namespace Cinematron.DAL.Contracts
{
    public interface IWatchable
    {
        int Id {get ;set;}
        string Title {get; set;}
        string Description {get; set;}
        string Duration {get; set;}
        string ThumbnailUrl {get; set;}
    }
}
