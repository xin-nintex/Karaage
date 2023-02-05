using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Karaage.Youtube.Client.Configuration;
using Karaage.Youtube.Client.Contracts;
using Karaage.Youtube.Client.Exceptions;
using Karaage.Youtube.Client.Models;
using Microsoft.Extensions.Options;

namespace Karaage.Youtube.Client;

public class YoutubeClient : IYoutubeClient
{
    private readonly YouTubeService _youTubeService;
    public YoutubeClient(IOptions<YoutubeClientOption> options)
    {
        _youTubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = options.Value.ApiKey,
            ApplicationName = nameof(YoutubeClient),
        });
    }

    public async Task<VideoStats> GetVideoStatisticsByIdAsync(string id)
    {
        var listRequest = _youTubeService.Videos.List("statistics");
        listRequest.Id = id;
        var videoListResponse = await listRequest.ExecuteAsync();
        var item = videoListResponse.Items.FirstOrDefault() ?? throw new YoutubeClientException();
        return new VideoStats
        (
            item.Id,
            item.Statistics.CommentCount,
            item.Statistics.DislikeCount,
            item.Statistics.FavoriteCount,
            item.Statistics.ViewCount,
            item.Statistics.LikeCount
        );
    }
}