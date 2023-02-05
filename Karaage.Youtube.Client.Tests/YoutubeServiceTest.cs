using Karaage.Youtube.Client.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace Karaage.Youtube.Client.Tests;

public class Tests
{
    private YoutubeClient? _subject;

    [SetUp]
    public void Setup()
    {
        var options = new Mock<IOptions<YoutubeClientOption>>();
        options.Setup(x => x.Value)
            .Returns(new YoutubeClientOption()
            {
                ApiKey = Environment.GetEnvironmentVariable("YOUTUBE_API_KEY", EnvironmentVariableTarget.Machine)!
            });
        _subject = new YoutubeClient(options.Object);
    }

    
    [Test]
    public async Task YoutubeService_Should_GetVideoById([Values("8EA71rLoY5s")]string id)
    {
        Assert.That(_subject, Is.Not.Null);
        var stats = await _subject?.GetVideoStatisticsByIdAsync(id)!;
        Assert.That(stats, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(stats.Id, Is.EqualTo(id));
            Assert.That(stats.ViewCount, Is.GreaterThan(0));
        });
    }
}