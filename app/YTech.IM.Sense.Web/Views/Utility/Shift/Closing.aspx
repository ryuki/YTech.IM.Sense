<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MyMaster.master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<ShiftFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <% if (false)
       { %>
    <script src="../../../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <% } %>
    <% using (Html.BeginForm())
       {%>
    <%=Html.AntiForgeryToken()%>
    <table>
        <tr>
            <td>
                <label for="ShiftDate">
                    Tanggal :
                </label>
            </td>
            <td>
                <%=Html.TextBox("ShiftDate", Model.Shift.ShiftDate.Value.ToString(CommonHelper.DateFormat))%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ShiftDateFrom">
                    Dari Jam :
                </label>
            </td>
            <td>
                <%=Html.TextBox("ShiftDateFrom", Model.Shift.ShiftDateFrom.Value.ToString(CommonHelper.TimeFormat))%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ShiftDateFrom">
                    s/d
                </label>
            </td>
            <td>
                <%=Html.TextBox("ShiftDateTo", Model.Shift.ShiftDateTo.Value.ToString(CommonHelper.TimeFormat))%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ShiftNo">
                    Shift ke :
                </label>
            </td>
            <td>
                <%=Html.TextBox("ShiftNo", Model.Shift.ShiftNo.Value)%>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <%=Html.SubmitButton("Save", "OK")%>
            </td>
        </tr>
    </table>
     <div id="dialog" title="Status">
        <p>
        </p>
    </div>
    <% } %>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#ShiftDate").datepicker({ dateFormat: "dd-M-yy" });
            $("#dialog").dialog({
                autoOpen: false
            });
            $(':submit').button();
            $('form').submit(function () {
                //get the form
                var f = $('form');
                var serializedForm = f.serialize();
                //alert(serializedForm);
                var action = f.attr('action');
                //alert(action);
                $.post(action, serializedForm,
                    function (result) {
                       // alert(result);
//                        var result = JSON.parse(result);
                        var success = result.Success;
                        var msg = result.Message;
                        $('#dialog p:first').text(msg);
                        $("#dialog").dialog("open");

                        $(':submit').attr('disabled', 'disabled');
                    });
                return false;
            });

            jQuery().ajaxStart(function () {
                $('form').fadeOut("slow");
            });

            jQuery().ajaxStop(function () {
                $('form').fadeIn("slow");
            });
        });    
    </script>
</asp:Content>
