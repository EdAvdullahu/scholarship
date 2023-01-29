using Scholarship_back.Outer.Models;
using System;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface Notification
    {
        public void SendNotification(User person, string msg)
        {
            // Code to send an email to the person
            // using the provided email address and message
        }
    }
}
