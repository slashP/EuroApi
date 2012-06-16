using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using EuroApi.Context;
using SignalR.Hubs;

namespace EuroApi.Entities
{
    public class Chat : Hub
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public void GetMessages()
        {
            var messages = _db.LiveTalks.OrderByDescending(x => x.Id).Take(6).Select(x => new {x.User, x.Content}).ToList();
            messages.Reverse();
            messages.ForEach(x => Caller.addMessage(x));
        }

        public void Send(LiveTalk chatMessage)
        {
            var tagRegex = new Regex(@"<[^>]+>");
            if(chatMessage.Content.Length > 400 || tagRegex.Match(chatMessage.Content).Success)
            {
                return;
            }
            _db.LiveTalks.Add(chatMessage);
            _db.SaveChanges();
            Clients.addMessage(chatMessage);
        }
    }
}