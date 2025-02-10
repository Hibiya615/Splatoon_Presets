using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Hooking;
using ECommons.DalamudServices;
using ECommons.Schedulers;
using Splatoon.SplatoonScripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatoonScriptsOfficial.Duties.Dawntrail;

internal class R4S_黑色安息日的午夜_Midnight_Sabbath: SplatoonScript
{
    public override HashSet<uint> ValidTerritories => new() { 1232 };
    public override Metadata? Metadata => new(2, "Fragile，南雲鉄虎调色");

    public override void OnActorControl(uint actorID, uint category, uint p1, uint p2, uint p3, uint p4, uint p5, uint p6, ulong targetId, byte replaying)
    {
        if (category == 407)
        {
            var obj = Svc.Objects.SearchById(actorID);
            switch (p1)
            {
                case 4561:
                    FirstLine(obj);
                    break;
                case 4562:
                    AfterLine(obj);
                    break;
                case 4563:
                    FirstWing(obj);
                    break;
                case 4564:
                    AfterWing(obj);
                    break;
            }
        }
    }

    private void FirstLine(IGameObject obj)
    {
        Controller.RegisterElementFromCode(obj.EntityId.ToString(), $"{{\"Name\":\"第一轮直线\",\"type\":3,\"refY\":30.0,\"radius\":5.0,\"color\":4278255615,\"fillIntensity\":0.15,\"originFillColor\":587268095,\"endFillColor\":587268095,\"refActorObjectID\":{obj.EntityId},\"refActorUseCastTime\":true,\"refActorCastTimeMax\":5.0,\"refActorUseOvercast\":true,\"refActorComparisonType\":2,\"includeRotation\":true,\"onlyVisible\":true,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0,\"refActorUseTransformation\":true,\"refActorTetherConnectedWithPlayer\":[],\"refActorTransformationID\":7}}");
        Controller.ScheduleReset(20000);
    }

    private void FirstWing(IGameObject obj)
    {
        Controller.RegisterElementFromCode(obj.EntityId.ToString(), $"{{\"Name\":\"第一轮月环\",\"type\":1,\"radius\":5.0,\"Donut\":10.0,\"color\":4278255615,\"fillIntensity\":0.15,\"originFillColor\":587268095,\"endFillColor\":587268095,\"refActorObjectID\":{obj.EntityId},\"refActorUseCastTime\":true,\"refActorCastTimeMax\":5.0,\"refActorUseOvercast\":true,\"refActorComparisonType\":2,\"includeRotation\":true,\"onlyVisible\":true,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0,\"refActorUseTransformation\":true,\"refActorTetherConnectedWithPlayer\":[],\"refActorTransformationID\":31}}");
        Controller.ScheduleReset(20000);
    }

    private void AfterLine(IGameObject obj)
    {
        _ = new TickScheduler(delegate
        {
            Controller.RegisterElementFromCode(obj.EntityId.ToString(), $"{{\"Name\":\"第二轮直线\",\"type\":3,\"refY\":30.0,\"radius\":5.0,\"color\":4278255615,\"fillIntensity\":0.15,\"originFillColor\":587268095,\"endFillColor\":587268095,\"refActorObjectID\":{obj.EntityId},\"refActorUseCastTime\":true,\"refActorCastTimeMax\":5.0,\"refActorUseOvercast\":true,\"refActorComparisonType\":2,\"includeRotation\":true,\"onlyVisible\":true,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0,\"refActorUseTransformation\":true,\"refActorTetherConnectedWithPlayer\":[],\"refActorTransformationID\":7}}");
        }, 8000);
        Controller.ScheduleReset(20000);
    }

    private void AfterWing(IGameObject obj)
    {
        _ = new TickScheduler(delegate
        {
            Controller.RegisterElementFromCode(obj.EntityId.ToString(), $"{{\"Name\":\"第二轮月环\",\"type\":1,\"radius\":5.0,\"Donut\":10.0,\"color\":4278255615,\"fillIntensity\":0.15,\"originFillColor\":587268095,\"endFillColor\":587268095,\"refActorObjectID\":{obj.EntityId},\"refActorUseCastTime\":true,\"refActorCastTimeMax\":5.0,\"refActorUseOvercast\":true,\"refActorComparisonType\":2,\"includeRotation\":true,\"onlyVisible\":true,\"refActorTetherTimeMin\":0.0,\"refActorTetherTimeMax\":0.0,\"refActorUseTransformation\":true,\"refActorTetherConnectedWithPlayer\":[],\"refActorTransformationID\":31}}");
        }, 8000);
        Controller.ScheduleReset(20000);
    }

    public override void OnReset()
    {
        Controller.ClearRegisteredElements();
    }
}