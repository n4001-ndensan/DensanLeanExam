using BlazorApp3.Domain.Value;

namespace BlazorApp3.Domain.Model;

/// <summary>
/// タスク情報
/// </summary>
public class MyTask : IEquatable<MyTask>, IComparable<MyTask>
{
    /// <summary>
    /// 題名
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// 期限（日付）
    /// </summary>
    public DateOnly Deadline { get; set; }

    /// <summary>
    /// 状態（0.未着手、1.仕掛中、2.完了、9.無視）
    /// </summary>
    public MyTaskStatus Status { get; set; }

    /// <summary>
    /// 内容（改行あり文字列）
    /// </summary>
    public string Content { get; set; } = "";

    /// <summary>
    /// 大小比較
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(MyTask? other)
    {
        int res = Status.CompareTo(other?.Status);
        if (res != 0) return res;
        return Deadline.CompareTo(other?.Deadline);
    }

    /// <summary>
    /// 同一性比較
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(MyTask? other)
    {
        return other != null &&
               Title == other.Title &&
               Deadline == other.Deadline &&
               Status == other.Status &&
               Content == other.Content;
    }
}
