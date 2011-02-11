﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="accordion">
    <h3>
        <a href="#">Home</a></h3>
    <div>
        <div>
            <%=Html.ActionLinkForAreas<HomeController>(c => c.Index(), "Home") %></div>
    </div>
    <% if (Request.IsAuthenticated)
       {
%>
    <h3>
        <a href="#">Data Pokok</a></h3>
    <div>
        <div>
            <%= Html.ActionLinkForAreas<WarehouseController>(c => c.Index(),"Master Gudang") %></div>
        <div>
            <%= Html.ActionLinkForAreas<MItemCatController>(c => c.Index(),"Master Kategori Perawatan") %></div>
        <div>
            <%= Html.ActionLinkForAreas<BrandController>(c => c.Index(),"Master Merek") %></div>
        <div>
            <%= Html.ActionLinkForAreas<ItemController>(c => c.Index(), "Master Produk")%></div>
        <div>
            <%= Html.ActionLinkForAreas<PacketController>(c => c.Index(), "Master Paket")%></div>
        <div>
            <%= Html.ActionLinkForAreas<RoomController>(c => c.Index(), "Master Ruangan")%></div>
        <div>
            <hr />
        </div>
        <div>
            <%= Html.ActionLinkForAreas<SupplierController>(c => c.Index(),"Master Supplier") %></div>
        <div>
            <%= Html.ActionLinkForAreas<CustomerController>(c => c.Index(),"Master Konsumen") %></div>
        <div>
            <hr />
        </div>
        <div>
            <%= Html.ActionLinkForAreas<DepartmentController>(c => c.Index(),"Master Departemen") %></div>
        <div>
            <%= Html.ActionLinkForAreas<EmployeeController>(c => c.Index(), "Master Karyawan")%>
        </div>
        <div>
            <hr />
        </div>
        <div>
            <%= Html.ActionLinkForAreas<CostCenterController>(c => c.Index(),"Master Cost Center") %></div>
        <div>
            <%= Html.ActionLinkForAreas<AccountController>(c => c.Index(),"Master Akun") %></div>
    </div>
    <h3>
        <a href="#">Inventori</a></h3>
    <div>
        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.Index(), "Order Pembelian")%></div>
        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.Purchase(), "Pembelian")%></div>
        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.ReturPurchase(), "Retur Pembelian")%></div>
            <div><hr /></div>
        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.Sales(), "Penjualan")%></div>
        <div>
           <%= Html.ActionLinkForAreas<InventoryController>(c => c.ReturSales(), "Retur Penjualan")%></div>
        <div>
         <%= Html.ActionLinkForAreas<InventoryController>(c => c.Billing(), "Billing")%></div>
            <div><hr /></div>

        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.Mutation(), "Mutasi Stok")%></div>
        <div>
            <%= Html.ActionLinkForAreas<InventoryController>(c => c.Adjusment(), "Penyesuaian Stok")%></div>
        <div>
            <hr />
        </div>
    </div>
    <h3>
        <a href="#">Pembukuan</a></h3>
    <div>
        <div>
            <%= Html.ActionLinkForAreas<AccountingController>(c => c.GeneralLedger(), "General Ledger")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<AccountingController>(c => c.CashIn(), "Kas Masuk")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<AccountingController>(c => c.CashOut(), "Kas Keluar")%>
        </div>
        <%-- <div>Mutasi Kas</div>
                            <div>Kasbon</div>
                            <div><hr /></div>
                            <div>Pembayaran Hutang</div>
                            <div>Pembayaran Gaji</div>--%>
    </div>
     <h3>
        <a href="#">Absensi</a></h3>
    <div>
      <div>
            <%= Html.ActionLinkForAreas<HRController>(c => c.Absent(), "Absen Karyawan")%>
        </div>
         </div>

    <h3>
        <a href="#">Laporan</a></h3>
    <div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptBrand), "Daftar Merek")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptCostCenter), "Daftar Cost Center")%>
        </div>
        <div>
            <hr />
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptStockCard), "Kartu Stok")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptStockItem), "Laporan Stok Per Gudang")%>
        </div>
        <div>
            <hr />
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptJournal), "Lap. Jurnal")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptNeraca), "Lap. Neraca")%>
        </div>
        <div>
            <%= Html.ActionLinkForAreas<ReportController>(c => c.Report(EnumReports.RptLR), "Lap. Laba / Rugi")%>
        </div>
    </div>
    <h3>
        <a href="#">Utiliti</a></h3>
    <div>
        <div>
            <%= Html.ActionLinkForAreas<UserAdministrationController>(c => c.Index(null), "Daftar Pengguna")%></div>
        <div>
            Ganti Password</div>
        <div>
            Backup Database</div>
        <div>
            <%= Html.ActionLinkForAreas<AccountingController>(c => c.Closing(), "Tutup Buku")%>
        </div>
    </div>
    <%
        }
%>
</div>
