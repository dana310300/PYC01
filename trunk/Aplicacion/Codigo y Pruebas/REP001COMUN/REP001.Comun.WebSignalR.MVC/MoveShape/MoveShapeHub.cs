using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace REP001.Comun.WebSignalR.MVC.MoveShape
{
    [HubName("moveShapeHub")]
    public class MoveShapeHub:Hub
    {
        public void MoveShape(int x, int y) {
            Clients.Others.actionShapeMoved(x, y);
        }

        public void MoveShape1(int x, int y) {
            Clients.Others.actionShapeMoved1(x, y);
        }
    }
}