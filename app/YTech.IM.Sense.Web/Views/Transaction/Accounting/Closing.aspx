<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MyMaster.master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<ClosingViewModel>" %>
<%@ Import Namespace="YTech.IM.Sense.Enums" %>
<%@ Import Namespace="YTech.IM.Sense.Web.Controllers.ViewModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script language="javascript" type="text/javascript">

        $(function () {
            $("#Save").button();
            $("#DateFrom").datepicker({ dateFormat: "dd-M-yy" });
            $("#DateTo").datepicker({ dateFormat: "dd-M-yy" });
        });

        $(document).ready(function () {


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="title" runat="server">
    Tutup Buku
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<% if (TempData[EnumCommonViewData.SaveState.ToString()] != null)
   {
       if (TempData[EnumCommonViewData.SaveState.ToString()].Equals(EnumSaveState.Success))
       {	%>
    <div class="ui-state-highlight ui-corner-all" style="padding: 5pt; margin-bottom: 5pt;">
        <p>
            <span class="ui-icon ui-icon-info" style="float: left; margin-right: 0.3em;"></span>
            Tutup Buku berhasil disimpan.</p>
    </div>
    <% }
       else if (TempData[EnumCommonViewData.SaveState.ToString()].Equals(EnumSaveState.Failed))
       { %>
    <div class="ui-state-error ui-corner-all" style="padding: 5pt; margin-bottom: 5pt;">
        <p>
            <span class="ui-icon ui-icon-alert" style="float: left; margin-right: 0.3em;"></span>
            Tutup Buku gagal disimpan.
        </p>
    </div>
   <% }
   } %>


    <% using (Html.BeginForm())
       {%>
    <%=Html.AntiForgeryToken()%>
    
<div>
    <span id="toolbar" class="ui-widget-header ui-corner-all">

        <button id="Save" type="submit">
            Ok</button>
    </span>
</div>

    <table>
        <tr>
            <td>
                <label for="DateFrom">
                    Dari Tanggal :</label>
            </td>
            <td>
                <%= Html.TextBox("DateFrom", (Model.DateFrom.HasValue) ? Model.DateFrom.Value.ToString("dd-MMM-yyyy") : "")%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="DateTo">
                    Sampai Tanggal :</label>
            </td>
            <td>
                <%= Html.TextBox("DateTo", (Model.DateTo.HasValue) ? Model.DateTo.Value.ToString("dd-MMM-yyyy") : "")%>
            </td>
        </tr>
    </table>
    <%
        }%>
</asp:Content>
