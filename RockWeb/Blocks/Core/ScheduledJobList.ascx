﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScheduledJobList.ascx.cs" Inherits="RockWeb.Blocks.Administration.ScheduledJobList" %>

<asp:UpdatePanel ID="upScheduledJobList" runat="server">
    <ContentTemplate>

        <Rock:ModalAlert ID="mdGridWarning" runat="server" />

        <asp:Panel ID="pnlScheduledJobs" CssClass="panel panel-block" runat="server">
            
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-clock-o"></i> Jobs List</h1>
            </div>
            <div class="panel-body">
                <div class="grid grid-panel">
                    <Rock:GridFilter ID="gfSettings" runat="server" OnApplyFilterClick="gfSettings_ApplyFilterClick" OnClearFilterClick="gfSettings_ClearFilterClick">
                        <Rock:RockTextBox ID="tbNameFilter" runat="server" Label="Name" />
                        <Rock:RockDropDownList ID="ddlActiveFilter" runat="server" Label="Active Status">
                                <asp:ListItem Text="[All]" Value="" />
                                <asp:ListItem Text="Active" Value="true" />
                                <asp:ListItem Text="Inactive" Value="false" />
                            </Rock:RockDropDownList>
                    </Rock:GridFilter>

                    <Rock:Grid ID="gScheduledJobs" runat="server" TooltipField="Description" OnRowSelected="gScheduledJobs_Edit" AllowSorting="true" OnRowDataBound="gScheduledJobs_RowDataBound">
                        <Columns>
                            <Rock:RockBoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <Rock:DateTimeField DataField="LastSuccessfulRunDateTime" HeaderText="Last Successful Run" SortExpression="LastSuccessfulRunDateTime" />
                            <Rock:DateTimeField DataField="LastRunDateTime" HeaderText="Last Run Date" SortExpression="LastRunDateTime" />
                            <Rock:RockLiteralField ID="lLastRunDurationSeconds" HeaderText="Last Run Duration" SortExpression="LastRunDurationSeconds" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <Rock:RockLiteralField ID="lLastStatus" HeaderText="Last Status" SortExpression="LastStatus" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                            <Rock:RockLiteralField ID="lLastStatusMessageAsHtml" HeaderText="Last Status Message" SortExpression="LastStatusMessage"/>
                            <Rock:BoolField DataField="IsSystem" HeaderText="System" SortExpression="IsSystem" />
                            <Rock:BoolField DataField="IsActive" HeaderText="Active" SortExpression="IsActive" />
                            <Rock:LinkButtonField OnClick="gScheduledJobs_History" CssClass="btn btn-default btn-sm" HeaderText="History" ToolTip="History" Text="<i class='fa fa-history'></i>" OnDataBound="gScheduledJobs_History_DataBound"/>
                            <Rock:LinkButtonField OnClick="gScheduledJobs_RunNow"  CssClass="btn btn-default btn-sm" HeaderText="Run Now" ToolTip="Run Now" Text="<i class='fa fa-play'></i>" OnDataBound="gScheduledJobs_RunNow_DataBound"/>
                            <Rock:DeleteField OnClick="gScheduledJobs_Delete" />
                        </Columns>
                    </Rock:Grid>
                </div>
            </div>
        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
