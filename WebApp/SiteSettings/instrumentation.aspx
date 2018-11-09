﻿<%@ Page Title="Gerenciamento da instrumentação" Language="C#" Inherits="Benner.Tecnologia.Wes.Components.WebApp.InstrumentationPage" %>

<%@ Register Assembly="Benner.Tecnologia.Wes.Components" Namespace="Benner.Tecnologia.Wes.Components.UI" TagPrefix="wesUI" %>
<%@ Register Assembly="Benner.Tecnologia.Wes.Components" Namespace="Benner.Tecnologia.Wes.Components.WebControls" TagPrefix="wesUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="portlet">
                <div class="portlet-body form">
                    <div class="row">
                        <div class="col-md-12">
                            <wesUI:MessagePanel ID="messagePanel" runat="server">
                            </wesUI:MessagePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div id="ctl00_UserConfig">
                            <div class="col-md-6 widget">
                                <div class="portlet light">
                                    <div class="portlet-title">
                                        <div class="caption collapsible" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl00_UserConfig');">
                                            <span class="caption-subject font-green-sharp bold uppercase">Configuração para usuário</span>
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl00_UserConfig');"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body form">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="control-label" ID="lblUser" Text="Usuário:" />
                                                <wesUI:SearchControl ID="cbUser" runat="server"></wesUI:SearchControl>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" class="control-label" ID="lblLevel" Text="Nível:" />
                                                <asp:DropDownList ID="cbUserLevel" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="CBUserLevelSelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <asp:Panel ID="pnUserLevelInfo" CssClass="alert alert-info" runat="server"></asp:Panel>
                                        </div>
                                        <div class="form-actions nobg">
                                            <asp:Button ID="btConfigUser" CssClass="btn blue" CommandName="User" runat="server" OnCommand="ButtonCommand" Text="Aplicar" ToolTip="aplicar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="ctl01_GlobalConfig">
                            <div class="col-md-6 widget">
                                <div class="portlet light">
                                    <div class="portlet-title">
                                        <div class="caption collapsible" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl01_GlobalConfig');">
                                            <span class="caption-subject"><span class="font-green-sharp bold uppercase">Configuração global</span> (todos os usuários)</span>
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl01_GlobalConfig');"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body form">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:Label runat="server" class="control-label" ID="lblGlobalLevel" Text="Nível:" />
                                                <asp:DropDownList ID="cbGlobalLevel" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="CBGlobalLevelSelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <asp:Panel ID="pnGlobalLevelInfo" CssClass="alert alert-info" runat="server"></asp:Panel>
                                        </div>
                                        <div class="form-actions nobg">
                                            <asp:Button ID="btConfigGlobal" CssClass="btn blue" CommandName="Global" runat="server" OnCommand="ButtonCommand" Text="Aplicar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div id="ctl02_ExceptionVisualization">
                            <div class="col-md-6 widget">
                                <div class="portlet light">
                                    <div class="portlet-title">
                                        <div class="caption collapsible" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl02_ExceptionVisualization');">
                                            <span class="caption-subject font-red bold uppercase">Visualizar exceção</span>
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl02_ExceptionVisualization');"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="form-group">
                                            <label class="control-label"></label>
                                            <div class="input-group">
                                                <input id="exceptionIdTextBox" placeholder="Identificador" class="form-control" />
                                                <span class="input-group-btn">
                                                    <a id="exceptionButton" class="btn blue">
                                                        <asp:Label runat="server" ID="lblView" Text="Visualizar" />
                                                    </a>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="ctl03_Glimpse">
                            <div class="col-md-6 widget">
                                <div class="portlet light">
                                    <div class="portlet-title">
                                        <div class="caption collapsible" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl03_Glimpse');">
                                            <span class="caption-subject font-green-sharp bold uppercase">Glimpse</span>
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse" onclick="Benner.CollapsiblePanel.changeServerChromeState('ctl03_Glimpse');"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <asp:Button ID="btnEnableGlimpse" CssClass="btn green" runat="server" CommandName="Glimpse" OnCommand="ButtonCommand" Text="Ativar" ToolTip="Ativar Glimpse" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $(function () {
            $("#exceptionButton").click(function () {
                Benner.ModalPage.show({ title: "Visualização da exceção", url: "../Error.aspx?ExceptionIdentifier=" + $("#exceptionIdTextBox").val(), size: "full-page", height: 680 });
            });
        });
    </script>
</asp:Content>

