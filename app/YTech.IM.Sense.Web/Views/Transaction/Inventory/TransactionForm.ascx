﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<YTech.IM.Sense.Web.Controllers.ViewModel.TransactionFormViewModel>" %>
<%@ Import Namespace="YTech.IM.Sense.Enums" %>
<%--<% using (Html.BeginForm("Save", "Inventory", FormMethod.Post, new { @class = "cmxform" }))
   { %>--%>
<% using (Html.BeginForm())
   { %>
<%= Html.AntiForgeryToken() %>
<%= Html.Hidden("Trans.Id", (ViewData.Model.Trans != null) ? ViewData.Model.Trans.Id : "")%>
<%= Html.Hidden("Trans.TransStatus", (ViewData.Model.Trans != null) ? ViewData.Model.Trans.TransStatus : "")%>
<%--<div>
<%= ViewData.Model.Title %>
</div>--%>
<% if (TempData[EnumCommonViewData.SaveState.ToString()] != null)
   {
       if (TempData[EnumCommonViewData.SaveState.ToString()].Equals(EnumSaveState.Success))
       {	%>
<div class="ui-state-highlight ui-corner-all" style="padding: 5pt; margin-bottom: 5pt;">
    <p>
        <span class="ui-icon ui-icon-info" style="float: left; margin-right: 0.3em;"></span>
        Transaksi berhasil disimpan.</p>
</div>
<% }
   else if (TempData[EnumCommonViewData.SaveState.ToString()].Equals(EnumSaveState.Failed))
   { %>
<div class="ui-state-error ui-corner-all" style="padding: 5pt; margin-bottom: 5pt;">
    <p>
        <span class="ui-icon ui-icon-alert" style="float: left; margin-right: 0.3em;"></span>
        Transaksi gagal disimpan.
    </p>
</div>
<% }
   } %>
<div>
    <span id="toolbar" class="ui-widget-header ui-corner-all"><a id="newTrans" href="/Transaction/Inventory<% if (!ViewData.Model.Trans.TransStatus.Equals(EnumTransactionStatus.PurchaseOrder.ToString())){%>/<%= Model.Trans.TransStatus.ToString() %><%} %>">
        Baru</a>
        <button id="Save" type="submit">
            Simpan</button>
    </span>
</div>
<table>
    <tr>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td>
            <table>
             <% if (ViewData.Model.ViewDate)
                   {	%>
                <tr>
                    <td>
                        <label for="Trans_TransDate">
                            Tanggal :</label>
                    </td>
                    <td>
                        <%= Html.TextBox("Trans.TransDate", (Model.Trans.TransDate.HasValue) ? Model.Trans.TransDate.Value.ToString("dd-MMM-yyyy") : "")%>
                        <%= Html.ValidationMessage("Trans.TransDate")%>
                    </td>
                </tr>
                <% } %>

                 <% if (ViewData.Model.ViewFactur)
                   {	%>
                <tr>
                    <td>
                        <label for="Trans_TransFactur">
                            No Faktur :</label>
                    </td>
                    <td>
                        <%= Html.TextBox("Trans.TransFactur", Model.Trans.TransFactur)%>
                        <%= Html.ValidationMessage("Trans.TransFactur")%>
                    </td>
                </tr>
                <% } %>
                <% if (ViewData.Model.ViewSupplier)
                   {	%>
                <tr>
                    <td>
                        <label for="Trans_TransBy">
                            Supplier :</label>
                    </td>
                    <td>
                        <%= Html.DropDownList("Trans.TransBy", Model.SupplierList)%>
                        <%= Html.ValidationMessage("Trans.TransBy")%>
                    </td>
                </tr>
                <% } %>
                <% if (ViewData.Model.ViewWarehouse)
                   {	%>
                <tr>
                    <td>
                        <label for="Trans_WarehouseId">
                            Gudang :</label>
                    </td>
                    <td>
                        <%= Html.DropDownList("Trans.WarehouseId", Model.WarehouseList)%>
                        <%= Html.ValidationMessage("Trans.WarehouseId")%>
                    </td>
                </tr>
                <% } %>
                <% if (ViewData.Model.ViewWarehouseTo)
                   {	%>
                <tr>
                    <td>
                        <label for="Trans_WarehouseIdTo">
                            Ke Gudang :</label>
                    </td>
                    <td>
                        <%= Html.DropDownList("Trans.WarehouseIdTo", Model.WarehouseToList)%>
                        <%= Html.ValidationMessage("Trans.WarehouseIdTo")%>
                    </td>
                </tr>
                <% } %>
            </table>
        </td>
        <td>
        </td>
    </tr>
</table>
<table id="list" class="scroll" cellpadding="0" cellspacing="0">
</table>
<div id="listPager" class="scroll" style="text-align: center;">
</div>
<div id="listPsetcols" class="scroll" style="text-align: center;">
</div>
<div id="dialog" title="Status">
    <p>
    </p>
</div>
<% } %>
<script language="javascript">
    function CalculateTotal() {
        var price = $('#TransDetPrice').attr('value');
        var qty = $('#TransDetQty').attr('value');
        var disc = $('#TransDetDisc').attr('value');
        var subtotal = (price * qty)
        var total = subtotal - (disc * subtotal / 100);

        $('#TransDetTotal').attr('value', total);
    }

    $(function () {
        $("#newTrans").button();
        $("#Save").button();
        $("#Trans_TransDate").datepicker({ dateFormat: "dd-M-yy" });
    });

    $(document).ready(function () {
        $("#dialog").dialog({
            autoOpen: false
        });

        var editDialog = {
            url: '<%= Url.Action("Update", "Inventory") %>'
                , closeAfterAdd: true
                , closeAfterEdit: true
                , modal: true

                , onclickSubmit: function (params) {
                    var ajaxData = {};

                    var list = $("#list");
                    var selectedRow = list.getGridParam("selrow");
                    rowData = list.getRowData(selectedRow);
                    ajaxData = { Id: rowData.Id };

                    return ajaxData;
                }
                , afterShowForm: function (eparams) {
                    $('#Id').attr('disabled', 'disabled');
                }
                , width: "400"
                , afterComplete: function (response, postdata, formid) {
                    $('#dialog p:first').text(response.responseText);
                    $("#dialog").dialog("open");
                }
        };
        var insertDialog = {
            url: '<%= Url.Action("Insert", "Inventory") %>'
                , closeAfterAdd: true
                , closeAfterEdit: true
                , modal: true
                , afterShowForm: function (eparams) {
                    $('#Id').attr('disabled', '');

                    $('#TransDetPrice').attr('value', '0');
                    $('#TransDetQty').attr('value', '1');
                    $('#TransDetDisc').attr('value', '0');
                    $('#TransDetTotal').attr('value', '0');

                    $('#ItemId').change(function () {
                        var price = $.ajax({ url: '/Master/Item/Get/' + $('#ItemId :selected').val(), async: false, cache: false, success: function (data, result) { if (!result) alert('Failure to retrieve the items.'); } }).responseText;
                        $('#TransDetPrice').attr('value', price);
                        CalculateTotal();
                    });
                    $('#TransDetPrice').change(function () {
                        CalculateTotal();
                    });
                    $('#TransDetQty').change(function () {
                        CalculateTotal();
                    });
                    $('#TransDetDisc').change(function () {
                        CalculateTotal();
                    });
                }
                , afterComplete: function (response, postdata, formid) {
                    $('#dialog p:first').text(response.responseText);
                    $("#dialog").dialog("open");
                }
                , width: "400"
        };
        var deleteDialog = {
            url: '<%= Url.Action("Delete", "Inventory") %>'
                , modal: true
                , width: "400"
                , afterComplete: function (response, postdata, formid) {
                    $('#dialog p:first').text(response.responseText);
                    $("#dialog").dialog("open");
                }
        };

        $.jgrid.nav.addtext = "Tambah";
        $.jgrid.nav.edittext = "Edit";
        $.jgrid.nav.deltext = "Hapus";
        $.jgrid.edit.addCaption = "Tambah Detail Baru";
        $.jgrid.edit.editCaption = "Edit Detail";
        $.jgrid.del.caption = "Hapus Detail";
        $.jgrid.del.msg = "Anda yakin menghapus Detail yang dipilih?";
        $("#list").jqGrid({
            url: '<%= Url.Action("List", "Inventory") %>',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Id', 'Produk', 'Produk', 'Kuantitas', 'Harga', 'Diskon', 'Total', 'Keterangan'],
            colModel: [
                    { name: 'Id', index: 'Id', width: 100, align: 'left', key: true, editrules: { required: true, edithidden: false }, hidedlg: true, hidden: true, editable: false },
                    { name: 'ItemId', index: 'ItemId', width: 200, align: 'left', editable: true, edittype: 'select', editrules: { edithidden: true }, hidden: true },
                    { name: 'ItemName', index: 'ItemName', width: 200, align: 'left', editable: false, edittype: 'select', editrules: { edithidden: true} },
                   { name: 'TransDetQty', index: 'TransDetQty', width: 200, sortable: false, align: 'right', editable: true, editrules: { required: false, number: true }, formatter: 'number' },
                   { name: 'TransDetPrice', index: 'TransDetPrice', width: 200, sortable: false, align: 'right', editable: true, editrules: { required: false, number: true }, formatter: 'number' },
                   { name: 'TransDetDisc', index: 'TransDetDisc', width: 200, sortable: false, align: 'right', editable: true, editrules: { required: false, number: true }, formatter: 'number' },
                   { name: 'TransDetTotal', index: 'TransDetTotal', width: 200, sortable: false, align: 'right', editable: true, editrules: { required: false, number: true }, formatter: 'number' },
                   { name: 'TransDetDesc', index: 'BrandDesc', width: 200, sortable: false, align: 'left', editable: true, edittype: 'textarea', editoptions: { rows: "3", cols: "20" }, editrules: { required: false}}],

            pager: $('#listPager'),
            rowNum: -1,
            //              rowList: [20, 30, 50, 100],
            rownumbers: true,
            //              sortname: 'Id',
            //              sortorder: "asc",
            //              viewrecords: true,
            height: 300,
            caption: 'Daftar Detail',
            autowidth: true,
            loadComplete: function () {
                $('#list').setColProp('ItemId', { editoptions: { value: items} });
                $('#listPager_center').hide();
            },
            ondblClickRow: function (rowid, iRow, iCol, e) {
                //$("#list").editGridRow(rowid, editDialog);
            }, footerrow: true, userDataOnFooter: true, altRows: true
        }).navGrid('#listPager',
                {
                    edit: false, add: true, del: true, search: false, refresh: true, view: false
                },
                editDialog,
                insertDialog,
                deleteDialog
            );

        var items = $.ajax({ url: '/Master/Item/GetList', async: false, cache: false, success: function (data, result) { if (!result) alert('Failure to retrieve the items.'); } }).responseText;
    });
</script>
