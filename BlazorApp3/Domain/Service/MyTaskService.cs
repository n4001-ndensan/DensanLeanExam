using BlazorApp3.Domain.Value;

namespace BlazorApp3.Domain.Service;

public class MyTaskService
{
    /// <summary>
    /// ステータス（数値）に対応するテキストを取得する
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public static string GetStatusText(MyTaskStatus status) => status switch
    {
        MyTaskStatus.未着手 => "未着手",
        MyTaskStatus.仕掛中 => "仕掛中",
        MyTaskStatus.完了 => "完了",
        MyTaskStatus.無視 => "無視",
        _ => ""
    };

    /// <summary>
    /// 文字列の1行目を返す
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string GetFirstLineContent(string content)
    {
        var firstLine = content.Split('\n')[0];
        return firstLine;
    }
}
