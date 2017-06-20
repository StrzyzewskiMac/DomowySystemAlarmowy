using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.DAO;
using SystemModel.TO;
using SystemCore.Mappers;
using SystemCore.Services.SMS;

namespace SystemCore.Devices.Alarm.Impl
{
    public class AlarmSystemImpl : AlarmSystem
    {
        public bool AlarmOn
        {
            get;
            private set;
        }

        public int BeepIntervalInMiliseconds
        {
            get;
            private set;
        }

        public int BeepLengthInMiliseconds
        {
            get;
            private set;
        }

        public void TurnOffAlarm()
        {
            AlarmOn = false;
        }

        public void TurnOnAlarm(int beepLengthInMs, int beepIntervalsInMs)
        {
            BeepLengthInMiliseconds = beepLengthInMs;
            BeepIntervalInMiliseconds = beepIntervalsInMs;
            AlarmOn = true;

            _NotifyUsers();
        }

        private void _NotifyUsers()
        {
            var msg = SystemContext.SystemContext.SMSService.NewMessage();
            msg.Message = "Alarm został włączony!";
            msg.Title = "Alarm";

            var recipients = SystemUserDAO.GetInstance().GetAll().Select(SystemUserTO2UserMapper.Map).Select(user => new SMSRecipient { PhoneNumber = user.PhoneNumber });
            foreach (var recipient in recipients)
                msg.Recipients.Add(recipient);

            SystemContext.SystemContext.SMSService.SendMessage(msg);
        }
    }
}
