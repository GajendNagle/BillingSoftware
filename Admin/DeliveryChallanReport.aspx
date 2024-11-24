<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="DeliveryChallanReport.aspx.cs" Inherits="Admin_DeliveryChallanReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .grid-header
        {
            background-color: #34495e;
            color: White;
            text-align: center;
        }
        .fieldset-container
        {
            width: 80%;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        }
        
        fieldset
        {
            border: 1px solid black; /* Black border for fieldset */
            border-radius: 5px; /* Rounded corners */
            padding: 20px; /* Padding inside fieldset */
            position: relative; /* Position relative for legend */
            margin: 20px 0; /* Margin around fieldset */
        }
        
        legend
        {
            font-size: 1.5em;
            font-weight: bold;
            color: black;
            padding: 0 10px;
            position: absolute;
            top: -21px;
            left: 23px;
            background-color: white;
            margin: 0;
            width: auto;
            border: 1px solid black;
            border-radius: 5px;
            padding: -1px 10px;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>
                            Report
                        </h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <fieldset>
                                    <legend>View Report Details</legend>
                                    <div class="col-sm-3 mb-3">
                                        <label for="txtDCNo">
                                            Input Invoice NO :</label>
                                        <asp:TextBox ID="txtDCNo" AutoComplete="off" AutoPostBack="true" OnTextChanged="txtDCNo_onTextChanged"
                                            runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="txtFromDate">
                                            From Date:</label>
                                        <asp:TextBox ID="txtFromDate" autocomplete="off" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="txtToDate">
                                            To Date:</label>
                                        <asp:TextBox runat="Server" autocomplete="off" TextMode="Date" class="form-control"
                                            ID="txtToDate"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3" style="margin-top: 3rem;">
                                        <asp:Button runat="server" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_onClick"
                                            CssClass="btn btn-primary" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-midnightblue" id="grdDiv" runat="server" visible="false">
                    <div class="panel-heading">
                        <h4>
                            Bill Information Report</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel ID="pnlReceiptData" runat="server">
                                    <asp:GridView runat="server" CssClass="table table-bordered text-center" AutoGenerateColumns="false"
                                        ID="grdReportData" OnRowCommand="grdReportData_OnRowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                     <asp:Label runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                  <asp:LinkButton ID="btnPrintEdit" runat="server" OnClientClick="aspnetForm.target='_blank';"
                                                        CommandName="EditRecord" CssClass="btn btn-alert-info rounded" Text="Edit"
                                                        CommandArgument='<%# Eval("DC_No") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DC No." ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label  runat="server" Text='<%# Eval("DC_No") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# Eval("Dc_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer Name" ItemStyle-CssClass="grid-ItemName"
                                                HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Customer_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" ItemStyle-CssClass="grid-ItemName" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Cust_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile Number" ItemStyle-CssClass="grid-ItemName"
                                                HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Mobile_no") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Qty" ItemStyle-CssClass="grid-Qty" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Total_Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount" ItemStyle-CssClass="grid-TotalAmt" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("Total_Amt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Print" ItemStyle-CssClass="grid-TotalAmt" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnPrintBill" runat="server" OnClientClick="aspnetForm.target='_blank';"
                                                        CommandName="PrintRecord" CssClass="btn btn-success rounded" Text="Print Bill"
                                                        CommandArgument='<%# Eval("DC_No") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <div class="col-md-12" runat="server" id="ErrorMsg">
                                <label>
                                    <b>No Record Found</b></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
