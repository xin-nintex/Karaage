using Karaage.Youtube.Client.Models;

namespace Karaage.Youtube.Client.Contracts;

public interface IYoutubeClient
{
    Task<VideoStats> GetVideoStatisticsByIdAsync(string id);
}