﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DevelopEnvironmentInfo.ascx.cs" Inherits="RockWeb.Blocks.Examples.DevelopEnvironmentInfo" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlView" runat="server" CssClass="">
            <pre>
<asp:Literal ID="lDatabaseName" runat="server" /><asp:Literal ID="lHostingEnvironment" runat="server" />

<input id="cbLimitToSessionId" runat="server" type="checkbox" checked="checked" /> Limit SQL to Session
SQL Logging: <asp:Literal ID="lDebugSqlStatus" runat="server" /> <asp:LinkButton ID="btnStartLogSQL" runat="server" CssClass="btn btn-xs btn-action" ToolTip="Log SQL Calls to the Visual Studio output window" Text="Start" OnClick="btnStartLogSQL_Click" CausesValidation="false"/> | <asp:LinkButton ID="btnStopLogSql" runat="server" CssClass="btn btn-xs btn-action" Text="Stop" OnClick="btnStopLogSQL_Click" /> | <asp:LinkButton ID="btnShowSQLLog" runat="server" CssClass="btn btn-xs btn-action" Text="Show" OnClick="btnShowSQLLog_Click" /> 

<div class="pull-right"></div><asp:LinkButton ID="btnLoadPages" runat="server" CssClass="btn btn-action btn-xs " Text="Load BlockTypes/Pages Test" ToolTip="Loads all BlockTypes, and then does a simple request of all Pages, outputting the progress to the Debug Output" OnClick="btnLoadBlockTypesAndPages_Click" CausesValidation="false" /> <asp:LinkButton ID="btnShutdown" runat="server" CssClass="btn btn-danger btn-xs" Text="Restart Website" OnClick="btnShutdown_Click" CausesValidation="false" /><div></div></pre>
        </asp:Panel>

        <Rock:ModalDialog ID="mdSQLOutput" runat="server">
            <Content>
                <Rock:CodeEditor ID="ceSqlOutput" runat="server" EditorMode="Sql" EditorHeight="600" />
            </Content>
        </Rock:ModalDialog>
    </ContentTemplate>
</asp:UpdatePanel>
