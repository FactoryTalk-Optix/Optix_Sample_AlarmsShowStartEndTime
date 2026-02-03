#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.EventLogger;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Modbus;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.DataLogger;
using System.Linq;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // GenerateAlarmDurationColumn();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void GenerateAlarmDurationColumn()
    {
        DataGrid table = (DataGrid)Owner;
        DataGridColumn newColumn = InformationModel.Make<DataGridColumn>("AlarmDuration");

        newColumn.Title = "Alarm Duration";

        var dataItemTemplate = InformationModel.Make<DataGridLabelItemTemplate>("DataItemTemplate");

        var itemAlias = table.GetNodesByType<Alias>().FirstOrDefault(a => a.BrowseName == "Item");

        var pointedNode = InformationModel.Get(itemAlias.NodeId);

        dataItemTemplate.TextVariable.Value = "ciao";

        newColumn.DataItemTemplate.Delete();
        newColumn.Add(dataItemTemplate);
        table.Columns.Add(newColumn);
    }
}
