namespace Karaage.Youtube.Client.Models;

public record VideoStats(
    string Id, 
    ulong? CommentCount, 
    ulong? DislikeCount, 
    ulong? FavoriteCount, 
    ulong? ViewCount,
    ulong? LikeCount);