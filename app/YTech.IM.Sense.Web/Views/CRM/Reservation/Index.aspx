<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MyMaster.master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<ReservationFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<% if (false)
   { %>
<script src="../../../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
<% } %>
    Tambah Reservasi baru
    <table>
      <%--  <tr>
            <td>
                <label for="ReservationIsMember">
                    Punya kartu member</label>
            </td>
            <td>
                <%= Html.CheckBox("ReservationIsMember", Model.Reservation.ReservationIsMember)%>
            </td>
        </tr>--%>
        <tr>
            <td>
                <label for="CustomerId">
                    No Member :</label>
            </td>
            <td>
                <%= Html.TextBox("CustomerId",Model.Reservation.CustomerId != null ? Model.Reservation.CustomerId.Id : null)%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ReservationName">
                    Nama Pemesan :</label>
            </td>
            <td>
                <%= Html.TextBox("ReservationName", Model.Reservation.ReservationName)%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ReservationPhoneNo">
                    No Telp :</label>
            </td>
            <td>
                <%= Html.TextBox("ReservationName", Model.Reservation.ReservationPhoneNo)%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ReservationDate">
                    Tanggal Reservasi :</label>
            </td>
            <td>
                <%= Html.TextBox("ReservationDate", Model.Reservation.ReservationDate.HasValue ? Model.Reservation.ReservationDate.Value.ToString(CommonHelper.DateFormat) : null)%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ReservationAppoinmentTime">
                    Jam :</label>
            </td>
            <td>
                <%= Html.TextBox("ReservationAppoinmentTime", Model.Reservation.ReservationAppoinmentTime.HasValue ? Model.Reservation.ReservationAppoinmentTime.Value.ToString(CommonHelper.TimeFormat) : null)%>
            </td>
        </tr>
        <tr>
            <td>
                <label for="ReservationNoOfPeople">
                    Jumlah Orang :</label>
            </td>
            <td>
                <%= Html.TextBox("ReservationNoOfPeople", Model.Reservation.ReservationNoOfPeople)%>
                <input id="btnDetail" type="button" value="Detail" />
            </td>
        </tr>
        <tr>
        <td colspan="2">
        <table id="tblDetail"></table>
        </td>
        </tr>
    </table>
    
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#btnDetail').click(function () {
            var noOfPeople = $('#ReservationNoOfPeople').val();
            for (var i = 0; i < noOfPeople; i++) {

            }
        });
    });
</script>
</asp:Content>
