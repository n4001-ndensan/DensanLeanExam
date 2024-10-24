using BlazorApp3.Domain.Model;
using BlazorApp3.Domain.Value;
using BlazorApp3.Application.Value;

namespace BlazorApp3.Components.Pages;

public partial class MyTaskEdit
{
    private readonly MyTask myTask = new();
    private readonly List<MyTaskStatus> myTaskStatusList = Enum.GetValues<MyTaskStatus>().ToList();

    protected override void OnInitialized()
    {
        // セッションにタスク一覧がない場合は、不正な遷移のため、一覧画面に戻る
        if (!sessionState.HasState)
        {
            NavigationManager.NavigateTo(PageUrl.MYTASK_LIST);
        }
    }

    /// <summary>
    /// キャンセルボタン押下時の処理
    /// </summary>
    private async Task Cancel()
    {
        await Task.Yield();

        // 一覧画面に戻る
        NavigationManager.NavigateTo(PageUrl.MYTASK_LIST);
    }

    /// <summary>
    /// 登録ボタン押下時の処理
    /// </summary>
    private async Task SaveMyTask()
    {
        Logger.LogInformation("MyTask Title={{{}}} Deadline={{{}}} Status={{{}}} Content={{{}}}", myTask.Title, myTask.Deadline, myTask.Status, myTask.Content);

        await Task.Yield();

        // 保存
        sessionState?.State?.Add(myTask);

        // 一覧画面に戻る
        NavigationManager.NavigateTo(PageUrl.MYTASK_LIST);
    }
}
