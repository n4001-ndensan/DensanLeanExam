using BlazorApp3.Domain.Model;
using BlazorApp3.Domain.Value;
using BlazorApp3.Application.Value;

namespace BlazorApp3.Components.Pages;

public partial class MyTaskList
{
    private List<MyTask>? myTaskList;

    protected override void OnInitialized()
    {
        InitMyTaskList();
        SortMyTaskList();
    }

    /// <summary>
    /// タスク一覧の初期化
    /// </summary>
    private void InitMyTaskList()
    {
        // セッションからタスク一覧を取得
        if (sessionState.HasState)
        {
            myTaskList ??= sessionState?.State;
        }

        // セッションにタスク一覧がない場合はサンプルデータをセット
        myTaskList ??=
        [
            new MyTask
            {
                Title = "サンプルタスク1",
                Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                Status = MyTaskStatus.未着手,
                Content = "サンプルタスク1の内容です。"
            },
            new MyTask
            {
                Title = "サンプルタスク2",
                Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                Status = MyTaskStatus.仕掛中,
                Content = "サンプルタスク2の内容です。\n改行もできます。"
            },
            new MyTask
            {
                Title = "サンプルタスク3",
                Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                Status = MyTaskStatus.完了,
                Content = "サンプルタスク3の内容です。\n改行もできます。"
            }
        ];
    }

    /// <summary>
    /// タスク一覧のソート
    /// </summary>
    private void SortMyTaskList()
    {
        myTaskList?.Sort();
    }

    /// <summary>
    /// タスク一覧をセッションに保存
    /// </summary>
    private void SaveMyTaskList()
    {
        sessionState.State = myTaskList;
    }

    /// <summary>
    /// 追加ボタン押下時の処理
    /// </summary>
    private async Task AddMyTask()
    {
        await Task.Yield();

        SaveMyTaskList();
        TransferUrlToTaskEdit();
    }

    /// <summary>
    /// タスク編集画面へ遷移
    /// </summary>
    private void TransferUrlToTaskEdit()
    {
        NavigationManager.NavigateTo(PageUrl.MYTASK_EDIT);
    }
}
