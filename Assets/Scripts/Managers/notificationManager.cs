using UnityEngine;
using Unity.Notifications.Android;
using System.Data;
using System;
using System.Collections;

public class notificationManager : MonoBehaviour
{
    public string ChannelID = "game_reminders";
    private void Start()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = ChannelID,
            Name = "Space Clicker Notifications",
            Importance = Importance.Default,
            Description = "Reminders for keep playing our awesome game!"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void ScheduleNotif()
    {
        var notification1 = new AndroidNotification
        {
            Title = "Get rid of these meteors",
            Text = "Come back and destroy some meteors!",
            FireTime = DateTime.Now.AddHours(4),
        };
        var notification2 = new AndroidNotification
        {
            Title = "Your pets miss you!",
            Text = "Come back and take care of your adorable pets!",
            FireTime = DateTime.Now.AddHours(8),
        };
        var notification3 = new AndroidNotification
        {
            Title = "We miss you!",
            Text = "Haven't seen you in a while...",
            FireTime = DateTime.Now.AddDays(2),
        };
        AndroidNotificationCenter.SendNotification(notification1,ChannelID);
        AndroidNotificationCenter.SendNotification(notification2, ChannelID);
        AndroidNotificationCenter.SendNotification(notification3, ChannelID);
    }
    public void ClearNotification()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ScheduleNotif();
        }
        else
        {
            ClearNotification();
        }
    }
    public IEnumerator RequestPermission()
    {
        if(AndroidNotificationCenter.UserPermissionToPost==PermissionStatus.Allowed)
        {
            yield break;
        }
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
        {
            yield return null;
        }
        
    }
}
